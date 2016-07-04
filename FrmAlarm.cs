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
            m_Manager.ConnLost += ConnLostFromManager;
            m_Manager.Error += ErrorFromManager;
        }

        private bool SetProfileToManager()
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
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("格式错误", "错误");
            }
            catch (Exception e)
            {
                MessageBox.Show($"未知错误：{e}", "错误");
            }
            return false;
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

            UpdateState(state);

            lblConnValue.Text = "正常";
            tslError.Text = "系统工作正常";

            if (report == null)
                return;

            if (report.IsShaking)
            {
                lblShakeValue.Text = "异常";
                lblShakeValue.ForeColor = m_Manager.ShakingEnabled ? Color.Red : Color.Gray;
            }
            else
            {
                lblShakeValue.Text = "正常";
                lblShakeValue.ForeColor = m_Manager.ShakingEnabled ? Color.Black : Color.Gray;
            }

            // TODO: show raw_state.dist
            lblDistValue.Text = report.Distance.ToString(CultureInfo.InvariantCulture);
            lblDistValue.ForeColor = m_Manager.DistanceEnabled ? Color.Black : Color.Gray;

            // TODO: show raw_state.illum
            lblIllumValue.Text = report.Illuminance.ToString(CultureInfo.InvariantCulture);
            lblIllumValue.ForeColor = m_Manager.IlluminanceEnabled ? Color.Black : Color.Gray;
            
            var sb = new StringBuilder();
            sb.AppendLine($"RX @ {report.TimeStamp:HH:mm:ss.ffff}:");
            foreach (var b in report.RawBytes)
                sb.Append($" {b:x2}");
            sb.AppendLine();
            txtLog.AppendText(sb.ToString());
        }

        private void ConnLostFromManager(AlarmingState state)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ConnLostFromManager(state)));
                return;
            }

            lblConnValue.Text = "失联";
            lblConnValue.ForeColor = m_Manager.ConnectivityEnabled ? Color.Red : Color.Gray;

            UpdateState(state);

            txtLog.AppendText($"LOST @ {DateTime.Now:HH:mm:ss.ffff}:");
        }

        private void ErrorFromManager(Exception e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ErrorFromManager(e)));
                return;
            }

            tslError.Text = "系统错误：" + e.Message;
            txtLog.AppendText($"ERR @ {DateTime.Now:HH:mm:ss.ffff}");
            txtLog.AppendText(e.ToString());
        }

        public void UpdateState(AlarmingState state)
        {
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

            if (m_Manager.IsOpen)
            {
                btnToggleCom.Text = "关闭串口";
                btnToggleCom.Enabled = true;
            }
            else
            {
                btnToggleCom.Text = "打开串口";

                comboBoxSerialPorts.Enabled = true;
                comboBoxBaudRate.Enabled = true;
                comboBoxWordLength.Enabled = true;
                comboBoxStopBits.Enabled = true;
                comboBoxParity.Enabled = true;
                btnToggleCom.Enabled = true;
            }
        }

        private void btnToggleCom_Click(object sender, EventArgs e)
        {
            if (!m_Manager.IsOpen)
            {
                if (!SetProfileToManager())
                    return;

                comboBoxSerialPorts.Enabled = false;
                comboBoxBaudRate.Enabled = false;
                comboBoxWordLength.Enabled = false;
                comboBoxStopBits.Enabled = false;
                comboBoxParity.Enabled = false;

                btnToggleCom.Enabled = false;
                m_Manager.OpenPort();
            }
            else
            {
                btnToggleCom.Enabled = false;
                m_Manager.UnarmAndClosePort();
            }
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
