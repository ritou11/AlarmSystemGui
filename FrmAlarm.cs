using System;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using AlarmSystem.BLL;
using AlarmSystem.DAL;
using AlarmSystem.Entities;

namespace AlarmSystem
{
    public partial class FrmAlarm : Form
    {
        private const int MaxPoints = 50;

        private readonly BLL.AlarmSystem m_Manager;
        private bool m_ShowConsole = true;
        private bool m_EnableBuzzer;
        private bool m_ActBuzzer = true;

        public FrmAlarm()
        {
            InitializeComponent();

            tabSettings.SelectedIndex = 1;

            comboBoxSerialPorts.Items.Clear();
            foreach (var s in SerialPort.GetPortNames())
                comboBoxSerialPorts.Items.Add(s);

            InitializeChart();

            m_Manager = new BLL.AlarmSystem();
            m_Manager.Update += UpdateFromManger;
            m_Manager.ConnLost += ConnLostFromManager;
            m_Manager.Error += ErrorFromManager;
            m_Manager.OpenPortResult += OpenPortFromManager;
            m_Manager.ClosePortResult += ClosePortFromManager;

            GetProfileFromManager();
            UpdateState();
        }

        private void InitializeChart()
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();

            // dist
            var chAreaDist = chart1.ChartAreas.Add("dist");
            chAreaDist.Position = new ElementPosition(0, 0, 100, 30);
            chAreaDist.AxisX.Enabled = AxisEnabled.False;
            chAreaDist.AxisY.Enabled = AxisEnabled.True;
            chAreaDist.AxisY2.Enabled = AxisEnabled.True;
            chAreaDist.AxisX.MajorGrid.Enabled = false;
            chAreaDist.AxisY.MajorGrid.Enabled = false;
            chAreaDist.AxisY2.MajorGrid.Enabled = false;
            chAreaDist.CursorY.AxisType = AxisType.Secondary;
            chAreaDist.CursorY.SelectionColor = Color.FromArgb(30, Color.Green);
            chAreaDist.CursorY.SetSelectionPosition(0, BLL.AlarmSystem.MaxDist);

            var chSeriesDistRaw = chart1.Series.Add("distRaw");
            chSeriesDistRaw.ChartArea = "dist";
            chSeriesDistRaw.ChartType = SeriesChartType.FastPoint;
            chSeriesDistRaw.YAxisType = AxisType.Primary;

            var chSeriesDist = chart1.Series.Add("dist");
            chSeriesDist.ChartArea = "dist";
            chSeriesDist.ChartType = SeriesChartType.FastLine;
            chSeriesDist.YAxisType = AxisType.Secondary;
            chSeriesDist.Color = Color.Black;
            chSeriesDist.BorderWidth = 3;

            // illum
            var chAreaIllum = chart1.ChartAreas.Add("illum");
            chAreaIllum.Position = new ElementPosition(0, 30, 100, 30);
            chAreaIllum.AxisX.Enabled = AxisEnabled.False;
            chAreaIllum.AxisY.Enabled = AxisEnabled.True;
            chAreaIllum.AxisY2.Enabled = AxisEnabled.True;
            chAreaIllum.AxisX.MajorGrid.Enabled = false;
            chAreaIllum.AxisY.MajorGrid.Enabled = false;
            chAreaIllum.AxisY2.MajorGrid.Enabled = false;
            chAreaIllum.CursorY.SelectionColor = Color.FromArgb(30, Color.Green);
            chAreaIllum.CursorY.SetSelectionPosition(0, BLL.AlarmSystem.MaxIllum);

            var chSeriesIllum = chart1.Series.Add("illum");
            chSeriesIllum.ChartArea = "illum";
            chSeriesIllum.ChartType = SeriesChartType.FastLine;
            chSeriesIllum.Color = Color.Black;
            chSeriesIllum.BorderWidth = 3;

            // acc
            var chAreaAcc = chart1.ChartAreas.Add("acc");
            chAreaAcc.Position = new ElementPosition(0, 60, 100, 40);
            chAreaAcc.AxisX.Enabled = AxisEnabled.False;
            chAreaAcc.AxisY.Enabled = AxisEnabled.True;
            chAreaAcc.AxisY2.Enabled = AxisEnabled.True;
            chAreaAcc.AxisX.MajorGrid.Enabled = false;
            chAreaAcc.AxisY.MajorGrid.Enabled = false;
            chAreaAcc.AxisY2.MajorGrid.Enabled = false;
            chAreaAcc.CursorY.AxisType = AxisType.Secondary;
            chAreaAcc.CursorY.SelectionColor = Color.FromArgb(30, Color.Green);
            chAreaAcc.CursorY.SetSelectionPosition(-BLL.AlarmSystem.MaxAcc, BLL.AlarmSystem.MaxAcc);

            var chSeriesAccRaw = chart1.Series.Add("accRaw");
            chSeriesAccRaw.ChartArea = "acc";
            chSeriesAccRaw.ChartType = SeriesChartType.FastPoint;
            chSeriesAccRaw.YAxisType = AxisType.Primary;

            var chSeriesAcc = chart1.Series.Add("acc");
            chSeriesAcc.ChartArea = "acc";
            chSeriesAcc.ChartType = SeriesChartType.FastLine;
            chSeriesAcc.YAxisType = AxisType.Primary;

            var chSeriesAccCuSum = chart1.Series.Add("accCuSum");
            chSeriesAccCuSum.ChartArea = "acc";
            chSeriesAccCuSum.ChartType = SeriesChartType.FastLine;
            chSeriesAccCuSum.YAxisType = AxisType.Secondary;
            chSeriesAccCuSum.Color = Color.Black;
            chSeriesAccCuSum.BorderWidth = 3;
        }

        private static double InfTo(double value, int accuracy)
            => Math.Sign(value) * Math.Ceiling(Math.Abs(value) * Math.Pow(10, accuracy)) * Math.Pow(10, -accuracy);

        private void UpdateChartRange()
        {
            // dist
            var chAreaDist = chart1.ChartAreas["dist"];

            var chSeriesDistRaw = chart1.Series["distRaw"];
            var sdrMax = chSeriesDistRaw.Points.FindMaxByValue()?.YValues[0];

            var chSeriesDist = chart1.Series["dist"];
            var sdMax = chSeriesDist.Points.FindMaxByValue()?.YValues[0];

            chAreaDist.AxisY.Minimum = 0;
            chAreaDist.AxisY.Maximum = InfTo(Math.Max(sdrMax ?? 0, BLL.AlarmSystem.MaxDist) + 10, -1);

            chAreaDist.AxisY2.Minimum = 0;
            chAreaDist.AxisY2.Maximum = InfTo(Math.Max(sdMax ?? 0, BLL.AlarmSystem.MaxDist) + 10, -1);

            // illum
            var chAreaIllum = chart1.ChartAreas["illum"];

            var chSeriesIllum = chart1.Series["illum"];
            var siMax = chSeriesIllum.Points.FindMaxByValue()?.YValues[0];

            chAreaIllum.AxisY.Minimum = 0;
            chAreaIllum.AxisY.Maximum = InfTo(Math.Max(siMax ?? 0, BLL.AlarmSystem.MaxIllum) + 2, 0);

            chAreaIllum.AxisY2.Minimum = 0;
            chAreaIllum.AxisY2.Maximum = InfTo(Math.Max(siMax ?? 0, BLL.AlarmSystem.MaxIllum) + 2, 0);

            // acc
            var chAreaAcc = chart1.ChartAreas["acc"];

            var chSeriesAccRaw = chart1.Series["accRaw"];
            var sarMin = chSeriesAccRaw.Points.FindMinByValue()?.YValues[0];
            var sarMax = chSeriesAccRaw.Points.FindMaxByValue()?.YValues[0];

            var chSeriesAcc = chart1.Series["acc"];
            var saMin = chSeriesAcc.Points.FindMinByValue()?.YValues[0];
            var saMax = chSeriesAcc.Points.FindMaxByValue()?.YValues[0];

            var chSeriesAccCuSum = chart1.Series["accCuSum"];
            var sacsMin = chSeriesAccCuSum.Points.FindMinByValue()?.YValues[0];
            var sacsMax = chSeriesAccCuSum.Points.FindMaxByValue()?.YValues[0];

            chAreaAcc.AxisY.Minimum = InfTo(Math.Min(sarMin ?? 0, saMin ?? 0) - 10, -1);
            chAreaAcc.AxisY.Maximum = InfTo(Math.Max(sarMax ?? 0, saMax ?? 0) + 10, -1);

            chAreaAcc.AxisY2.Minimum = InfTo(Math.Min(sacsMin ?? 0, -BLL.AlarmSystem.MaxAcc) - 10, -1);
            chAreaAcc.AxisY2.Maximum = InfTo(Math.Max(sacsMax ?? 0, BLL.AlarmSystem.MaxAcc) + 10, -1);
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

        private void AppendSeries(string name, double data)
        {
            var series = chart1.Series[name];
            while (series.Points.Count >= MaxPoints)
                series.Points.RemoveAt(0);
            series.Points.AddY(data);
        }

        private void UpdateFromManger(Report report, Report rawReport, double cusum)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateFromManger(report, rawReport, cusum)));
                return;
            }

            UpdateState();

            lblConnValue.Text = "正常";
            lblConnValue.ForeColor = m_Manager.ConnectivityEnabled ? Color.Black : Color.Gray;
            tslError.Text = "系统工作正常";

            if (report == null)
                return;

            AppendSeries("distRaw", rawReport.Distance);
            AppendSeries("dist", report.Distance);
            AppendSeries("illum", report.Illuminance);
            AppendSeries("accRaw", rawReport.Acceleration);
            AppendSeries("acc", report.Acceleration);
            AppendSeries("accCuSum", cusum);
            UpdateChartRange();

            if (m_Manager.RealState.HasFlag(AlarmingState.Level1))
            {
                lblDistValue.Text = report.Distance.ToString("0.00");
                lblDistValue.ForeColor = m_Manager.DistanceEnabled ? Color.Red : Color.Gray;
            }
            else
            {
                lblDistValue.Text = report.Distance.ToString("0.00");
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
                lblShakeValue.Text = report.Acceleration.ToString("0.00");
                lblShakeValue.ForeColor = m_Manager.ShakingEnabled ? Color.Red : Color.Gray;
            }
            else
            {
                lblShakeValue.Text = report.Acceleration.ToString("0.00");
                lblShakeValue.ForeColor = m_Manager.ShakingEnabled ? Color.Black : Color.Gray;
            }

            m_ActBuzzer = report.IsBuzzerOn;
            btnActBuzz.Text = m_ActBuzzer ? "关闭蜂鸣器" : "打开蜂鸣器";

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
                if (m_EnableBuzzer)
                    m_Manager.SendManagementPackage(ManagementPackageType.BuzzOn);
                lblState.BackColor = Color.Red;
            }
            else if (m_Manager.State.HasFlag(AlarmingState.Level3))
            {
                lblState.Text = "A级警报";
                if (m_EnableBuzzer)
                    m_Manager.SendManagementPackage(ManagementPackageType.BuzzOn);
                lblState.BackColor = Color.Orange;
            }
            else if (m_Manager.State.HasFlag(AlarmingState.Level2))
            {
                lblState.Text = "B级警报";
                if (m_EnableBuzzer)
                    m_Manager.SendManagementPackage(ManagementPackageType.BuzzOn);
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
        {
            m_EnableBuzzer = !m_EnableBuzzer;
            btnBuzz.Text = m_EnableBuzzer ? "禁用蜂鸣器" : "启用蜂鸣器";
            btnActBuzz.Enabled = m_EnableBuzzer;
            if (m_ActBuzzer && !m_EnableBuzzer)
                m_Manager.SendManagementPackage(ManagementPackageType.BuzzOff);
        }

        private void btnActBuzz_Click(object sender, EventArgs e)
            =>
                m_Manager.SendManagementPackage(
                                                m_ActBuzzer
                                                    ? ManagementPackageType.BuzzOff
                                                    : ManagementPackageType.BuzzOn);


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
