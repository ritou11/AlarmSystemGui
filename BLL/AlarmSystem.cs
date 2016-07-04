using System;
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

    public delegate void UpdateEventHandler(AlarmingState state, Report report);

    public delegate void ErrorEventHandler(Exception e);

    public class AlarmSystem
    {
        public event UpdateEventHandler Update;
        public event ErrorEventHandler Error;

        public TimeSpan DefaultTimeout { get; set; }

        private TimeSpan m_WatchDogTimeout;

        public TimeSpan WatchDogTimeout
        {
            get { return m_WatchDogTimeout; }
            set
            {
                m_WatchDogTimeout = value;
                m_Watchdog.Interval = m_WatchDogTimeout.TotalMilliseconds;
            }
        }

        public bool ShakingEnabled { get; set; }
        public bool IlluminanceEnabled { get; set; }
        public bool DistanceEnabled { get; set; }

        private bool m_ConnectivityEnabled;

        public bool ConnectivityEnabled
        {
            get { return m_ConnectivityEnabled; }
            set
            {
                if (m_ConnectivityEnabled == value)
                    return;

                m_ConnectivityEnabled = value;
                if (m_ConnectivityEnabled)
                    m_Watchdog.Start();
                else
                    m_Watchdog.Stop();
            }
        }

        private Profile m_TheProfile;

        public Profile TheProfile
        {
            get { return m_TheProfile; }
            set
            {
                if (m_TheProfile == value)
                    return;

                var old = m_TheProfile;
                m_TheProfile = value;
                m_Port.Close();
                if (!m_Port.Open(m_TheProfile, DefaultTimeout))
                {
                    m_TheProfile = old;
                    Error?.Invoke(new TimeoutException("更改端口配置失败"));
                    return;
                }
                ProfileKeeper.SaveProfile(m_TheProfile);
            }
        }

        private readonly AsyncSerialPort m_Port;
        private AlarmingState m_RealState;
        private AlarmingState m_State;
        private readonly Timer m_Watchdog;

        public AlarmSystem()
        {
            m_WatchDogTimeout = new TimeSpan(0, 0, 0, 0, 800);
            DefaultTimeout = new TimeSpan(0, 0, 0, 2);

            try
            {
                if (ProfileKeeper.IsExists())
                    m_TheProfile = ProfileKeeper.LoadProfile();
            }
            catch (Exception)
            {
                // ignore
            }
            if (m_TheProfile == null)
            {
                m_TheProfile =
                    new Profile
                    {
                        Name = "COM1",
                        BaudRate = 115200,
                        DataBits = 8,
                        StopBits = StopBits.One,
                        Parity = Parity.None
                    };
                ProfileKeeper.SaveProfile(m_TheProfile);
            }

            ShakingEnabled = false;
            IlluminanceEnabled = false;
            DistanceEnabled = false;
            m_ConnectivityEnabled = false;

            m_State = AlarmingState.None;
            m_Watchdog = new Timer(WatchDogTimeout.TotalMilliseconds) { AutoReset = false };
            m_Watchdog.Elapsed += Watchdog_Triggered;

            m_Port = new AsyncSerialPort(m_TheProfile, 8);
            m_Port.OpenPort += Port_Open;
            m_Port.ClosePort += Port_Close;
            m_Port.PackageArrived += Port_Package;
            m_Port.ReadWriteError += Port_Error;
            m_Port.Open(m_TheProfile, DefaultTimeout);
        }

        private void Watchdog_Triggered(object sender, ElapsedEventArgs e)
        {
            var old = m_RealState;
            m_RealState |= AlarmingState.Level4;

            if (ConnectivityEnabled &&
                !old.HasFlag(AlarmingState.Level4) &&
                m_RealState.HasFlag(AlarmingState.Level4))
                m_State |= AlarmingState.Level4;
        }

        public void ArmAll()
        {
            ShakingEnabled = true;
            IlluminanceEnabled = true;
            DistanceEnabled = true;
            ConnectivityEnabled = true;
        }

        public void UnarmAll()
        {
            ShakingEnabled = false;
            IlluminanceEnabled = false;
            DistanceEnabled = false;
            ConnectivityEnabled = false;
        }

        public void OpenPort()
        {
            if (!m_Port.Open(m_TheProfile, DefaultTimeout))
                Error?.Invoke(new TimeoutException("打开端口失败"));
        }

        public void UnarmAndClosePort()
        {
            m_RealState = AlarmingState.None;
            m_State = AlarmingState.Unarmed;

            m_Port.Close();
        }

        private void CheckAlarm(Report report)
        {
            var old = m_RealState;
            m_RealState = AlarmingState.None;
            if (report.Distance > 10)
                m_RealState |= AlarmingState.Level1;
            if (report.Illuminance > 5)
                m_RealState |= AlarmingState.Level2;
            if (report.IsShaking)
                m_RealState |= AlarmingState.Level3;
            if (ConnectivityEnabled)
            {
                m_Watchdog.Stop();
                m_Watchdog.Start();
            }

            if (DistanceEnabled &&
                !old.HasFlag(AlarmingState.Level1) &&
                m_RealState.HasFlag(AlarmingState.Level1))
                m_State |= AlarmingState.Level1;
            if (IlluminanceEnabled &&
                !old.HasFlag(AlarmingState.Level2) &&
                m_RealState.HasFlag(AlarmingState.Level2))
                m_State |= AlarmingState.Level2;
            if (ShakingEnabled &&
                !old.HasFlag(AlarmingState.Level3) &&
                m_RealState.HasFlag(AlarmingState.Level3))
                m_State |= AlarmingState.Level3;
        }

        public void IgnoreAlarm()
        {
            if (m_State == AlarmingState.Unarmed)
                return;

            m_State = AlarmingState.None;
            Update?.Invoke(m_State, null);
        }

        // TODO: use DAL.Packer
        public void SendManagementPackage(byte[] package) => m_Port.Send(package);

        private void Port_Error(Exception e) => Error?.Invoke(e);

        private void Port_Package(byte[] package)
        {
            var report = Packer.ParseReport(package);
            if (report == null)
            {
                Error?.Invoke(new ApplicationException("校验字错误"));
                return;
            }
            CheckAlarm(report);
            Update?.Invoke(m_State, report);
        }

        private void Port_Close(Exception e)
        {
            if (e == null)
            {
                m_State = AlarmingState.Unarmed;
                return;
            }
            Error?.Invoke(e);
        }

        private void Port_Open(Exception e)
        {
            if (e == null)
                return;
            Error?.Invoke(e);
        }
    }
}
