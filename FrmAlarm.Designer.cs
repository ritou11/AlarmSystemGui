namespace AlarmSystem
{
    partial class FrmAlarm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.labelReadData = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtBoxRxtData = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.btnToggleCom = new System.Windows.Forms.Button();
            this.comboBoxWordLength = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDist = new System.Windows.Forms.Label();
            this.lbDist = new System.Windows.Forms.Label();
            this.lbState = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblIllum = new System.Windows.Forms.Label();
            this.lbIllum = new System.Windows.Forms.Label();
            this.lbAcl2 = new System.Windows.Forms.Label();
            this.lblAcl = new System.Windows.Forms.Label();
            this.lblConn = new System.Windows.Forms.Label();
            this.lbConn = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerSend
            // 
            this.timerSend.Interval = 1000;
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // labelReadData
            // 
            this.labelReadData.AutoSize = true;
            this.labelReadData.Location = new System.Drawing.Point(806, 736);
            this.labelReadData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelReadData.Name = "labelReadData";
            this.labelReadData.Size = new System.Drawing.Size(0, 18);
            this.labelReadData.TabIndex = 49;
            // 
            // txtSend
            // 
            this.txtSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSend.Location = new System.Drawing.Point(4, 516);
            this.txtSend.Margin = new System.Windows.Forms.Padding(4);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(469, 31);
            this.txtSend.TabIndex = 58;
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSend.Location = new System.Drawing.Point(481, 516);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(92, 32);
            this.btnSend.TabIndex = 59;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtBoxRxtData
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtBoxRxtData, 2);
            this.txtBoxRxtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxRxtData.Location = new System.Drawing.Point(4, 4);
            this.txtBoxRxtData.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxRxtData.Multiline = true;
            this.txtBoxRxtData.Name = "txtBoxRxtData";
            this.txtBoxRxtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxRxtData.Size = new System.Drawing.Size(569, 504);
            this.txtBoxRxtData.TabIndex = 63;
            this.txtBoxRxtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxRxtData_KeyPress);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(676, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tableLayoutPanel1.SetRowSpan(this.tabControl1, 7);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(593, 597);
            this.tabControl1.TabIndex = 65;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(585, 560);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "控制台";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(523, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.comboBoxParity.Location = new System.Drawing.Point(124, 164);
            this.comboBoxParity.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(387, 32);
            this.comboBoxParity.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 40);
            this.label1.TabIndex = 18;
            this.label1.Text = "串口号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxSerialPorts
            // 
            this.comboBoxSerialPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxSerialPorts.FormattingEnabled = true;
            this.comboBoxSerialPorts.Location = new System.Drawing.Point(124, 4);
            this.comboBoxSerialPorts.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            this.comboBoxSerialPorts.Size = new System.Drawing.Size(387, 32);
            this.comboBoxSerialPorts.TabIndex = 23;
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBoxStopBits.Location = new System.Drawing.Point(124, 124);
            this.comboBoxStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(387, 32);
            this.comboBoxStopBits.TabIndex = 8;
            // 
            // btnToggleCom
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.btnToggleCom, 2);
            this.btnToggleCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToggleCom.Location = new System.Drawing.Point(4, 204);
            this.btnToggleCom.Margin = new System.Windows.Forms.Padding(4);
            this.btnToggleCom.Name = "btnToggleCom";
            this.btnToggleCom.Size = new System.Drawing.Size(507, 42);
            this.btnToggleCom.TabIndex = 24;
            this.btnToggleCom.Text = "打开串口";
            this.btnToggleCom.UseVisualStyleBackColor = true;
            this.btnToggleCom.Click += new System.EventHandler(this.buttonOpenOrCloseCom_Click);
            // 
            // comboBoxWordLength
            // 
            this.comboBoxWordLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxWordLength.FormattingEnabled = true;
            this.comboBoxWordLength.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxWordLength.Location = new System.Drawing.Point(124, 84);
            this.comboBoxWordLength.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxWordLength.Name = "comboBoxWordLength";
            this.comboBoxWordLength.Size = new System.Drawing.Size(387, 32);
            this.comboBoxWordLength.TabIndex = 7;
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600",
            "1382400"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(124, 44);
            this.comboBoxBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(387, 32);
            this.comboBoxBaudRate.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(4, 160);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 40);
            this.label8.TabIndex = 4;
            this.label8.Text = "校验位";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(4, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 40);
            this.label5.TabIndex = 1;
            this.label5.Text = "波特率";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(4, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 40);
            this.label6.TabIndex = 2;
            this.label6.Text = "数据位";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(4, 120);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 40);
            this.label7.TabIndex = 3;
            this.label7.Text = "停止位";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDist
            // 
            this.lblDist.AutoSize = true;
            this.lblDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDist.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDist.Location = new System.Drawing.Point(4, 0);
            this.lblDist.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDist.Name = "lblDist";
            this.lblDist.Size = new System.Drawing.Size(160, 60);
            this.lblDist.TabIndex = 66;
            this.lblDist.Text = "距离";
            this.lblDist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDist
            // 
            this.lbDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDist.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDist.Location = new System.Drawing.Point(172, 0);
            this.lbDist.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDist.Name = "lbDist";
            this.lbDist.Size = new System.Drawing.Size(496, 60);
            this.lbDist.TabIndex = 71;
            this.lbDist.Text = "无数据";
            this.lbDist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbState
            // 
            this.lbState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(255)))), ((int)(((byte)(124)))));
            this.lbState.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbState.Location = new System.Drawing.Point(822, 738);
            this.lbState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(402, 142);
            this.lbState.TabIndex = 74;
            this.lbState.Text = "安全";
            this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbState.Click += new System.EventHandler(this.lbState_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(704, 846);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 34);
            this.btnClose.TabIndex = 75;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(704, 738);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 34);
            this.button3.TabIndex = 76;
            this.button3.Text = "鸣笛警报";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(704, 774);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 34);
            this.button4.TabIndex = 77;
            this.button4.Text = "关闭警报";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(704, 810);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 34);
            this.button5.TabIndex = 78;
            this.button5.Text = "切换显示";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.lbState_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel1.Controls.Add(this.lbConn, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblConn, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblAcl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbIllum, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIllum, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDist, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDist, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbAcl2, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1273, 605);
            this.tableLayoutPanel1.TabIndex = 79;
            // 
            // lblIllum
            // 
            this.lblIllum.AutoSize = true;
            this.lblIllum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIllum.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIllum.Location = new System.Drawing.Point(4, 60);
            this.lblIllum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIllum.Name = "lblIllum";
            this.lblIllum.Size = new System.Drawing.Size(160, 60);
            this.lblIllum.TabIndex = 72;
            this.lblIllum.Text = "照度";
            this.lblIllum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbIllum
            // 
            this.lbIllum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIllum.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIllum.Location = new System.Drawing.Point(172, 60);
            this.lbIllum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIllum.Name = "lbIllum";
            this.lbIllum.Size = new System.Drawing.Size(496, 60);
            this.lbIllum.TabIndex = 73;
            this.lbIllum.Text = "无数据";
            this.lbIllum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAcl2
            // 
            this.lbAcl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAcl2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAcl2.Location = new System.Drawing.Point(172, 120);
            this.lbAcl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAcl2.Name = "lbAcl2";
            this.lbAcl2.Size = new System.Drawing.Size(496, 60);
            this.lbAcl2.TabIndex = 74;
            this.lbAcl2.Text = "无数据";
            this.lbAcl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAcl
            // 
            this.lblAcl.AutoSize = true;
            this.lblAcl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAcl.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAcl.Location = new System.Drawing.Point(4, 120);
            this.lblAcl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAcl.Name = "lblAcl";
            this.lblAcl.Size = new System.Drawing.Size(160, 60);
            this.lblAcl.TabIndex = 75;
            this.lblAcl.Text = "振动";
            this.lblAcl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConn
            // 
            this.lblConn.AutoSize = true;
            this.lblConn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConn.Location = new System.Drawing.Point(4, 180);
            this.lblConn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConn.Name = "lblConn";
            this.lblConn.Size = new System.Drawing.Size(160, 60);
            this.lblConn.TabIndex = 76;
            this.lblConn.Text = "连接";
            this.lblConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbConn
            // 
            this.lbConn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbConn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbConn.Location = new System.Drawing.Point(172, 180);
            this.lbConn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbConn.Name = "lbConn";
            this.lbConn.Size = new System.Drawing.Size(496, 60);
            this.lbConn.TabIndex = 77;
            this.lbConn.Text = "无数据";
            this.lbConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtBoxRxtData, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSend, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtSend, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(577, 552);
            this.tableLayoutPanel2.TabIndex = 64;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnToggleCom, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxParity, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxSerialPorts, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxStopBits, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxBaudRate, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxWordLength, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(515, 434);
            this.tableLayoutPanel3.TabIndex = 25;
            // 
            // FrmAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1490, 918);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbState);
            this.Controls.Add(this.labelReadData);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAlarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基于Verilog的大件贵重物品安保系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmSystem_FormClosing);
            this.Load += new System.EventHandler(this.AlarmSystem_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timerSend;
        private System.Windows.Forms.Label labelReadData;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtBoxRxtData;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.ComboBox comboBoxWordLength;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSerialPorts;
        private System.Windows.Forms.Button btnToggleCom;
        private System.Windows.Forms.Label lblDist;
        private System.Windows.Forms.Label lbDist;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbIllum;
        private System.Windows.Forms.Label lblIllum;
        private System.Windows.Forms.Label lbConn;
        private System.Windows.Forms.Label lblConn;
        private System.Windows.Forms.Label lblAcl;
        private System.Windows.Forms.Label lbAcl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

