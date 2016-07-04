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
            this.labelReadData = new System.Windows.Forms.Label();
            this.lblDist = new System.Windows.Forms.Label();
            this.lblDistValue = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.btnBuzz = new System.Windows.Forms.Button();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUnbuzz = new System.Windows.Forms.Button();
            this.lblConnValue = new System.Windows.Forms.Label();
            this.lblConn = new System.Windows.Forms.Label();
            this.lblShake = new System.Windows.Forms.Label();
            this.lblIllumValue = new System.Windows.Forms.Label();
            this.lblIllum = new System.Windows.Forms.Label();
            this.lblShakeValue = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslError = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslState = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
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
            // lblDist
            // 
            this.lblDist.AutoSize = true;
            this.lblDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDist.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblDist.Location = new System.Drawing.Point(4, 0);
            this.lblDist.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDist.Name = "lblDist";
            this.lblDist.Size = new System.Drawing.Size(177, 50);
            this.lblDist.TabIndex = 66;
            this.lblDist.Text = "距离";
            this.lblDist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDist.Click += new System.EventHandler(this.lblDist_Click);
            // 
            // lblDistValue
            // 
            this.lblDistValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDistValue.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblDistValue.Location = new System.Drawing.Point(189, 0);
            this.lblDistValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDistValue.Name = "lblDistValue";
            this.lblDistValue.Size = new System.Drawing.Size(547, 50);
            this.lblDistValue.TabIndex = 71;
            this.lblDistValue.Text = "无数据";
            this.lblDistValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(255)))), ((int)(((byte)(124)))));
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblState.Location = new System.Drawing.Point(195, 210);
            this.lblState.Margin = new System.Windows.Forms.Padding(10);
            this.lblState.Name = "lblState";
            this.tableLayoutPanel1.SetRowSpan(this.lblState, 4);
            this.lblState.Size = new System.Drawing.Size(535, 375);
            this.lblState.TabIndex = 74;
            this.lblState.Text = "AA级警报";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBuzz
            // 
            this.btnBuzz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuzz.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBuzz.Location = new System.Drawing.Point(4, 204);
            this.btnBuzz.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuzz.Name = "btnBuzz";
            this.btnBuzz.Size = new System.Drawing.Size(177, 90);
            this.btnBuzz.TabIndex = 76;
            this.btnBuzz.Text = "启动蜂鸣器";
            this.btnBuzz.UseVisualStyleBackColor = true;
            this.btnBuzz.Click += new System.EventHandler(this.btnBuzz_Click);
            // 
            // btnIgnore
            // 
            this.btnIgnore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIgnore.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIgnore.Location = new System.Drawing.Point(4, 400);
            this.btnIgnore.Margin = new System.Windows.Forms.Padding(4);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(177, 90);
            this.btnIgnore.TabIndex = 77;
            this.btnIgnore.Text = "忽略警报";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSettings.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSettings.Location = new System.Drawing.Point(4, 498);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(177, 93);
            this.btnSettings.TabIndex = 78;
            this.btnSettings.Text = "高级选项";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.btnUnbuzz, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblConnValue, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSettings, 0, 7);
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(740, 595);
            this.tableLayoutPanel1.TabIndex = 79;
            // 
            // btnUnbuzz
            // 
            this.btnUnbuzz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUnbuzz.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUnbuzz.Location = new System.Drawing.Point(4, 302);
            this.btnUnbuzz.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnbuzz.Name = "btnUnbuzz";
            this.btnUnbuzz.Size = new System.Drawing.Size(177, 90);
            this.btnUnbuzz.TabIndex = 81;
            this.btnUnbuzz.Text = "关闭蜂鸣器";
            this.btnUnbuzz.UseVisualStyleBackColor = true;
            this.btnUnbuzz.Click += new System.EventHandler(this.btnUnbuzz_Click);
            // 
            // lblConnValue
            // 
            this.lblConnValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConnValue.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblConnValue.Location = new System.Drawing.Point(189, 150);
            this.lblConnValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnValue.Name = "lblConnValue";
            this.lblConnValue.Size = new System.Drawing.Size(547, 50);
            this.lblConnValue.TabIndex = 77;
            this.lblConnValue.Text = "无数据";
            this.lblConnValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConn
            // 
            this.lblConn.AutoSize = true;
            this.lblConn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConn.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblConn.Location = new System.Drawing.Point(4, 150);
            this.lblConn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConn.Name = "lblConn";
            this.lblConn.Size = new System.Drawing.Size(177, 50);
            this.lblConn.TabIndex = 76;
            this.lblConn.Text = "连接";
            this.lblConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConn.Click += new System.EventHandler(this.lblConn_Click);
            // 
            // lblShake
            // 
            this.lblShake.AutoSize = true;
            this.lblShake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShake.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblShake.Location = new System.Drawing.Point(4, 100);
            this.lblShake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShake.Name = "lblShake";
            this.lblShake.Size = new System.Drawing.Size(177, 50);
            this.lblShake.TabIndex = 75;
            this.lblShake.Text = "振动";
            this.lblShake.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblShake.Click += new System.EventHandler(this.lblShake_Click);
            // 
            // lblIllumValue
            // 
            this.lblIllumValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIllumValue.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblIllumValue.Location = new System.Drawing.Point(189, 50);
            this.lblIllumValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIllumValue.Name = "lblIllumValue";
            this.lblIllumValue.Size = new System.Drawing.Size(547, 50);
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
            this.lblIllum.Size = new System.Drawing.Size(177, 50);
            this.lblIllum.TabIndex = 72;
            this.lblIllum.Text = "照度";
            this.lblIllum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIllum.Click += new System.EventHandler(this.lblIllum_Click);
            // 
            // lblShakeValue
            // 
            this.lblShakeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShakeValue.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblShakeValue.Location = new System.Drawing.Point(189, 100);
            this.lblShakeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShakeValue.Name = "lblShakeValue";
            this.lblShakeValue.Size = new System.Drawing.Size(547, 50);
            this.lblShakeValue.TabIndex = 74;
            this.lblShakeValue.Text = "无数据";
            this.lblShakeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslError,
            this.tslState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 595);
            this.statusStrip1.Name = "statusStrip1";
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
            // tslState
            // 
            this.tslState.BackColor = System.Drawing.SystemColors.Control;
            this.tslState.Name = "tslState";
            this.tslState.Size = new System.Drawing.Size(1039, 24);
            this.tslState.Spring = true;
            this.tslState.Text = "安全状态：正常";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPage1);
            this.tabSettings.Controls.Add(this.tabPage2);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabSettings.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabSettings.Location = new System.Drawing.Point(740, 0);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(4);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(432, 595);
            this.tabSettings.TabIndex = 81;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(424, 558);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "日志";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(4, 4);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(416, 550);
            this.txtLog.TabIndex = 64;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(424, 558);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(416, 550);
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
            this.btnToggleCom.Margin = new System.Windows.Forms.Padding(4);
            this.btnToggleCom.Name = "btnToggleCom";
            this.btnToggleCom.Size = new System.Drawing.Size(408, 42);
            this.btnToggleCom.TabIndex = 24;
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
            this.comboBoxParity.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(288, 32);
            this.comboBoxParity.TabIndex = 9;
            // 
            // comboBoxSerialPorts
            // 
            this.comboBoxSerialPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxSerialPorts.FormattingEnabled = true;
            this.comboBoxSerialPorts.Location = new System.Drawing.Point(124, 4);
            this.comboBoxSerialPorts.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            this.comboBoxSerialPorts.Size = new System.Drawing.Size(288, 32);
            this.comboBoxSerialPorts.TabIndex = 23;
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
            this.comboBoxStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(288, 32);
            this.comboBoxStopBits.TabIndex = 8;
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
            this.comboBoxBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(288, 32);
            this.comboBoxBaudRate.TabIndex = 6;
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
            this.comboBoxWordLength.Size = new System.Drawing.Size(288, 32);
            this.comboBoxWordLength.TabIndex = 7;
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
            // FrmAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1172, 624);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.labelReadData);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAlarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基于Verilog的大件贵重物品安保系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmSystem_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelReadData;
        private System.Windows.Forms.Label lblDist;
        private System.Windows.Forms.Label lblDistValue;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnBuzz;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblIllumValue;
        private System.Windows.Forms.Label lblIllum;
        private System.Windows.Forms.Label lblConnValue;
        private System.Windows.Forms.Label lblConn;
        private System.Windows.Forms.Label lblShake;
        private System.Windows.Forms.Label lblShakeValue;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslError;
        private System.Windows.Forms.ToolStripStatusLabel tslState;
        private System.Windows.Forms.Button btnUnbuzz;
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
    }
}

