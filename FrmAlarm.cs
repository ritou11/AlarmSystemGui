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

            tabSettings.SelectedIndex = 1;

            comboBoxSerialPorts.Items.Clear();
            foreach (var s in SerialPort.GetPortNames())
                comboBoxSerialPorts.Items.Add(s);

            m_Manager = new BLL.AlarmSystem();
            m_Manager.Update += UpdateFromManger;
            m_Manager.ConnLost += ConnLostFromManager;
            m_Manager.Error += ErrorFromManager;
            m_Manager.OpenPortResult += OpenPortFromManager;
            m_Manager.ClosePortResult += ClosePortFromManager;

            GetProfileFromManager();
            UpdateState();
        }

        private bool SetProfileToManager()
        {
            try
            {
                var profile =
                    new Profile
                        {
                            Name = comboBoxSerialPorts.Text,
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
            comboBoxSerialPorts.Text = profile.Name;
            comboBoxBaudRate.Text = profile.BaudRate.ToString(CultureInfo.InvariantCulture);
            comboBoxWordLength.Text = profile.DataBits.ToString(CultureInfo.InvariantCulture);
            comboBoxStopBits.Text = profile.StopBits.ToString();
            comboBoxParity.Text = profile.Parity.ToString();
        }

        private void UpdateFromManger(Report report)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateFromManger(report)));
                return;
            }

            UpdateState();

            lblConnValue.Text = "正常";
            lblConnValue.ForeColor = m_Manager.ConnectivityEnabled ? Color.Black : Color.Gray;
            tslError.Text = "系统工作正常";

            if (report == null)
                return;

            if (m_Manager.RealState.HasFlag(AlarmingState.Level1))
            {
                lblDistValue.Text = report.Distance.ToString(CultureInfo.InvariantCulture);
                lblDistValue.ForeColor = m_Manager.DistanceEnabled ? Color.Red : Color.Gray;
            }
            else
            {
                lblDistValue.Text = report.Distance.ToString(CultureInfo.InvariantCulture);
                lblDistValue.ForeColor = m_Manager.DistanceEnabled ? Color.Black : Color.Gray;
            }

            if (m_Manager.RealState.HasFlag(AlarmingState.Level2))
            {
                lblIllumValue.Text = report.Illuminance.ToString(CultureInfo.InvariantCulture);
                lblIllumValue.ForeColor = m_Manager.IlluminanceEnabled ? Color.Red : Color.Gray;
            }
            else
            {
                lblIllumValue.Text = report.Illuminance.ToString(CultureInfo.InvariantCulture);
                lblIllumValue.ForeColor = m_Manager.IlluminanceEnabled ? Color.Black : Color.Gray;
            }

            if (m_Manager.RealState.HasFlag(AlarmingState.Level3))
            {
                lblShakeValue.Text = report.Acceleration.ToString(CultureInfo.InvariantCulture);
                lblShakeValue.ForeColor = m_Manager.ShakingEnabled ? Color.Red : Color.Gray;
            }
            else
            {
                lblShakeValue.Text = report.Acceleration.ToString(CultureInfo.InvariantCulture);
                lblShakeValue.ForeColor = m_Manager.ShakingEnabled ? Color.Black : Color.Gray;
            }
            if (chbLog.Checked)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"RX @ {report.TimeStamp:HH:mm:ss.ffff}:");
                foreach (var b in report.RawBytes)
                    sb.Append($" {b:x2}");
                sb.AppendLine();
                txtLog.AppendText(sb.ToString());
            }
        }

        private void ConnLostFromManager()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ConnLostFromManager));
                return;
            }

            lblConnValue.Text = "失联";
            lblConnValue.ForeColor = m_Manager.ConnectivityEnabled ? Color.Red : Color.Gray;

            UpdateState();

            txtLog.AppendText($"LOST @ {DateTime.Now:HH:mm:ss.ffff}:");
        }

        private void ErrorFromManager(Exception e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ErrorFromManager(e)));
                return;
            }

            tslError.Text = "系统错误：" + e.Message.Trim();
            txtLog.AppendText($"ERR @ {DateTime.Now:HH:mm:ss.ffff}");
            txtLog.AppendText(e.ToString());

            UpdateState();
        }

        private void ClosePortFromManager(Exception e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ClosePortFromManager(e)));
                return;
            }

            btnToggleCom.Enabled = true;

            if (e != null)
            {
                ErrorFromManager(e);
                return;
            }

            UpdateState();

            comboBoxSerialPorts.Enabled = true;
            comboBoxBaudRate.Enabled = true;
            comboBoxWordLength.Enabled = true;
            comboBoxStopBits.Enabled = true;
            comboBoxParity.Enabled = true;
        }

        private void OpenPortFromManager(Exception e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OpenPortFromManager(e)));
                return;
            }

            btnToggleCom.Enabled = true;

            if (e != null)
            {
                ErrorFromManager(e);

                comboBoxSerialPorts.Enabled = true;
                comboBoxBaudRate.Enabled = true;
                comboBoxWordLength.Enabled = true;
                comboBoxStopBits.Enabled = true;
                comboBoxParity.Enabled = true;
                return;
            }

            UpdateState();
        }

        private void UpdateState()
        {
            if (m_Manager.State.HasFlag(AlarmingState.Unarmed))
            {
                lblState.Text = "未布防";
                lblState.BackColor = Color.Gray;
            }
            else if (m_Manager.State.HasFlag(AlarmingState.Level4))
            {
                lblState.Text = "AA级警报";
                lblState.BackColor = Color.Red;
            }
            else if (m_Manager.State.HasFlag(AlarmingState.Level3))
            {
                lblState.Text = "A级警报";
                lblState.BackColor = Color.Orange;
            }
            else if (m_Manager.State.HasFlag(AlarmingState.Level2))
            {
                lblState.Text = "B级警报";
                lblState.BackColor = Color.Gold;
            }
            else if (m_Manager.State.HasFlag(AlarmingState.Level1))
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

            btnToggleCom.Text = m_Manager.IsOpen ? "关闭串口" : "打开串口";
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
                m_Manager.ClosePort();
            }
        }

        private void AlarmSystem_FormClosing(object sender, FormClosingEventArgs e) => m_Manager.ClosePort();

        private void btnBuzz_Click(object sender, EventArgs e)
            => m_Manager.SendManagementPackage(ManagementPackageType.BuzzOn);

        private void btnUnbuzz_Click(object sender, EventArgs e)
            => m_Manager.SendManagementPackage(ManagementPackageType.BuzzOff);

        private void btnIgnore_Click(object sender, EventArgs e)
            => m_Manager.IgnoreAlarm();

        private void btnSettings_Click(object sender, EventArgs e)
        {
            m_ShowConsole ^= true;
            SuspendLayout();
            if (WindowState == FormWindowState.Normal)
                if (!m_ShowConsole)
                    Width = Width - tabSettings.Width;
                else
                    Width = Width + tabSettings.Width;
            tabSettings.Visible = m_ShowConsole;
            ResumeLayout();
        }

        private void lblDist_Click(object sender, EventArgs e)
            => m_Manager.DistanceEnabled = !m_Manager.DistanceEnabled;

        private void lblIllum_Click(object sender, EventArgs e)
            => m_Manager.IlluminanceEnabled = !m_Manager.IlluminanceEnabled;

        private void lblShake_Click(object sender, EventArgs e) => m_Manager.ShakingEnabled = !m_Manager.ShakingEnabled;

        private void lblConn_Click(object sender, EventArgs e)
            => m_Manager.ConnectivityEnabled = !m_Manager.ConnectivityEnabled;

        private void btnClear_Click(object sender, EventArgs e)
            => txtLog.Text = "";
    }
}
