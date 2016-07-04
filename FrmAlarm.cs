using System;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using AlarmSystem.BLL;
using AlarmSystem.DAL;
using AlarmSystem.Entities;

namespace AlarmSystem
{
    public partial class FrmAlarm : Form
    {
        private readonly BLL.AlarmSystem m_Manager;
        private bool m_ShowConsole = true;

        public FrmAlarm()
        {
            InitializeComponent();

            comboBoxSerialPorts.Items.Clear();
            foreach (var s in SerialPort.GetPortNames())
                comboBoxSerialPorts.Items.Add(s);

            GetProfileFromManager();

            m_Manager = new BLL.AlarmSystem();
            m_Manager.Update += UpdateFromManger;
            m_Manager.Error += ErrorFromManager;
        }

        private void SetProfileToManager()
        {
            try
            {
                var profile =
                    new Profile
                        {
                            BaudRate = Convert.ToInt32(comboBoxBaudRate.Text),
                            DataBits = Convert.ToInt32(comboBoxWordLength.Text),
                            StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStopBits.Text),
                            Parity = (Parity)Enum.Parse(typeof(Parity), comboBoxParity.Text)
                        };
                m_Manager.TheProfile = profile;
            }
            catch (FormatException)
            {
                MessageBox.Show("格式错误", "错误");
            }
            catch (Exception e)
            {
                MessageBox.Show($"未知错误：{e}", "错误");
            }
        }

        private void GetProfileFromManager()
        {
            var profile = m_Manager.TheProfile;
            comboBoxBaudRate.Text = profile.BaudRate.ToString(CultureInfo.InvariantCulture);
            comboBoxWordLength.Text = profile.DataBits.ToString(CultureInfo.InvariantCulture);
            comboBoxStopBits.Text = profile.StopBits.ToString();
            comboBoxParity.Text = profile.Parity.ToString();
        }

        private void UpdateFromManger(AlarmingState state, Report report)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateFromManger(state, report)));
                return;
            }

            if (state.HasFlag(AlarmingState.Unarmed))
            {
                lblState.Text = "未布防";
                lblState.BackColor = Color.Gray;
            }
            else if (state.HasFlag(AlarmingState.Level4))
            {
                lblState.Text = "AA级警报";
                lblState.BackColor = Color.Red;
            }
            else if (state.HasFlag(AlarmingState.Level3))
            {
                lblState.Text = "A级警报";
                lblState.BackColor = Color.Orange;
            }
            else if (state.HasFlag(AlarmingState.Level2))
            {
                lblState.Text = "B级警报";
                lblState.BackColor = Color.Gold;
            }
            else if (state.HasFlag(AlarmingState.Level1))
            {
                lblState.Text = "C级警报";
                lblState.BackColor = Color.DodgerBlue;
            }
            else
            {
                lblState.Text = "正常";
                lblState.BackColor = Color.LawnGreen;
            }

            tslState.Text = "安全状态：" + lblState.Text;
            tslError.Text = "系统工作正常";
        }

        private void ErrorFromManager(Exception e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ErrorFromManager(e)));
                return;
            }

            tslError.Text = "系统错误：" + e.Message;
        }

        private void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            sp1.Encoding = Encoding.Default;

            if (sp1.IsOpen)
                try
                {
                    var receivedData = new Byte[sp1.BytesToRead]; //创建接收字节数组
                    sp1.Read(receivedData, 0, receivedData.Length); //读取数据
                    sp1.DiscardInBuffer(); //清空SerialPort控件的Buffer
                    lstRecv.AddRange(receivedData);

                    if (chbConsole.Checked)
                    {
                        var strRcv = new StringBuilder();
                        for (var i = 0; i < receivedData.Length; i++) //窗体显示
                            strRcv.Append(receivedData[i].ToString("X2") + " "); //16进制显示
                        txtBoxRxtData.AppendText("\r\n" + "FPGA->PC:" + "\r\n" + "    " + strRcv);

                        txtBoxRxtData.Focus();
                        txtBoxRxtData.Select(txtBoxRxtData.Text.Length - 1, 0);
                        txtBoxRxtData.ScrollToCaret();
                    }

                    var cur_buffer = lstRecv.ToArray();
                    var removed = 0;
                    foreach (var frm in Command.getFrame(cur_buffer))
                    {
                        lstRecv.RemoveRange(frm.start_i - removed, 8);
                        removed += 8;
                        lblIllumValue.Text = frm.illum.ToString();
                        lblDistValue.Text = frm.dist.ToString();
                        lblShakeValue.Text = frm.acl2.ToString();
                        alas.Update(frm.dist, frm.illum, frm.acl2, conn, false);
                        UpdateLbState();
                        connchk = 0; // Have connection, so clear connchk;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "出错提示");
                }
            else
                MessageBox.Show("请打开某个串口", "错误提示");
        }

        private void btnToggleCom_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
                try
                {
                    //设置串口号
                    var serialName = comboBoxSerialPorts.Text;
                    if (serialName == "")
                    {
                        ListPorts();
                        return;
                    }
                    sp1.PortName = serialName;

                    //设置各“串口设置”
                    var strBaudRate = comboBoxBaudRate.Text;
                    var strDateBits = comboBoxWordLength.Text;
                    var strStopBits = comboBoxStopBits.Text;

                    var iBaudRate = Convert.ToInt32(strBaudRate);
                    var iDateBits = Convert.ToInt32(strDateBits);

                    sp1.BaudRate = iBaudRate; //波特率
                    sp1.DataBits = iDateBits; //数据位
                    switch (comboBoxStopBits.Text) //停止位
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
                    switch (comboBoxParity.Text) //校验位
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

                    if (sp1.IsOpen == true) //如果打开状态，则先关闭一下
                        sp1.Close();

                    //设置必要控件不可用
                    comboBoxSerialPorts.Enabled = false;
                    comboBoxBaudRate.Enabled = false;
                    comboBoxWordLength.Enabled = false;
                    comboBoxStopBits.Enabled = false;
                    comboBoxParity.Enabled = false;

                    sp1.Open(); //打开串口
                    btnToggleCom.Text = "关闭串口";
                    conn = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    connchk = 0;
                    return;
                }
            else
            {
                //恢复控件功能
                //设置必要控件不可用
                comboBoxSerialPorts.Enabled = true;
                comboBoxBaudRate.Enabled = true;
                comboBoxWordLength.Enabled = true;
                comboBoxStopBits.Enabled = true;
                comboBoxParity.Enabled = true;
                try
                {
                    sp1.Close(); //关闭串口
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: Uart lost!", "Error");
                }
                btnToggleCom.Text = "打开串口";
                conn = false;
            }
            alas.Update(0, 0, false, conn, !conn);
            UpdateLbState();
        }

        private void AlarmSystem_FormClosing(object sender, FormClosingEventArgs e) => m_Manager.UnarmAndClosePort();

        private void btnBuzz_Click(object sender, EventArgs e)
            => m_Manager.SendManagementPackage(ManagementPackageType.BuzzOn);

        private void btnUnbuzz_Click(object sender, EventArgs e)
            => m_Manager.SendManagementPackage(ManagementPackageType.BuzzOff);

        private void btnIgnore_Click(object sender, EventArgs e)
            => m_Manager.IgnoreAlarm();

        private void btnSettings_Click(object sender, EventArgs e)
        {
            m_ShowConsole ^= true;
            tabSettings.Visible = m_ShowConsole;
        }
    }
}
