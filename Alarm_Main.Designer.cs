namespace alarm
{
    partial class Alarm_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alarm_Form));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsSpNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsBaudRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsDataBits = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStopBits = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsParity = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsSend = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsRec = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonCleanWindows = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.labelReadData = new System.Windows.Forms.Label();
            this.labelTagType = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtBoxRxtData = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxByTimeSend = new System.Windows.Forms.TextBox();
            this.checkBoxByTimeSend = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.buttonOpenOrCloseCom = new System.Windows.Forms.Button();
            this.comboBoxWordLength = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbConn = new System.Windows.Forms.Label();
            this.lbAcl2 = new System.Windows.Forms.Label();
            this.lbDist = new System.Windows.Forms.Label();
            this.lbIllum = new System.Windows.Forms.Label();
            this.lbState = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("微软雅黑", 8.999999F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSpNum,
            this.tsBaudRate,
            this.tsDataBits,
            this.tsStopBits,
            this.tsParity,
            this.tsSend,
            this.tsRec});
            this.statusStrip1.Location = new System.Drawing.Point(0, 250);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(644, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsSpNum
            // 
            this.tsSpNum.Name = "tsSpNum";
            this.tsSpNum.Size = new System.Drawing.Size(96, 17);
            this.tsSpNum.Text = "串口号：未指定 ";
            // 
            // tsBaudRate
            // 
            this.tsBaudRate.Name = "tsBaudRate";
            this.tsBaudRate.Size = new System.Drawing.Size(96, 17);
            this.tsBaudRate.Text = "波特率：未指定 ";
            // 
            // tsDataBits
            // 
            this.tsDataBits.Name = "tsDataBits";
            this.tsDataBits.Size = new System.Drawing.Size(96, 17);
            this.tsDataBits.Text = "数据位：未指定 ";
            // 
            // tsStopBits
            // 
            this.tsStopBits.Name = "tsStopBits";
            this.tsStopBits.Size = new System.Drawing.Size(96, 17);
            this.tsStopBits.Text = "停止位：未指定 ";
            // 
            // tsParity
            // 
            this.tsParity.Name = "tsParity";
            this.tsParity.Size = new System.Drawing.Size(108, 17);
            this.tsParity.Text = "校验位：未指定    ";
            // 
            // tsSend
            // 
            this.tsSend.Name = "tsSend";
            this.tsSend.Size = new System.Drawing.Size(49, 17);
            this.tsSend.Text = "T : 0    ";
            // 
            // tsRec
            // 
            this.tsRec.Name = "tsRec";
            this.tsRec.Size = new System.Drawing.Size(46, 17);
            this.tsRec.Text = "R : 0   ";
            // 
            // buttonCleanWindows
            // 
            this.buttonCleanWindows.Location = new System.Drawing.Point(190, 156);
            this.buttonCleanWindows.Name = "buttonCleanWindows";
            this.buttonCleanWindows.Size = new System.Drawing.Size(67, 23);
            this.buttonCleanWindows.TabIndex = 15;
            this.buttonCleanWindows.Text = "清除内容";
            this.buttonCleanWindows.UseVisualStyleBackColor = true;
            this.buttonCleanWindows.Click += new System.EventHandler(this.buttonCleanWindows_Click);
            // 
            // timerSend
            // 
            this.timerSend.Interval = 1000;
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // labelReadData
            // 
            this.labelReadData.AutoSize = true;
            this.labelReadData.Location = new System.Drawing.Point(345, 372);
            this.labelReadData.Name = "labelReadData";
            this.labelReadData.Size = new System.Drawing.Size(0, 12);
            this.labelReadData.TabIndex = 49;
            // 
            // labelTagType
            // 
            this.labelTagType.AutoSize = true;
            this.labelTagType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTagType.ForeColor = System.Drawing.Color.Blue;
            this.labelTagType.Location = new System.Drawing.Point(645, 311);
            this.labelTagType.Name = "labelTagType";
            this.labelTagType.Size = new System.Drawing.Size(0, 19);
            this.labelTagType.TabIndex = 54;
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(7, 181);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(178, 23);
            this.txtSend.TabIndex = 58;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(190, 182);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(67, 23);
            this.btnSend.TabIndex = 59;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtBoxRxtData
            // 
            this.txtBoxRxtData.Location = new System.Drawing.Point(5, 6);
            this.txtBoxRxtData.Multiline = true;
            this.txtBoxRxtData.Name = "txtBoxRxtData";
            this.txtBoxRxtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxRxtData.Size = new System.Drawing.Size(254, 146);
            this.txtBoxRxtData.TabIndex = 63;
            this.txtBoxRxtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxRxtData_KeyPress);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(371, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(273, 238);
            this.tabControl1.TabIndex = 65;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtBoxRxtData);
            this.tabPage1.Controls.Add(this.textBoxByTimeSend);
            this.tabPage1.Controls.Add(this.checkBoxByTimeSend);
            this.tabPage1.Controls.Add(this.btnSend);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtSend);
            this.tabPage1.Controls.Add(this.buttonCleanWindows);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(265, 208);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "控制台";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxByTimeSend
            // 
            this.textBoxByTimeSend.Location = new System.Drawing.Point(79, 156);
            this.textBoxByTimeSend.Name = "textBoxByTimeSend";
            this.textBoxByTimeSend.Size = new System.Drawing.Size(59, 23);
            this.textBoxByTimeSend.TabIndex = 19;
            this.textBoxByTimeSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxByTimeSend_KeyPress);
            // 
            // checkBoxByTimeSend
            // 
            this.checkBoxByTimeSend.AutoSize = true;
            this.checkBoxByTimeSend.Location = new System.Drawing.Point(7, 160);
            this.checkBoxByTimeSend.Name = "checkBoxByTimeSend";
            this.checkBoxByTimeSend.Size = new System.Drawing.Size(75, 21);
            this.checkBoxByTimeSend.TabIndex = 21;
            this.checkBoxByTimeSend.Text = "定时发送";
            this.checkBoxByTimeSend.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(141, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "ms/次";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBoxParity);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.comboBoxSerialPorts);
            this.tabPage2.Controls.Add(this.comboBoxStopBits);
            this.tabPage2.Controls.Add(this.buttonOpenOrCloseCom);
            this.tabPage2.Controls.Add(this.comboBoxWordLength);
            this.tabPage2.Controls.Add(this.comboBoxBaudRate);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(265, 208);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.comboBoxParity.Location = new System.Drawing.Point(51, 115);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(66, 25);
            this.comboBoxParity.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "串口号:";
            // 
            // comboBoxSerialPorts
            // 
            this.comboBoxSerialPorts.FormattingEnabled = true;
            this.comboBoxSerialPorts.Location = new System.Drawing.Point(51, 7);
            this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            this.comboBoxSerialPorts.Size = new System.Drawing.Size(66, 25);
            this.comboBoxSerialPorts.TabIndex = 23;
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBoxStopBits.Location = new System.Drawing.Point(51, 88);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(66, 25);
            this.comboBoxStopBits.TabIndex = 8;
            // 
            // buttonOpenOrCloseCom
            // 
            this.buttonOpenOrCloseCom.Location = new System.Drawing.Point(6, 181);
            this.buttonOpenOrCloseCom.Name = "buttonOpenOrCloseCom";
            this.buttonOpenOrCloseCom.Size = new System.Drawing.Size(111, 23);
            this.buttonOpenOrCloseCom.TabIndex = 24;
            this.buttonOpenOrCloseCom.Text = "打开串口";
            this.buttonOpenOrCloseCom.UseVisualStyleBackColor = true;
            this.buttonOpenOrCloseCom.Click += new System.EventHandler(this.buttonOpenOrCloseCom_Click);
            // 
            // comboBoxWordLength
            // 
            this.comboBoxWordLength.FormattingEnabled = true;
            this.comboBoxWordLength.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxWordLength.Location = new System.Drawing.Point(51, 61);
            this.comboBoxWordLength.Name = "comboBoxWordLength";
            this.comboBoxWordLength.Size = new System.Drawing.Size(66, 25);
            this.comboBoxWordLength.TabIndex = 7;
            // 
            // comboBoxBaudRate
            // 
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
            this.comboBoxBaudRate.Location = new System.Drawing.Point(51, 34);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(66, 25);
            this.comboBoxBaudRate.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "校验位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "波特率";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "数据位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "停止位";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(3, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 31);
            this.label9.TabIndex = 66;
            this.label9.Text = "照度:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(3, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 31);
            this.label13.TabIndex = 67;
            this.label13.Text = "距离:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(3, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 31);
            this.label14.TabIndex = 68;
            this.label14.Text = "震动:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(3, 111);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 31);
            this.label16.TabIndex = 69;
            this.label16.Text = "连接:";
            // 
            // lbConn
            // 
            this.lbConn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbConn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbConn.Location = new System.Drawing.Point(88, 111);
            this.lbConn.Name = "lbConn";
            this.lbConn.Size = new System.Drawing.Size(268, 31);
            this.lbConn.TabIndex = 73;
            this.lbConn.Text = "无数据";
            this.lbConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAcl2
            // 
            this.lbAcl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAcl2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAcl2.Location = new System.Drawing.Point(88, 77);
            this.lbAcl2.Name = "lbAcl2";
            this.lbAcl2.Size = new System.Drawing.Size(268, 31);
            this.lbAcl2.TabIndex = 72;
            this.lbAcl2.Text = "无数据";
            this.lbAcl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDist
            // 
            this.lbDist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDist.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDist.Location = new System.Drawing.Point(88, 43);
            this.lbDist.Name = "lbDist";
            this.lbDist.Size = new System.Drawing.Size(268, 31);
            this.lbDist.TabIndex = 71;
            this.lbDist.Text = "无数据";
            this.lbDist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbIllum
            // 
            this.lbIllum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbIllum.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIllum.Location = new System.Drawing.Point(88, 9);
            this.lbIllum.Name = "lbIllum";
            this.lbIllum.Size = new System.Drawing.Size(268, 31);
            this.lbIllum.TabIndex = 70;
            this.lbIllum.Text = "无数据";
            this.lbIllum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbState
            // 
            this.lbState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(255)))), ((int)(((byte)(124)))));
            this.lbState.Font = new System.Drawing.Font("方正剪纸繁体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbState.Location = new System.Drawing.Point(88, 148);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(268, 95);
            this.lbState.TabIndex = 74;
            this.lbState.Text = "安全";
            this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbState.Click += new System.EventHandler(this.lbState_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(9, 220);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 23);
            this.btnClose.TabIndex = 75;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(9, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 23);
            this.button3.TabIndex = 76;
            this.button3.Text = "鸣笛警报";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(9, 172);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 23);
            this.button4.TabIndex = 77;
            this.button4.Text = "关闭警报";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(9, 196);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 23);
            this.button5.TabIndex = 78;
            this.button5.Text = "切换显示";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.lbState_Click);
            // 
            // Alarm_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 272);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbState);
            this.Controls.Add(this.lbConn);
            this.Controls.Add(this.lbAcl2);
            this.Controls.Add(this.lbDist);
            this.Controls.Add(this.lbIllum);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelTagType);
            this.Controls.Add(this.labelReadData);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Alarm_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基于Verilog的大件贵重物品安保系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmSystem_FormClosing);
            this.Load += new System.EventHandler(this.AlarmSystem_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button buttonCleanWindows;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timerSend;
        private System.Windows.Forms.ToolStripStatusLabel tsSpNum;
        private System.Windows.Forms.ToolStripStatusLabel tsBaudRate;
        private System.Windows.Forms.ToolStripStatusLabel tsDataBits;
        private System.Windows.Forms.ToolStripStatusLabel tsStopBits;
        private System.Windows.Forms.ToolStripStatusLabel tsParity;
        private System.Windows.Forms.ToolStripStatusLabel tsSend;
        private System.Windows.Forms.ToolStripStatusLabel tsRec;
        private System.Windows.Forms.Label labelReadData;
        private System.Windows.Forms.Label labelTagType;
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
        private System.Windows.Forms.Button buttonOpenOrCloseCom;
        private System.Windows.Forms.TextBox textBoxByTimeSend;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxByTimeSend;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbConn;
        private System.Windows.Forms.Label lbAcl2;
        private System.Windows.Forms.Label lbDist;
        private System.Windows.Forms.Label lbIllum;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

