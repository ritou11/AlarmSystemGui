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
    public partial class Alarm : Form
    {
        SerialPort sp1 = new SerialPort();
        int T_count = 0;
        int R_count = 0;
        byte[] UID = new byte[8] { 00, 00, 00, 00, 00, 00, 00, 00 };
        byte CmdNum = 0;
        int UID_Type = 4;
        List<byte> lstRecv=new List<byte>();
        ManualResetEvent eventX=new ManualResetEvent(false);
        static byte wait_for_flag=0x00;

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

        public Alarm()
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

            radioButtonKeyB.Checked = false;
            radioButtonKeyA.Checked = true;

            labelUID.Text = "00 00 00 00";

            // sp1.ReadTimeout = 200000000;
            //设置数据读取超时为1秒
            //  sp1.ReadTimeout = 1000;

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

                    int usedList = 0;
                    foreach(var s in Command.getFrame(lstRecv.ToArray()))
                    {
                        switch (s.type)
                        {
                            case 0x4B:
                                labelUID.Text = "";
                                for (int i = 0; i < s.cont[5]; i++)
                                {
                                    UID[i] = s.cont[i + 6];
                                    labelUID.Text += UID[i].ToString("X2")+" ";
                                }
                                break;
                            case 0x87:
                                string str="";
                                for (int i = 1; i < s.cont.Length; i++) str+=(char)s.cont[i];
                                txtBoxRxtData.AppendText("\r\nReceived Data As a Target:---<"+str+">---;\r\n");
                                break;
                            case 0x15:
                                if (s.CheckSelf())
                                {
                                    labelWakeUp.Text = "唤醒成功";
                                    labelWakeUp.ForeColor = Color.Green;
                                }
                                else
                                {
                                    labelWakeUp.Text = "唤醒失败";
                                    labelWakeUp.ForeColor = Color.Red;
                                }
                                break;
                            case 0x41:
                                if (CmdNum == 0x01)
                                {
                                    if (s.CheckSelf() && s.cont[0] == 0x00)
                                    {
                                        labelVerifyKeyA.ForeColor = Color.Green;
                                        labelVerifyKeyA.Text = "验证成功";
                                    }
                                    else
                                    {
                                        labelVerifyKeyA.ForeColor = Color.Red;
                                        labelVerifyKeyA.Text = "验证失败";
                                    }                                    
                                }
                                else if (CmdNum == 0x02)
                                {
                                    if (s.CheckSelf() && s.cont[0] == 0x00)
                                    {
                                        labelReadData.ForeColor = Color.Green;
                                        foreach(var b in s.cont) labelReadData.Text +=b.ToString("X2")+" ";
                                    }
                                    else
                                    {
                                        labelReadData.ForeColor = Color.Red;
                                        labelReadData.Text = "读取失败";
                                    }
                                }
                                break;
                        }
                        if (s.type == wait_for_flag)
                        {
                            wait_for_flag = 0x00;
                            eventX.Set();
                        }
                        usedList += s.len + 7;
                    }

                    for (int i = 0; i < lstRecv.Count - 3; i++)
                        if (lstRecv[i] == 0x00 && lstRecv[i + 1] == 0x00 && lstRecv[i + 2] == 0xFF && lstRecv[i+3]!=0)
                        {
                            lstRecv.RemoveRange(i,usedList);
                            break;
                        }
                    
                    return;

                    for (int i = 0; i < receivedData.Length - 2; i++)
                    {
                        if (receivedData[i] == 0xD5)
                        {
                            if (receivedData[i+1] == 0x4B)
                            {
                                //UID[0] = receivedData[i + 8];
                                //UID[1] = receivedData[i + 9];
                                //UID[2] = receivedData[i + 10];
                                //UID[3] = receivedData[i + 11];
                                //labelUID.Text = UID[0].ToString("X2") + " " + UID[1].ToString("X2") + " " + UID[2].ToString("X2") + " " + UID[3].ToString("X2");
                                //if (receivedData[i + 7] == 0x07)
                                //{
                                //    UID[4] = receivedData[i + 12];
                                //    UID[5] = receivedData[i + 13];
                                //    UID[6] = receivedData[i + 14];
                                //    UID_Type = 7;
                                //    labelUID.Text += " " + UID[4].ToString("X2") + " " + UID[5].ToString("X2") + " " + UID[6].ToString("X2");
                                    
                                //    buttonVerifyKeyA.Enabled = false;
                                //    labelwritelength.Text = "每次输入4个字节数据";
                                //    labelTagType.Text = "Mifare UltraLight";
                                //    int wlen = textBoxWritedata.Text.Length;
                                //    if (textBoxWritedata.Text.Length > 13)
                                //    {
                                //        textBoxWritedata.Text = "00 01 02 03";
                                //    }
                                //}
                                //else
                                //{
                                //    UID_Type = 4;
                                //    labelTagType.Text = "Mifare S50";
                                //    buttonVerifyKeyA.Enabled = true;
                                //    textBoxWritedata.Text = "00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F";
                                //    labelwritelength.Text = "每次输入16字节数据";
                                //}

                            }
                            else if (CmdNum == 2)
                            {
                                if (receivedData[i + 2] == 0x00)
                                {
                                    labelVerifyKeyA.Text = "验证成功";
                                    labelVerifyKeyA.ForeColor = Color.Green;
                                }
                                else
                                {
                                    labelVerifyKeyA.Text = "验证失败";
                                    labelVerifyKeyA.ForeColor = Color.Red;
                                    MessageBox.Show("1、未获取UID号，请先获取UID号 \r\n\r\n2、此卡已经修改了读写权限，请更换验证方式试一下", "错误提示：");
                                }
                            }
                            else if (CmdNum == 3)
                            {
                                if (receivedData[i + 2] == 0x00)
                                {
                                    labelWrite.Text = "写入成功";
                                    labelWrite.ForeColor = Color.Green;
                                }
                                else
                                {
                                    labelWrite.Text = "写入失败";
                                    labelWrite.ForeColor = Color.Red;
                                }

                            }
                            else if (CmdNum == 4)
                            {
                                labelReadData.Text = "";
                                byte checkcode = 0;
                                byte temp = 0;
                                for (int m = i; m < receivedData.Length - 2; m++)
                                {
                                    temp += receivedData[m];
                                }
                                checkcode = (byte)(0x100 - temp);
                                if (receivedData[receivedData.Length - 2] == checkcode)
                                {
                                    labelRead.Text = "读取成功";
                                    labelRead.ForeColor = Color.Green;
                                    if (UID_Type == 4)
                                    {
                                        for (int j = 0; j < 16; j++)
                                        {
                                            labelReadData.Text += receivedData[i + 3 + j].ToString("X2") + " ";
                                        }
                                    }
                                    else if (UID_Type == 7)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            labelReadData.Text += receivedData[i + 11 + j].ToString("X2") + " ";
                                        }
                                    }
                                }
                                else
                                {
                                    labelRead.Text = "读取失败";
                                    labelRead.ForeColor = Color.Red;
                                    labelReadData.Text = "";
                                }

                            }
                            //else if (CmdNum == 0)
                            //{
                            //    if (receivedData[i + 1] == 0x15)
                            //    {

                            //    }
                            //    else
                            //    {
                            //        //labelWakeUp.Text = "唤醒失败";
                            //        //labelWakeUp.ForeColor = Color.Red;
                            //    }
                            //}
                        }
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

        private void Initiator()
        {
            
        }
        public void Target()
        {
            sendCommand(Command.Wakeup,true);            
            eventX.WaitOne(Timeout.Infinite,true);
            Thread.Sleep(100);          
            
            sendCommand(Command.TargetInit,true);
            eventX.WaitOne(Timeout.Infinite, true);

            sendCommand(Command.TgGetData,true);
            eventX.WaitOne(Timeout.Infinite, true);
            Thread.Sleep(100);
            
            byte[] cmd;
            byte[] bytesToSend = Encoding.Default.GetBytes(txtSend.Text);
            byte[] data = new byte[bytesToSend.Length + 1];
            data[0] = 0x8E;
            Array.Copy(bytesToSend, 0, data, 1, bytesToSend.Length);
            Command.calcCommand(out cmd, data);
            sendCommand(cmd);
            eventX.WaitOne(Timeout.Infinite, true);
        }
        private void buttonWakeUp_Click(object sender, EventArgs e)
        {
            CmdNum = 0;

            if (checkBoxByTimeSend.Checked)  timerSend.Enabled = true;
            else timerSend.Enabled = false;

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            string strSend = Command.Wakeup;
            byte[] byteBuffer;
            if (!Command.dealCommand(out byteBuffer, strSend))
            {
                MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                timerSend.Enabled = false;
                return;
            }

            sp1.Write(byteBuffer, 0, byteBuffer.Length);

            txtBoxRxtData.Text += "\r\n" + "PC->PN532:" + "\r\n" + "    " + strSend;

            T_count += byteBuffer.Length;
            tsSend.Text = "T：" + T_count.ToString() + "   ";
            tsRec.Text = "R：" + R_count.ToString() + "   ";
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
                if (timerSend.Enabled == true)
                {
                    buttonWakeUp.PerformClick();
                }
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

        private void buttonVerifyKeyA_Click(object sender, EventArgs e)
        {
            byte loc=0x02;
            sendCommand(Command.InDataExchange(0x01,"60",loc.ToString("X2"),"FF FF FF FF FF FF",UID[0].ToString("X2"), UID[1].ToString("X2"), UID[2].ToString("X2"), UID[3].ToString("X2")));
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            sp1.Encoding = System.Text.Encoding.Default;
            CmdNum = 3;

            if (checkBoxByTimeSend.Checked) timerSend.Enabled = true;
            else timerSend.Enabled = false;

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            if (checkBoxkeywrite.Checked == true)
            {
                MessageBox.Show("请谨慎修改，存储区读写权限及读写密码； \r\n \r\n后果严重，暂不开放此权限；\r\n  \r\n若用到此项功能，请联系作者。", "警告：");
            }

            // String strSend = "00 00 FF 15 EB D4 40 01 A0 02 00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F D1 00"; 
            String strSend;
            if (UID_Type == 4)
            {
                strSend = Command.getStrWriteData4(textBoxWritedata.Text);
            }
            else if (UID_Type == 7)
            {
                strSend = Command.getStrWriteData7(textBoxWritedata.Text);
            }
            else return;
            
            byte[] tmpByteBuffer;
            if (!Command.dealCommand(out tmpByteBuffer,strSend))
            {
                MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                timerSend.Enabled = false;
                return;
            }
            byte[] byteBuffer = new byte[tmpByteBuffer.Length+2];
            for(int i = 0; i < tmpByteBuffer.Length; i++)
            {
                byteBuffer[i] = tmpByteBuffer[i];
            }
            byte temp = 0;
            for (int i = 5; i < byteBuffer.Length - 2; i++)
            {
                temp += byteBuffer[i];
            }
            byteBuffer[byteBuffer.Length - 2] = (byte)(0x100 - temp);
            byteBuffer[byteBuffer.Length - 1] = (byte)(0x00);

            sp1.Write(byteBuffer, 0, byteBuffer.Length);

            txtBoxRxtData.Text += "\r\n" + "PC->PN532:" + "\r\n" + "    " + strSend + " " + byteBuffer[byteBuffer.Length - 2].ToString("X") + " " + byteBuffer[byteBuffer.Length - 1].ToString("X");
            T_count += byteBuffer.Length;
            tsSend.Text = "T：" + T_count.ToString() + "   ";
            tsRec.Text = "R：" + R_count.ToString() + "   ";
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            sendCommand(Command.ReadCard);
        }

        private void buttonGetUID_Click(object sender, EventArgs e)
        {
            sp1.Encoding = System.Text.Encoding.Default;
            CmdNum = 1;

            if (checkBoxByTimeSend.Checked) timerSend.Enabled = true;
            else timerSend.Enabled = false;

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            String strSend = Command.ReadUID;
            byte[] byteBuffer;
            if (!Command.dealCommand(out byteBuffer, strSend))
            {
                MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                timerSend.Enabled = false;
                return;
            }
            sp1.Write(byteBuffer, 0, byteBuffer.Length);

            txtBoxRxtData.Text += "\r\n" + "PC->PN532:" + "\r\n" + "    " + strSend;
            T_count += byteBuffer.Length;
            tsSend.Text = "T：" + T_count.ToString() + "   ";
            tsRec.Text = "R：" + R_count.ToString() + "   ";
        }

        private void radioButtonKeyB_Click(object sender, EventArgs e)
        {
            radioButtonKeyA.Checked = false;
            radioButtonKeyB.Checked = true;
        }

        private void radioButtonKeyA_Click(object sender, EventArgs e)
        {
            radioButtonKeyB.Checked = false;
            radioButtonKeyA.Checked = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] cmd;
            Command.calcCommand(out cmd,txtSend.Text);
            sendCommand(cmd);
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            sendCommand(Command.TgGetData);
            MessageBox.Show("hhh");

            byte[] cmd;
            byte[] bytesToSend = Encoding.Default.GetBytes(txtSend.Text);
            byte[] data = new byte[bytesToSend.Length + 1];
            data[0] = 0x8E;
            Array.Copy(bytesToSend, 0, data, 1, bytesToSend.Length);
            Command.calcCommand(out cmd, data);
            sendCommand(cmd);

        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            Thread threadTg = new Thread(new ThreadStart(Target));
            threadTg.IsBackground = true;
            threadTg.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] cmd;
            Command.dealCommand(out cmd,txtSend.Text);
            sendCommand(cmd);
        }
    }
}
