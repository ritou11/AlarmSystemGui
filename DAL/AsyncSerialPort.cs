﻿using System;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Threading;
using AlarmSystem.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AlarmSystem.DAL
{
    public delegate int PackageArrivedEventHandler(byte[] package);

    public delegate void OpenPortEventHandler(Exception e);

    public delegate void ClosePortEventHandler(Exception e);

    public delegate void ReadWriteErrorEventHandler(Exception e);

    public class AsyncSerialPort
    {
        public event PackageArrivedEventHandler PackageArrived;
        public event OpenPortEventHandler OpenPort;
        public event ClosePortEventHandler ClosePort;
        public event ReadWriteErrorEventHandler ReadWriteError;

        public AsyncSerialPort(Profile profile, int packageLength)
        {
            m_TheProfile = profile;
            PackageLength = packageLength;

            m_LockPortRx = new object();
            m_LockPortTx = new object();

            m_RxThread = new Thread(RxEnterPoint) { IsBackground = true };
            m_TxThread = new Thread(TxEnterPoint) { IsBackground = true };

            m_TxCollection = new BlockingCollection<byte[]>();

            m_RxThread.Start();
            m_TxThread.Start();
        }

        public byte StartMark { get; set; }
        public int PackageLength { get; set; }

        private Profile m_TheProfile;
        private readonly object m_LockPortRx;
        private readonly object m_LockPortTx;
        // ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
        private readonly Thread m_RxThread;
        private readonly Thread m_TxThread;
        // ReSharper restore PrivateFieldCanBeConvertedToLocalVariable
        private SerialPort m_Port;
        private readonly BlockingCollection<byte[]> m_TxCollection;
        private CancellationTokenSource m_CancelSource;

        private List<byte> m_Buffer;

        public bool Open(Profile profile, TimeSpan timeout)
        {
            if (!Monitor.TryEnter(m_LockPortRx, timeout))
                return false;

            try
            {
                m_TheProfile = profile;
                m_CancelSource = new CancellationTokenSource();
                Monitor.PulseAll(m_LockPortRx);
            }
            finally
            {
                Monitor.Exit(m_LockPortRx);
            }
            return true;
        }

        public void Close() => m_CancelSource.Cancel();

        public void Send(byte[] package) => m_TxCollection.Add(package);

        private void RxEnterPoint()
        {
            lock (m_LockPortRx)
            {
                while (true)
                {
                    Monitor.Wait(m_LockPortRx);
                    try
                    {
                        m_Port = new SerialPort(
                            m_TheProfile.Name,
                            m_TheProfile.BaudRate,
                            m_TheProfile.Parity,
                            m_TheProfile.DataBits,
                            m_TheProfile.StopBits);
                        m_Port.Open();
                        OpenPort?.Invoke(null);
                        lock (m_LockPortTx)
                            Monitor.PulseAll(m_LockPortTx);
                    }
                    catch (Exception e)
                    {
                        OpenPort?.Invoke(e);
                        continue;
                    }

                    var buffer = new byte[PackageLength];
                    m_Buffer = new List<byte>();
                    while (true)
                        try
                        {
                            var task =
                                m_Port.BaseStream.ReadAsync(
                                                            buffer,
                                                            0,
                                                            PackageLength,
                                                            m_CancelSource.Token);
                            task.Wait(m_CancelSource.Token);
                            var lng = task.Result;

                            m_Buffer.AddRange(buffer.Take(lng));
                            var lastPackageTail = PackageArrived?.Invoke(m_Buffer.ToArray());
                            if (lastPackageTail == null) continue;
                            if (lastPackageTail > 0)
                            {
                                m_Buffer.RemoveRange(0, (int)lastPackageTail + 1);
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            break;
                        }
                        catch (Exception e)
                        {
                            ReadWriteError?.Invoke(e);
                        }


                    try
                    {
                        m_Port.Close();
                        ClosePort?.Invoke(null);
                    }
                    catch (Exception e)
                    {
                        ClosePort?.Invoke(e);
                    }
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private void TxEnterPoint()
        {
            lock (m_LockPortTx)
            {
                while (true)
                {
                    Monitor.Wait(m_LockPortTx);

                    while (true)
                        try
                        {
                            var data = m_TxCollection.Take(m_CancelSource.Token);
                            m_Port.Write(data, 0, data.Length);
                        }
                        catch (OperationCanceledException)
                        {
                            break;
                        }
                        catch (Exception e)
                        {
                            ReadWriteError?.Invoke(e);
                        }
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}
