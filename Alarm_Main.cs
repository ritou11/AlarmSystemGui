using INIFILE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;

namespace alarm
{
    public partial class Alarm_Form : Form
    {
        SerialPort sp1 = new SerialPort();
        int T_count = 0;
        int R_count = 0;
        List<byte> lstRecv=new List<byte>();
        ManualResetEvent eventX=new ManualResetEvent(false);
        static byte wait_for_flag=0x00;
        private bool showConsole=true;
        public bool sendCommand(string cmd)
        {
            sp1.Encoding = System.Text.Encoding.Default;
            if (checkBoxByTimeSend.Checked) timerSend.Enabled = true;
            else timerSend.Enabled = false;

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return false;
            }

            string strSend = cmd;
            byte[] byteBuffer;
            if (!Command.dealCommand(out byteBuffer,strSend))
            {
                MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                timerSend.Enabled = false;
                return false;
            }

            sp1.Write(byteBuffer, 0, byteBuffer.Length);
 
            txtBoxRxtData.AppendText("\r\n" + "PC->PN532:" + "\r\n" + "    " + strSend);

            txtBoxRxtData.Focus();
            txtBoxRxtData.Select(txtBoxRxtData.Text.Length - 1, 0);
            txtBoxRxtData.ScrollToCaret();

            T_count += byteBuffer.Length;
            tsSend.Text = "T：" + T_count.ToString() + "   ";
            tsRec.Text = "R：" + R_count.ToString() + "   ";
            return true;
        }
        public bool sendCommand(string cmd,bool isWaiting)
        {
            if (checkBoxByTimeSend.Checked) timerSend.Enabled = true;
            else timerSend.Enabled = false;

            if (!sp1.IsOpen)
            {
                MessageBox.Show("请先打开串口！", "Error");
                return false;
            }

            string strSend = cmd;
            byte[] byteBuffer;
            if (!Command.dealCommand(out byteBuffer,strSend))
            {
                MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                timerSend.Enabled = false;
                return false;
            }
            if (isWaiting)
            {
                for (int i = 0; i < byteBuffer.Length - 1; i++)
                    if (byteBuffer[i] == 0xD4)
                        wait_for_flag = (byte)(byteBuffer[i + 1]+1);
                eventX.Reset();
            }

            sp1.Write(byteBuffer, 0, byteBuffer.Length);
            
            txtBoxRxtData.AppendText( "\r\n" + "PC->PN532:" + "\r\n" + "    " + strSend);

            txtBoxRxtData.Focus();
            txtBoxRxtData.Select(txtBoxRxtData.Text.Length - 1, 0);
            txtBoxRxtData.ScrollToCaret();

            T_count += byteBuffer.Length;
            tsSend.Text = "T：" + T_count.ToString() + "   ";
            tsRec.Text = "R：" + R_count.ToString() + "   ";
            return true;
        }
        public bool sendCommand(byte[] byteBuffer)
        {
            if (checkBoxByTimeSend.Checked) timerSend.Enabled = true;
            else timerSend.Enabled = false;

            if (!sp1.IsOpen)
            {
                MessageBox.Show("请先打开串口！", "Error");
                return false;
            }
            
            sp1.Write(byteBuffer, 0, byteBuffer.Length);

            txtBoxRxtData.AppendText( "\r\n" + "PC->PN532:" + "\r\n" + "    ");
            for (int i = 0; i < byteBuffer.Length; i++) txtBoxRxtData.AppendText( byteBuffer[i].ToString("X2")+" ");
            
            txtBoxRxtData.Focus();
            txtBoxRxtData.Select(txtBoxRxtData.Text.Length - 1, 0);
            txtBoxRxtData.ScrollToCaret();

            T_count += byteBuffer.Length;
            tsSend.Text = "T：" + T_count.ToString() + "   ";
            tsRec.Text = "R：" + R_count.ToString() + "   ";
            return true;
        }

        public Alarm_Form()
        {
            InitializeComponent();
        }

        private void ListPorts()
        {
            comboBoxSerialPorts.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBoxSerialPorts.Items.Add(s);
            }
        }

        private void AlarmSystem_Load(object sender, EventArgs e)
        {
            INIFILE.Profile.LoadProfile();//加载所有
            sp1.Encoding = System.Text.Encoding.Default;
            // 预置波特率
            switch (Profile.G_BAUDRATE)
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
            switch (Profile.G_DATABITS)
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
            switch (Profile.G_STOP)
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
            switch (Profile.G_PARITY)
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
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }
            ListPorts();
            Control.CheckForIllegalCrossThreadCalls = false;
            sp1.DataReceived += new SerialDataReceivedEventHandler(sp1_DataReceived);
            //准备就绪              
            sp1.DtrEnable = true;
            sp1.RtsEnable = true;

            sp1.Close();
        }

        void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            sp1.Encoding = System.Text.Encoding.Default;

            if (sp1.IsOpen)
            {
                R_count += sp1.BytesToRead;
                string stt;
                stt = "T：" + T_count.ToString() + "   ";
                tsSend.Text = stt;
                stt = "R：" + R_count.ToString() + "   ";
                tsRec.Text = stt;
                try
                {
                    Byte[] receivedData = new Byte[sp1.BytesToRead];        //创建接收字节数组
                    sp1.Read(receivedData, 0, receivedData.Length);         //读取数据
                    sp1.DiscardInBuffer();                                  //清空SerialPort控件的Buffer
                    lstRecv.AddRange(receivedData);

                    StringBuilder strRcv = new StringBuilder();
                    for (int i = 0; i < receivedData.Length; i++) //窗体显示
                    {
                        strRcv.Append(receivedData[i].ToString("X2") + " ");  //16进制显示
                    }
                    txtBoxRxtData.AppendText("\r\n" + "PN532->PC:" + "\r\n" + "    " + strRcv.ToString());

                    txtBoxRxtData.Focus();
                    txtBoxRxtData.Select(txtBoxRxtData.Text.Length - 1, 0);
                    txtBoxRxtData.ScrollToCaret();

                    int usedLength = 0;          
                      
                    //TODO...

                    for (int i = 0; i < lstRecv.Count - 3; i++)
                        if (lstRecv[i] == 0x00 && lstRecv[i + 1] == 0x00 && lstRecv[i + 2] == 0xFF && lstRecv[i+3]!=0)
                        {
                            lstRecv.RemoveRange(i,usedLength);
                            break;
                        }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "出错提示");
                }
            }
            else
            {
                MessageBox.Show("请打开某个串口", "错误提示");
            }
        }

        private void buttonOpenOrCloseCom_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                try
                {
                    //设置串口号
                    string serialName = comboBoxSerialPorts.Text;
                    if (serialName == "")
                    {
                        ListPorts();
                        return;
                    }
                    sp1.PortName = serialName;

                    //设置各“串口设置”
                    string strBaudRate = comboBoxBaudRate.Text;
                    string strDateBits = comboBoxWordLength.Text;
                    string strStopBits = comboBoxStopBits.Text;

                    Int32 iBaudRate = Convert.ToInt32(strBaudRate);
                    Int32 iDateBits = Convert.ToInt32(strDateBits);

                    sp1.BaudRate = iBaudRate;       //波特率
                    sp1.DataBits = iDateBits;       //数据位
                    switch (comboBoxStopBits.Text)            //停止位
                    {
                        case "1":
                            sp1.StopBits = StopBits.One;
                            break;
                        case "1.5":
                            sp1.StopBits = StopBits.OnePointFive;
                            break;
                        case "2":
                            sp1.StopBits = StopBits.Two;
                            break;
                        default:
                            MessageBox.Show("Error：参数不正确!", "Error");
                            break;
                    }
                    switch (comboBoxParity.Text)             //校验位
                    {
                        case "无":
                            sp1.Parity = Parity.None;
                            break;
                        case "奇校验":
                            sp1.Parity = Parity.Odd;
                            break;
                        case "偶校验":
                            sp1.Parity = Parity.Even;
                            break;
                        default:
                            MessageBox.Show("Error：参数不正确!", "Error");
                            break;
                    }

                    if (sp1.IsOpen == true)//如果打开状态，则先关闭一下
                    {
                        sp1.Close();
                    }
                    //状态栏设置
                    tsSpNum.Text = "串口号：" + sp1.PortName + "  ";
                    tsBaudRate.Text = "波特率：" + sp1.BaudRate + "  ";
                    tsDataBits.Text = "数据位：" + sp1.DataBits + "  ";
                    tsStopBits.Text = "停止位：" + sp1.StopBits + "  ";
                    tsParity.Text = "校验位：" + sp1.Parity + "   ";
                    
                    //设置必要控件不可用
                    comboBoxSerialPorts.Enabled = false;
                    comboBoxBaudRate.Enabled = false;
                    comboBoxWordLength.Enabled = false;
                    comboBoxStopBits.Enabled = false;
                    comboBoxParity.Enabled = false;

                    sp1.Open();     //打开串口
                    buttonOpenOrCloseCom.Text = "关闭串口";
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    timerSend.Enabled = false;
                    return;
                }
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

                sp1.Close();                    //关闭串口
                buttonOpenOrCloseCom.Text = "打开串口";
                timerSend.Enabled = false;         //关闭计时器
            }
        }

        private void buttonCleanWindows_Click(object sender, EventArgs e)
        {
            txtBoxRxtData.Text = "";
            T_count = R_count = 0;
        }
        //关闭时事件

        private void AlarmSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            INIFILE.Profile.SaveProfile();
            sp1.Close();
        }

        private void txtBoxRxtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            //正则匹配
            string patten = "[0-9a-fA-F]|\b|0x|0X| "; //“\b”：退格键
            Regex r = new Regex(patten);
            Match m = r.Match(e.KeyChar.ToString());

            if (m.Success)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void timerSend_Tick(object sender, EventArgs e)
        {
            //转换时间间隔
            string strSecond = textBoxByTimeSend.Text;
            try
            {
                int isecond = int.Parse(strSecond);//Interval以微秒为单位
                timerSend.Interval = isecond;
            }
            catch (System.Exception)
            {
                timerSend.Enabled = false;
                MessageBox.Show("错误的定时输入！", "Error");
            }
        }

        private void textBoxByTimeSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            string patten = "[0-9]|\b"; //“\b”：退格键
            Regex r = new Regex(patten);
            Match m = r.Match(e.KeyChar.ToString());

            if (m.Success)
            {
                e.Handled = false;   //没操作“过”，系统会处理事件    
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] cmd;
            Command.calcCommand(out cmd,txtSend.Text);
            sendCommand(cmd);
        }
        private void lbState_Click(object sender, EventArgs e)
        {
            if (showConsole)
            {
                this.Size = new Size(386,311);
                tabControl1.Visible = false;
                showConsole = false;
            }
            else
            {
                this.Size = new Size(660, 311);
                tabControl1.Visible = true;
                showConsole = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
