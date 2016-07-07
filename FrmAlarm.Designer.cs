﻿namespace AlarmSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlarm));
            this.labelReadData = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslError = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnToggleCom = new System.Windows.Forms.Button();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxWordLength = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chbLog = new System.Windows.Forms.CheckBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnActBuzz = new System.Windows.Forms.Button();
            this.lblConnValue = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblConn = new System.Windows.Forms.Label();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.lblShake = new System.Windows.Forms.Label();
            this.lblIllumValue = new System.Windows.Forms.Label();
            this.lblIllum = new System.Windows.Forms.Label();
            this.btnBuzz = new System.Windows.Forms.Button();
            this.lblDist = new System.Windows.Forms.Label();
            this.lblDistValue = new System.Windows.Forms.Label();
            this.lblShakeValue = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statusStrip1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelReadData
            // 
            this.labelReadData.AutoSize = true;
            this.labelReadData.Location = new System.Drawing.Point(528, 628);
            this.labelReadData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelReadData.Name = "labelReadData";
            this.labelReadData.Size = new System.Drawing.Size(0, 18);
            this.labelReadData.TabIndex = 49;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 595);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1172, 29);
            this.statusStrip1.TabIndex = 80;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslError
            // 
            this.tslError.BackColor = System.Drawing.SystemColors.Control;
            this.tslError.Name = "tslError";
            this.tslError.Size = new System.Drawing.Size(118, 24);
            this.tslError.Text = "系统工作正常";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPage1);
            this.tabSettings.Controls.Add(this.tabPage2);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabSettings.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabSettings.Location = new System.Drawing.Point(740, 0);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(432, 595);
            this.tabSettings.TabIndex = 81;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(424, 558);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "日志";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(4, 4);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(416, 550);
            this.txtLog.TabIndex = 14;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(424, 554);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel3.Controls.Add(this.chbLog, 1, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(416, 546);
            this.tableLayoutPanel3.TabIndex = 25;
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
            // btnToggleCom
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.btnToggleCom, 2);
            this.btnToggleCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToggleCom.Location = new System.Drawing.Point(4, 204);
            this.btnToggleCom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnToggleCom.Name = "btnToggleCom";
            this.btnToggleCom.Size = new System.Drawing.Size(408, 42);
            this.btnToggleCom.TabIndex = 0;
            this.btnToggleCom.Text = "打开串口";
            this.btnToggleCom.UseVisualStyleBackColor = true;
            this.btnToggleCom.Click += new System.EventHandler(this.btnToggleCom_Click);
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Mark",
            "Space"});
            this.comboBoxParity.Location = new System.Drawing.Point(124, 164);
            this.comboBoxParity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(288, 32);
            this.comboBoxParity.TabIndex = 5;
            // 
            // comboBoxSerialPorts
            // 
            this.comboBoxSerialPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxSerialPorts.FormattingEnabled = true;
            this.comboBoxSerialPorts.Location = new System.Drawing.Point(124, 4);
            this.comboBoxSerialPorts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            this.comboBoxSerialPorts.Size = new System.Drawing.Size(288, 32);
            this.comboBoxSerialPorts.TabIndex = 1;
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Items.AddRange(new object[] {
            "None",
            "One",
            "OnePointFive",
            "Two"});
            this.comboBoxStopBits.Location = new System.Drawing.Point(124, 124);
            this.comboBoxStopBits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(288, 32);
            this.comboBoxStopBits.TabIndex = 4;
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
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(124, 44);
            this.comboBoxBaudRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(288, 32);
            this.comboBoxBaudRate.TabIndex = 2;
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
            this.comboBoxWordLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxWordLength.Name = "comboBoxWordLength";
            this.comboBoxWordLength.Size = new System.Drawing.Size(288, 32);
            this.comboBoxWordLength.TabIndex = 3;
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
            // chbLog
            // 
            this.chbLog.AutoSize = true;
            this.chbLog.Checked = true;
            this.chbLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.chbLog.Location = new System.Drawing.Point(304, 254);
            this.chbLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbLog.Name = "chbLog";
            this.chbLog.Size = new System.Drawing.Size(108, 32);
            this.chbLog.TabIndex = 19;
            this.chbLog.Text = "开启日志";
            this.chbLog.UseVisualStyleBackColor = true;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(740, 595);
            this.tabMain.TabIndex = 82;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(732, 563);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "控制面板";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chart1);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(732, 563);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "图形";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.btnActBuzz, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblConnValue, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSettings, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblConn, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnIgnore, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblShake, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblIllumValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIllum, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBuzz, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDist, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDistValue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblShakeValue, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblState, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnClear, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(726, 557);
            this.tableLayoutPanel1.TabIndex = 80;
            // 
            // btnActBuzz
            // 
            this.btnActBuzz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnActBuzz.Enabled = false;
            this.btnActBuzz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnActBuzz.Location = new System.Drawing.Point(4, 275);
            this.btnActBuzz.Margin = new System.Windows.Forms.Padding(4);
            this.btnActBuzz.Name = "btnActBuzz";
            this.btnActBuzz.Size = new System.Drawing.Size(173, 63);
            this.btnActBuzz.TabIndex = 7;
            this.btnActBuzz.Text = "打开蜂鸣器";
            this.btnActBuzz.UseVisualStyleBackColor = true;
            this.btnActBuzz.Click += new System.EventHandler(this.btnActBuzz_Click);
            // 
            // lblConnValue
            // 
            this.lblConnValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConnValue.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblConnValue.Location = new System.Drawing.Point(185, 150);
            this.lblConnValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnValue.Name = "lblConnValue";
            this.lblConnValue.Size = new System.Drawing.Size(537, 50);
            this.lblConnValue.TabIndex = 77;
            this.lblConnValue.Text = "无数据";
            this.lblConnValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSettings.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSettings.Location = new System.Drawing.Point(4, 488);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(173, 65);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.Text = "切换显示";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lblConn
            // 
            this.lblConn.AutoSize = true;
            this.lblConn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConn.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblConn.Location = new System.Drawing.Point(4, 150);
            this.lblConn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConn.Name = "lblConn";
            this.lblConn.Size = new System.Drawing.Size(173, 50);
            this.lblConn.TabIndex = 13;
            this.lblConn.Text = "连接";
            this.lblConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConn.Click += new System.EventHandler(this.lblConn_Click);
            // 
            // btnIgnore
            // 
            this.btnIgnore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIgnore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIgnore.Location = new System.Drawing.Point(4, 346);
            this.btnIgnore.Margin = new System.Windows.Forms.Padding(4);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(173, 63);
            this.btnIgnore.TabIndex = 8;
            this.btnIgnore.Text = "忽略警报";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // lblShake
            // 
            this.lblShake.AutoSize = true;
            this.lblShake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShake.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblShake.Location = new System.Drawing.Point(4, 100);
            this.lblShake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShake.Name = "lblShake";
            this.lblShake.Size = new System.Drawing.Size(173, 50);
            this.lblShake.TabIndex = 12;
            this.lblShake.Text = "振动";
            this.lblShake.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblShake.Click += new System.EventHandler(this.lblShake_Click);
            // 
            // lblIllumValue
            // 
            this.lblIllumValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIllumValue.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblIllumValue.Location = new System.Drawing.Point(185, 50);
            this.lblIllumValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIllumValue.Name = "lblIllumValue";
            this.lblIllumValue.Size = new System.Drawing.Size(537, 50);
            this.lblIllumValue.TabIndex = 73;
            this.lblIllumValue.Text = "无数据";
            this.lblIllumValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIllum
            // 
            this.lblIllum.AutoSize = true;
            this.lblIllum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIllum.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblIllum.Location = new System.Drawing.Point(4, 50);
            this.lblIllum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIllum.Name = "lblIllum";
            this.lblIllum.Size = new System.Drawing.Size(173, 50);
            this.lblIllum.TabIndex = 11;
            this.lblIllum.Text = "照度";
            this.lblIllum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIllum.Click += new System.EventHandler(this.lblIllum_Click);
            // 
            // btnBuzz
            // 
            this.btnBuzz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuzz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBuzz.Location = new System.Drawing.Point(4, 204);
            this.btnBuzz.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuzz.Name = "btnBuzz";
            this.btnBuzz.Size = new System.Drawing.Size(173, 63);
            this.btnBuzz.TabIndex = 6;
            this.btnBuzz.Text = "启用蜂鸣器";
            this.btnBuzz.UseVisualStyleBackColor = true;
            this.btnBuzz.Click += new System.EventHandler(this.btnBuzz_Click);
            // 
            // lblDist
            // 
            this.lblDist.AutoSize = true;
            this.lblDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDist.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblDist.Location = new System.Drawing.Point(4, 0);
            this.lblDist.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDist.Name = "lblDist";
            this.lblDist.Size = new System.Drawing.Size(173, 50);
            this.lblDist.TabIndex = 10;
            this.lblDist.Text = "距离";
            this.lblDist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDist.Click += new System.EventHandler(this.lblDist_Click);
            // 
            // lblDistValue
            // 
            this.lblDistValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDistValue.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblDistValue.Location = new System.Drawing.Point(185, 0);
            this.lblDistValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDistValue.Name = "lblDistValue";
            this.lblDistValue.Size = new System.Drawing.Size(537, 50);
            this.lblDistValue.TabIndex = 71;
            this.lblDistValue.Text = "无数据";
            this.lblDistValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShakeValue
            // 
            this.lblShakeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShakeValue.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblShakeValue.Location = new System.Drawing.Point(185, 100);
            this.lblShakeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShakeValue.Name = "lblShakeValue";
            this.lblShakeValue.Size = new System.Drawing.Size(537, 50);
            this.lblShakeValue.TabIndex = 74;
            this.lblShakeValue.Text = "无数据";
            this.lblShakeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(255)))), ((int)(((byte)(124)))));
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblState.Location = new System.Drawing.Point(191, 210);
            this.lblState.Margin = new System.Windows.Forms.Padding(10);
            this.lblState.Name = "lblState";
            this.tableLayoutPanel1.SetRowSpan(this.lblState, 5);
            this.lblState.Size = new System.Drawing.Size(525, 337);
            this.lblState.TabIndex = 74;
            this.lblState.Text = "AA级警报";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(4, 417);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(173, 63);
            this.btnClear.TabIndex = 78;
            this.btnClear.Text = "清空日志";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chart1
            // 
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(726, 557);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // FrmAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1172, 624);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.labelReadData);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmAlarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基于Verilog的大件贵重物品安保系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmSystem_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelReadData;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslError;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToggleCom;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.ComboBox comboBoxSerialPorts;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.ComboBox comboBoxWordLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chbLog;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnActBuzz;
        private System.Windows.Forms.Label lblConnValue;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblConn;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Label lblShake;
        private System.Windows.Forms.Label lblIllumValue;
        private System.Windows.Forms.Label lblIllum;
        private System.Windows.Forms.Button btnBuzz;
        private System.Windows.Forms.Label lblDist;
        private System.Windows.Forms.Label lblDistValue;
        private System.Windows.Forms.Label lblShakeValue;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

