using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Timers;
using AlarmSystem.DAL;
using AlarmSystem.Entities;

namespace AlarmSystem.BLL
{
    [Flags]
    public enum AlarmingState
    {
        Unarmed = 0x7f000000,
        None = 0x00,
        Level1 = 0x01,
        Level2 = 0x02,
        Level3 = 0x04,
        Level4 = 0x08
    }

    public delegate void UpdateEventHandler(Report report, Report rawReport, double cusum);

    public delegate void ConnLostEventHandler();

    public delegate void ErrorEventHandler(Exception e);

    public class AlarmSystem
    {
        public const int MaxDist = 100;
        public const int MaxIllum = 1;
        public const double MaxAcc = 40;

        public event UpdateEventHandler Update;
        public event ConnLostEventHandler ConnLost;
        public event ErrorEventHandler Error;
        public event OpenPortEventHandler OpenPortResult;
        public event ClosePortEventHandler ClosePortResult;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public TimeSpan DefaultTimeout { get; set; }

        private TimeSpan m_WatchDogTimeout;

        // ReSharper disable once MemberCanBePrivate.Global
        public TimeSpan WatchDogTimeout
        {
            get { return m_WatchDogTimeout; }
            // ReSharper disable once UnusedMember.Global
            set
            {
                m_WatchDogTimeout = value;
                m_Watchdog.Interval = m_WatchDogTimeout.TotalMilliseconds;
            }
        }

        public bool ShakingEnabled { get; set; }
        public bool IlluminanceEnabled { get; set; }
        public bool DistanceEnabled { get; set; }

        public bool ConnectivityEnabled { get; set; }

        public Profile TheProfile { get; set; }

        public bool IsOpen { get; private set; }
        public AlarmingState State { get; private set; }
        public AlarmingState RealState { get; private set; }

        private readonly AsyncSerialPort m_Port;
        private readonly Timer m_Watchdog;

        //private readonly ISmoother m_IllumSmoother;
        private readonly CuSumEventDetecter m_AccSmoother;
        private readonly ISmoother m_DistSmoother;

        public AlarmSystem()
        {
            m_WatchDogTimeout = new TimeSpan(0, 0, 0, 0, 800);
            DefaultTimeout = new TimeSpan(0, 0, 0, 2);

            try
            {
                if (ProfileKeeper.IsExists())
                    TheProfile = ProfileKeeper.LoadProfile();
            }
            catch (Exception)
            {
                // ignore
            }
            if (TheProfile == null)
            {
                var ports = SerialPort.GetPortNames();
                var name = ports.Length == 0 ? "COM1" : ports[0];
                TheProfile =
                    new Profile
                        {
                            Name = name,
                            BaudRate = 115200,
                            DataBits = 8,
                            StopBits = StopBits.One,
                            Parity = Parity.None
                        };
                ProfileKeeper.SaveProfile(TheProfile);
            }

            ShakingEnabled = true;
            IlluminanceEnabled = true;
            DistanceEnabled = true;
            ConnectivityEnabled = true;

            RealState = AlarmingState.None;
            State = AlarmingState.Unarmed;
            m_Watchdog = new Timer(WatchDogTimeout.TotalMilliseconds) { AutoReset = false };
            m_Watchdog.Elapsed += Watchdog_Triggered;

            //m_IllumSmoother = new ExponentSmoother(0.2);
            m_AccSmoother = new CuSumEventDetecter(0.5, 0.9, MaxAcc);
            m_DistSmoother = new MinSmoother(5);

            m_Port = new AsyncSerialPort(TheProfile, 12);
            m_Port.OpenPort += Port_Open;
            m_Port.ClosePort += Port_Close;
            m_Port.PackageArrived += Port_Package;
            m_Port.ReadWriteError += Port_Error;

            IsOpen = false;
        }

        private void Watchdog_Triggered(object sender, ElapsedEventArgs e)
        {
            var old = RealState;
            RealState |= AlarmingState.Level4;

            if (ConnectivityEnabled &&
                !old.HasFlag(AlarmingState.Level4) &&
                RealState.HasFlag(AlarmingState.Level4) &&
                IsOpen)
            {
                State |= AlarmingState.Level4;
                ConnLost?.Invoke();
            }
        }

        public void OpenPort()
        {
            if (IsOpen)
                return;

            if (!m_Port.Open(TheProfile, DefaultTimeout))
                OpenPortResult?.Invoke(new TimeoutException("打开端口失败"));
        }

        public void ClosePort()
        {
            if (!IsOpen)
                return;

            RealState = AlarmingState.None;
            State = AlarmingState.Unarmed;

            m_Port.Close();
        }

        private void CheckAlarm(Report report)
        {
            var old = RealState;
            RealState = AlarmingState.None;
            if (report.Distance > MaxDist)
                RealState |= AlarmingState.Level1;
            if (report.Illuminance > MaxIllum)
                RealState |= AlarmingState.Level2;
            if (m_AccSmoother.Occured)
                RealState |= AlarmingState.Level3;
            m_Watchdog.Stop();
            if (ConnectivityEnabled)
                m_Watchdog.Start();

            if (!(DistanceEnabled || IlluminanceEnabled || ShakingEnabled || ConnectivityEnabled))
                State = AlarmingState.Unarmed;

            if (DistanceEnabled &&
                !old.HasFlag(AlarmingState.Level1) &&
                RealState.HasFlag(AlarmingState.Level1))
                State |= AlarmingState.Level1;
            if (IlluminanceEnabled &&
                !old.HasFlag(AlarmingState.Level2) &&
                RealState.HasFlag(AlarmingState.Level2))
                State |= AlarmingState.Level2;
            if (ShakingEnabled &&
                !old.HasFlag(AlarmingState.Level3) &&
                RealState.HasFlag(AlarmingState.Level3))
                State |= AlarmingState.Level3;
        }

        public void IgnoreAlarm()
        {
            if (State == AlarmingState.Unarmed)
                return;
            SendManagementPackage(ManagementPackageType.BuzzOff);
            State = AlarmingState.None;
            Update?.Invoke(null, null, double.NaN);
        }

        public void SendManagementPackage(ManagementPackageType type)
            => m_Port.Send(Packer.GenerateManagementPackage(type));

        private void Port_Error(Exception e) => Error?.Invoke(e);

        private bool Port_Package(IList<byte> package)
        {
            var rawReport = Packer.ParseReport(package);
            if (rawReport == null)
                return false;

            var report =
                new Report
                    {
                        Illuminance = rawReport.Illuminance,
                        //Illuminance = m_IllumSmoother.Update(rawReport.Illuminance),
                        Acceleration = m_AccSmoother.Update(rawReport.Acceleration),
                        Distance = m_DistSmoother.Update(rawReport.Distance),
                        IsBuzzerOn = rawReport.IsBuzzerOn,
                        RawBytes = rawReport.RawBytes,
                        TimeStamp = rawReport.TimeStamp
                    };

            CheckAlarm(report);
            Update?.Invoke(report, rawReport, m_AccSmoother.Diviation);
            return true;
        }

        private void Port_Open(Exception e)
        {
            if (e != null)
            {
                OpenPortResult?.Invoke(e);
                return;
            }

            IsOpen = true;

            if (!(DistanceEnabled || IlluminanceEnabled || ShakingEnabled || ConnectivityEnabled))
                State = AlarmingState.Unarmed;
            else
                State = AlarmingState.None;

            OpenPortResult?.Invoke(null);

            ProfileKeeper.SaveProfile(TheProfile);
        }

        private void Port_Close(Exception e)
        {
            if (e != null)
            {
                ClosePortResult?.Invoke(e);
                return;
            }

            IsOpen = false;
            State = AlarmingState.Unarmed;
            ClosePortResult?.Invoke(null);
        }
    }
}
