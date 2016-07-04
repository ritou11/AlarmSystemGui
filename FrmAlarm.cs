using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace AlarmSystem
{
    public partial class FrmAlarm : Form
    {
        private readonly SerialPort m_Sp1 = new SerialPort();
        private int m_Count;
        private int m_RCount;
        private readonly List<byte> m_LstRecv = new List<byte>();
        private readonly ManualResetEvent m_EventX = new ManualResetEvent(false);
        private static byte m_WaitForFlag;
        private bool m_ShowConsole = true;
        private bool m_Conn;
        private readonly AlarmStatus m_Alas = new AlarmStatus();


        public bool sendCommand(string cmd)
        {
            m_Sp1.Encoding = Encoding.Default;
            if (checkBoxByTimeSend.Checked)
                timerSend.Enabled = true;
            else
                timerSend.Enabled = false;

            if (!m_Sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return false;
            }

            var strSend = cmd;
            byte[] byteBuffer;
            if (!Command.DealCommand(out byteBuffer, strSend))
            {
                MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                timerSend.Enabled = false;
                return false;
            }

            m_Sp1.Write(byteBuffer, 0, byteBuffer.Length);

            txtBoxRxtData.AppendText("\r\n" + "PC->PN532:" + "\r\n" + "    " + strSend);

            txtBoxRxtData.Focus();
            txtBoxRxtData.Select(txtBoxRxtData.Text.Length - 1, 0);
            txtBoxRxtData.ScrollToCaret();

            m_Count += byteBuffer.Length;
            tsSend.Text = "T：" + m_Count + "   ";
            tsRec.Text = "R：" + m_RCount + "   ";
            return true;
        }

        public bool sendCommand(string cmd, bool isWaiting)
        {
            if (checkBoxByTimeSend.Checked)
                timerSend.Enabled = true;
            else
                timerSend.Enabled = false;

            if (!m_Sp1.IsOpen)
            {
                MessageBox.Show("请先打开串口！", "Error");
                return false;
            }

            var strSend = cmd;
            byte[] byteBuffer;
            if (!Command.DealCommand(out byteBuffer, strSend))
            {
                MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                timerSend.Enabled = false;
                return false;
            }
            if (isWaiting)
            {
                for (var i = 0; i < byteBuffer.Length - 1; i++)
                    if (byteBuffer[i] == 0xD4)
                        m_WaitForFlag = (byte)(byteBuffer[i + 1] + 1);
                m_EventX.Reset();
            }

            m_Sp1.Write(byteBuffer, 0, byteBuffer.Length);

            txtBoxRxtData.AppendText("\r\n" + "PC->PN532:" + "\r\n" + "    " + strSend);

            txtBoxRxtData.Focus();
            txtBoxRxtData.Select(txtBoxRxtData.Text.Length - 1, 0);
            txtBoxRxtData.ScrollToCaret();

            m_Count += byteBuffer.Length;
            tsSend.Text = "T：" + m_Count + "   ";
            tsRec.Text = "R：" + m_RCount + "   ";
            return true;
        }

        public bool sendCommand(byte[] byteBuffer)
        {
            if (checkBoxByTimeSend.Checked)
                timerSend.Enabled = true;
            else
                timerSend.Enabled = false;

            if (!m_Sp1.IsOpen)
            {
                MessageBox.Show("请先打开串口！", "Error");
                return false;
            }

            m_Sp1.Write(byteBuffer, 0, byteBuffer.Length);

            txtBoxRxtData.AppendText("\r\n" + "PC->PN532:" + "\r\n" + "    ");
            for (var i = 0; i < byteBuffer.Length; i++)
                txtBoxRxtData.AppendText(byteBuffer[i].ToString("X2") + " ");

            txtBoxRxtData.Focus();
            txtBoxRxtData.Select(txtBoxRxtData.Text.Length - 1, 0);
            txtBoxRxtData.ScrollToCaret();

            m_Count += byteBuffer.Length;
            tsSend.Text = "T：" + m_Count + "   ";
            tsRec.Text = "R：" + m_RCount + "   ";
            return true;
        }

        public FrmAlarm()
        {
            InitializeComponent();
            m_Alas.Update(0, 0, false, m_Conn, !m_Conn);
            UpdateLbState();
        }

        public void UpdateLbState()
        {
            //TODO:　More actions when state changes e.g. color/alert/email
            switch (m_Alas.AssertState())
            {
                case AlarmStatus.State.Disabled:
                    lbState.Text = "未开启";
                    break;
                case AlarmStatus.State.A1:
                    lbState.Text = "一级警报";
                    break;
                case AlarmStatus.State.A2:
                    lbState.Text = "二级警报";
                    break;
                case AlarmStatus.State.A3:
                    lbState.Text = "三级警报";
                    break;
                case AlarmStatus.State.A4:
                    lbState.Text = "四级警报";
                    break;
                case AlarmStatus.State.Norm:
                    lbState.Text = "安全";
                    break;
                case AlarmStatus.State.Err:
                    lbState.Text = "错误";
                    break;
            }
        }

        private void ListPorts()
        {
            comboBoxSerialPorts.Items.Clear();
            foreach (var s in SerialPort.GetPortNames())
                comboBoxSerialPorts.Items.Add(s);
        }

        private void AlarmSystem_Load(object sender, EventArgs e)
        {
            Profile.LoadProfile(); //加载所有
            m_Sp1.Encoding = Encoding.Default;
            // 预置波特率
            switch (Profile.GBaudrate)
            {
                case "300":
                    comboBoxBaudRate.SelectedIndex = 0;
                    break;
                case "600":
                    comboBoxBaudRate.SelectedIndex = 1;
                    break;
                case "1200":
                    comboBoxBaudRate.SelectedIndex = 2;
                    break;
                case "2400":
                    comboBoxBaudRate.SelectedIndex = 3;
                    break;
                case "4800":
                    comboBoxBaudRate.SelectedIndex = 4;
                    break;
                case "9600":
                    comboBoxBaudRate.SelectedIndex = 5;
                    break;
                case "19200":
                    comboBoxBaudRate.SelectedIndex = 6;
                    break;
                case "38400":
                    comboBoxBaudRate.SelectedIndex = 7;
                    break;
                case "57600":
                    comboBoxBaudRate.SelectedIndex = 8;
                    break;
                case "115200":
                    comboBoxBaudRate.SelectedIndex = 9;
                    break;
                case "230400":
                    comboBoxBaudRate.SelectedIndex = 10;
                    break;
                case "460800":
                    comboBoxBaudRate.SelectedIndex = 11;
                    break;
                case "921600":
                    comboBoxBaudRate.SelectedIndex = 12;
                    break;
                case "1382400":
                    comboBoxBaudRate.SelectedIndex = 13;
                    break;
                default:
                    {
                        MessageBox.Show("波特率预置参数错误。");
                        return;
                    }
            }
            //预置数据位
            switch (Profile.GDatabits)
            {
                case "5":
                    comboBoxWordLength.SelectedIndex = 0;
                    break;
                case "6":
                    comboBoxWordLength.SelectedIndex = 1;
                    break;
                case "7":
                    comboBoxWordLength.SelectedIndex = 2;
                    break;
                case "8":
                    comboBoxWordLength.SelectedIndex = 3;
                    break;
                default:
                    {
                        MessageBox.Show("数据位预置参数错误。");
                        return;
                    }
            }
            //预置停止位
            switch (Profile.GStop)
            {
                case "1":
                    comboBoxStopBits.SelectedIndex = 0;
                    break;
                case "1.5":
                    comboBoxStopBits.SelectedIndex = 1;
                    break;
                case "2":
                    comboBoxStopBits.SelectedIndex = 2;
                    break;
                default:
                    {
                        MessageBox.Show("停止位预置参数错误。");
                        return;
                    }
            }
            //预置校验位
            switch (Profile.GParity)
            {
                case "NONE":
                    comboBoxParity.SelectedIndex = 0;
                    break;
                case "ODD":
                    comboBoxParity.SelectedIndex = 1;
                    break;
                case "EVEN":
                    comboBoxParity.SelectedIndex = 2;
                    break;
                default:
                    {
                        MessageBox.Show("校验位预置参数错误。");
                        return;
                    }
            }
            //检查是否含有串口
            var str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }
            ListPorts();
            CheckForIllegalCrossThreadCalls = false;
            m_Sp1.DataReceived += sp1_DataReceived;
            //准备就绪              
            m_Sp1.DtrEnable = true;
            m_Sp1.RtsEnable = true;

            m_Sp1.Close();
        }

        private void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            m_Sp1.Encoding = Encoding.Default;

            if (m_Sp1.IsOpen)
            {
                m_RCount += m_Sp1.BytesToRead;
                string stt;
                stt = "T：" + m_Count + "   ";
                tsSend.Text = stt;
                stt = "R：" + m_RCount + "   ";
                tsRec.Text = stt;
                try
                {
                    var receivedData = new Byte[m_Sp1.BytesToRead]; //创建接收字节数组
                    m_Sp1.Read(receivedData, 0, receivedData.Length); //读取数据
                    m_Sp1.DiscardInBuffer(); //清空SerialPort控件的Buffer
                    m_LstRecv.AddRange(receivedData);

                    var strRcv = new StringBuilder();
                    for (var i = 0; i < receivedData.Length; i++) //窗体显示
                        strRcv.Append(receivedData[i].ToString("X2") + " "); //16进制显示
                    txtBoxRxtData.AppendText("\r\n" + "FPGA->PC:" + "\r\n" + "    " + strRcv);

                    txtBoxRxtData.Focus();
                    txtBoxRxtData.Select(txtBoxRxtData.Text.Length - 1, 0);
                    txtBoxRxtData.ScrollToCaret();

                    var curBuffer = m_LstRecv.ToArray();
                    var removed = 0;
                    foreach (var frm in Command.GetFrame(curBuffer))
                    {
                        m_LstRecv.RemoveRange(frm.StartI - removed, 8);
                        removed += 8;
                        lbIllum.Text = frm.Illum.ToString();
                        lbDist.Text = frm.Dist.ToString();
                        lbAcl2.Text = frm.Acl2.ToString();
                        m_Alas.Update(frm.Dist, frm.Illum, frm.Acl2, m_Conn, false);
                        UpdateLbState();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "出错提示");
                }
            }
            else
                MessageBox.Show("请打开某个串口", "错误提示");
        }

        private void buttonOpenOrCloseCom_Click(object sender, EventArgs e)
        {
            if (!m_Sp1.IsOpen)
                try
                {
                    //设置串口号
                    var serialName = comboBoxSerialPorts.Text;
                    if (serialName == "")
                    {
                        ListPorts();
                        return;
                    }
                    m_Sp1.PortName = serialName;

                    //设置各“串口设置”
                    var strBaudRate = comboBoxBaudRate.Text;
                    var strDateBits = comboBoxWordLength.Text;
                    var strStopBits = comboBoxStopBits.Text;

                    var iBaudRate = Convert.ToInt32(strBaudRate);
                    var iDateBits = Convert.ToInt32(strDateBits);

                    m_Sp1.BaudRate = iBaudRate; //波特率
                    m_Sp1.DataBits = iDateBits; //数据位
                    switch (comboBoxStopBits.Text) //停止位
                    {
                        case "1":
                            m_Sp1.StopBits = StopBits.One;
                            break;
                        case "1.5":
                            m_Sp1.StopBits = StopBits.OnePointFive;
                            break;
                        case "2":
                            m_Sp1.StopBits = StopBits.Two;
                            break;
                        default:
                            MessageBox.Show("Error：参数不正确!", "Error");
                            break;
                    }
                    switch (comboBoxParity.Text) //校验位
                    {
                        case "无":
                            m_Sp1.Parity = Parity.None;
                            break;
                        case "奇校验":
                            m_Sp1.Parity = Parity.Odd;
                            break;
                        case "偶校验":
                            m_Sp1.Parity = Parity.Even;
                            break;
                        default:
                            MessageBox.Show("Error：参数不正确!", "Error");
                            break;
                    }

                    if (m_Sp1.IsOpen) //如果打开状态，则先关闭一下
                        m_Sp1.Close();
                    //状态栏设置
                    tsSpNum.Text = "串口号：" + m_Sp1.PortName + "  ";
                    tsBaudRate.Text = "波特率：" + m_Sp1.BaudRate + "  ";
                    tsDataBits.Text = "数据位：" + m_Sp1.DataBits + "  ";
                    tsStopBits.Text = "停止位：" + m_Sp1.StopBits + "  ";
                    tsParity.Text = "校验位：" + m_Sp1.Parity + "   ";

                    //设置必要控件不可用
                    comboBoxSerialPorts.Enabled = false;
                    comboBoxBaudRate.Enabled = false;
                    comboBoxWordLength.Enabled = false;
                    comboBoxStopBits.Enabled = false;
                    comboBoxParity.Enabled = false;

                    m_Sp1.Open(); //打开串口
                    buttonOpenOrCloseCom.Text = "关闭串口";
                    m_Conn = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    timerSend.Enabled = false;
                    return;
                }
            else
            {
                //状态栏设置
                tsSpNum.Text = "串口号：未指定  ";
                tsBaudRate.Text = "波特率：未指定  ";
                tsDataBits.Text = "数据位：未指定  ";
                tsStopBits.Text = "停止位：未指定  ";
                tsParity.Text = "校验位：未指定   ";
                //恢复控件功能
                //设置必要控件不可用
                comboBoxSerialPorts.Enabled = true;
                comboBoxBaudRate.Enabled = true;
                comboBoxWordLength.Enabled = true;
                comboBoxStopBits.Enabled = true;
                comboBoxParity.Enabled = true;

                m_Sp1.Close(); //关闭串口
                buttonOpenOrCloseCom.Text = "打开串口";
                timerSend.Enabled = false; //关闭计时器
                m_Conn = false;
            }
            m_Alas.Update(0, 0, false, m_Conn, !m_Conn);
            UpdateLbState();
        }

        private void buttonCleanWindows_Click(object sender, EventArgs e)
        {
            txtBoxRxtData.Text = "";
            m_Count = m_RCount = 0;
        }

        //关闭时事件

        private void AlarmSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Profile.SaveProfile();
            m_Sp1.Close();
        }

        private void txtBoxRxtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            //正则匹配
            var patten = "[0-9a-fA-F]|\b|0x|0X| "; //“\b”：退格键
            var r = new Regex(patten);
            var m = r.Match(e.KeyChar.ToString());

            if (m.Success)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void timerSend_Tick(object sender, EventArgs e)
        {
            //转换时间间隔
            var strSecond = textBoxByTimeSend.Text;
            try
            {
                var isecond = int.Parse(strSecond); //Interval以微秒为单位
                timerSend.Interval = isecond;
            }
            catch (Exception)
            {
                timerSend.Enabled = false;
                MessageBox.Show("错误的定时输入！", "Error");
            }
        }

        private void textBoxByTimeSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            var patten = "[0-9]|\b"; //“\b”：退格键
            var r = new Regex(patten);
            var m = r.Match(e.KeyChar.ToString());

            if (m.Success)
                e.Handled = false; //没操作“过”，系统会处理事件    
            else
                e.Handled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] cmd;
            Command.CalcCommand(out cmd, txtSend.Text);
            sendCommand(cmd);
        }

        private void lbState_Click(object sender, EventArgs e)
        {
            if (m_ShowConsole)
            {
                Size = new Size(386, 311);
                tabControl1.Visible = false;
                m_ShowConsole = false;
            }
            else
            {
                Size = new Size(660, 311);
                tabControl1.Visible = true;
                m_ShowConsole = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
