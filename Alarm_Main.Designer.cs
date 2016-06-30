namespace alarm
{
    partial class Alarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alarm));
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
            this.buttonWakeUp = new System.Windows.Forms.Button();
            this.buttonVerifyKeyA = new System.Windows.Forms.Button();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUID = new System.Windows.Forms.Label();
            this.labelVerifyKeyA = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxWritedata = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labelWrite = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labelRead = new System.Windows.Forms.Label();
            this.labelReadData = new System.Windows.Forms.Label();
            this.buttonGetUID = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelWakeUp = new System.Windows.Forms.Label();
            this.labelTagType = new System.Windows.Forms.Label();
            this.radioButtonKeyA = new System.Windows.Forms.RadioButton();
            this.radioButtonKeyB = new System.Windows.Forms.RadioButton();
            this.checkBoxkeywrite = new System.Windows.Forms.CheckBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTarget = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtBoxRxtData = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.comboBoxWordLength = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
            this.buttonOpenOrCloseCom = new System.Windows.Forms.Button();
            this.textBoxByTimeSend = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxByTimeSend = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSpNum,
            this.tsBaudRate,
            this.tsDataBits,
            this.tsStopBits,
            this.tsParity,
            this.tsSend,
            this.tsRec});
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(743, 22);
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
            this.buttonCleanWindows.Location = new System.Drawing.Point(197, 243);
            this.buttonCleanWindows.Name = "buttonCleanWindows";
            this.buttonCleanWindows.Size = new System.Drawing.Size(74, 38);
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
            // buttonWakeUp
            // 
            this.buttonWakeUp.Location = new System.Drawing.Point(12, 16);
            this.buttonWakeUp.Name = "buttonWakeUp";
            this.buttonWakeUp.Size = new System.Drawing.Size(141, 26);
            this.buttonWakeUp.TabIndex = 7;
            this.buttonWakeUp.Text = "唤醒NFC模块(&1)";
            this.buttonWakeUp.UseVisualStyleBackColor = true;
            this.buttonWakeUp.Click += new System.EventHandler(this.buttonWakeUp_Click);
            // 
            // buttonVerifyKeyA
            // 
            this.buttonVerifyKeyA.Location = new System.Drawing.Point(83, 88);
            this.buttonVerifyKeyA.Name = "buttonVerifyKeyA";
            this.buttonVerifyKeyA.Size = new System.Drawing.Size(70, 26);
            this.buttonVerifyKeyA.TabIndex = 31;
            this.buttonVerifyKeyA.Text = "验证(&3)";
            this.buttonVerifyKeyA.UseVisualStyleBackColor = true;
            this.buttonVerifyKeyA.Click += new System.EventHandler(this.buttonVerifyKeyA_Click);
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(83, 123);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(70, 26);
            this.buttonWrite.TabIndex = 32;
            this.buttonWrite.Text = "写数据(&4)";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(12, 160);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(141, 26);
            this.buttonRead.TabIndex = 33;
            this.buttonRead.Text = "从标签读出数据(&5)";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "UID：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "验证是否成功：";
            // 
            // labelUID
            // 
            this.labelUID.AutoSize = true;
            this.labelUID.Location = new System.Drawing.Point(114, 262);
            this.labelUID.Name = "labelUID";
            this.labelUID.Size = new System.Drawing.Size(41, 12);
            this.labelUID.TabIndex = 40;
            this.labelUID.Text = "无响应";
            // 
            // labelVerifyKeyA
            // 
            this.labelVerifyKeyA.AutoSize = true;
            this.labelVerifyKeyA.Location = new System.Drawing.Point(114, 298);
            this.labelVerifyKeyA.Name = "labelVerifyKeyA";
            this.labelVerifyKeyA.Size = new System.Drawing.Size(41, 12);
            this.labelVerifyKeyA.TabIndex = 41;
            this.labelVerifyKeyA.Text = "无响应";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 343);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 12);
            this.label11.TabIndex = 43;
            // 
            // textBoxWritedata
            // 
            this.textBoxWritedata.Location = new System.Drawing.Point(161, 331);
            this.textBoxWritedata.Name = "textBoxWritedata";
            this.textBoxWritedata.Size = new System.Drawing.Size(300, 21);
            this.textBoxWritedata.TabIndex = 44;
            this.textBoxWritedata.Text = "00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 335);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 45;
            this.label12.Text = "写入是否成功：";
            // 
            // labelWrite
            // 
            this.labelWrite.AutoSize = true;
            this.labelWrite.Location = new System.Drawing.Point(114, 334);
            this.labelWrite.Name = "labelWrite";
            this.labelWrite.Size = new System.Drawing.Size(41, 12);
            this.labelWrite.TabIndex = 46;
            this.labelWrite.Text = "无响应";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 371);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 12);
            this.label15.TabIndex = 47;
            this.label15.Text = "读出是否成功：";
            // 
            // labelRead
            // 
            this.labelRead.AutoSize = true;
            this.labelRead.Location = new System.Drawing.Point(114, 370);
            this.labelRead.Name = "labelRead";
            this.labelRead.Size = new System.Drawing.Size(41, 12);
            this.labelRead.TabIndex = 48;
            this.labelRead.Text = "无响应";
            // 
            // labelReadData
            // 
            this.labelReadData.AutoSize = true;
            this.labelReadData.Location = new System.Drawing.Point(345, 372);
            this.labelReadData.Name = "labelReadData";
            this.labelReadData.Size = new System.Drawing.Size(0, 12);
            this.labelReadData.TabIndex = 49;
            // 
            // buttonGetUID
            // 
            this.buttonGetUID.Location = new System.Drawing.Point(12, 52);
            this.buttonGetUID.Name = "buttonGetUID";
            this.buttonGetUID.Size = new System.Drawing.Size(141, 26);
            this.buttonGetUID.TabIndex = 50;
            this.buttonGetUID.Text = "寻找NFC标签(&2)";
            this.buttonGetUID.UseVisualStyleBackColor = true;
            this.buttonGetUID.Click += new System.EventHandler(this.buttonGetUID_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 51;
            this.label4.Text = "唤醒是否成功:";
            // 
            // labelWakeUp
            // 
            this.labelWakeUp.AutoSize = true;
            this.labelWakeUp.Location = new System.Drawing.Point(114, 226);
            this.labelWakeUp.Name = "labelWakeUp";
            this.labelWakeUp.Size = new System.Drawing.Size(41, 12);
            this.labelWakeUp.TabIndex = 52;
            this.labelWakeUp.Text = "无响应";
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
            // radioButtonKeyA
            // 
            this.radioButtonKeyA.AutoSize = true;
            this.radioButtonKeyA.Location = new System.Drawing.Point(12, 85);
            this.radioButtonKeyA.Name = "radioButtonKeyA";
            this.radioButtonKeyA.Size = new System.Drawing.Size(47, 16);
            this.radioButtonKeyA.TabIndex = 55;
            this.radioButtonKeyA.TabStop = true;
            this.radioButtonKeyA.Text = "KeyA";
            this.radioButtonKeyA.UseVisualStyleBackColor = true;
            this.radioButtonKeyA.Click += new System.EventHandler(this.radioButtonKeyA_Click);
            // 
            // radioButtonKeyB
            // 
            this.radioButtonKeyB.AutoSize = true;
            this.radioButtonKeyB.Location = new System.Drawing.Point(12, 104);
            this.radioButtonKeyB.Name = "radioButtonKeyB";
            this.radioButtonKeyB.Size = new System.Drawing.Size(47, 16);
            this.radioButtonKeyB.TabIndex = 56;
            this.radioButtonKeyB.TabStop = true;
            this.radioButtonKeyB.Text = "KeyB";
            this.radioButtonKeyB.UseVisualStyleBackColor = true;
            this.radioButtonKeyB.Click += new System.EventHandler(this.radioButtonKeyB_Click);
            // 
            // checkBoxkeywrite
            // 
            this.checkBoxkeywrite.AutoSize = true;
            this.checkBoxkeywrite.Location = new System.Drawing.Point(11, 129);
            this.checkBoxkeywrite.Name = "checkBoxkeywrite";
            this.checkBoxkeywrite.Size = new System.Drawing.Size(72, 16);
            this.checkBoxkeywrite.TabIndex = 57;
            this.checkBoxkeywrite.Text = "修改权限";
            this.checkBoxkeywrite.UseVisualStyleBackColor = true;
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(3, 25);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(195, 21);
            this.txtSend.TabIndex = 58;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(142, 52);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(56, 23);
            this.btnSend.TabIndex = 59;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTarget);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.txtSend);
            this.panel1.Location = new System.Drawing.Point(277, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 83);
            this.panel1.TabIndex = 62;
            // 
            // btnTarget
            // 
            this.btnTarget.Location = new System.Drawing.Point(3, 52);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(77, 23);
            this.btnTarget.TabIndex = 60;
            this.btnTarget.Text = "TargetSend";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(103, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Target";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Initiator";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // txtBoxRxtData
            // 
            this.txtBoxRxtData.Location = new System.Drawing.Point(159, 12);
            this.txtBoxRxtData.Multiline = true;
            this.txtBoxRxtData.Name = "txtBoxRxtData";
            this.txtBoxRxtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxRxtData.Size = new System.Drawing.Size(189, 205);
            this.txtBoxRxtData.TabIndex = 63;
            this.txtBoxRxtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxRxtData_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 22);
            this.button1.TabIndex = 64;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(367, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(214, 230);
            this.tabControl1.TabIndex = 65;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(206, 204);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "控制台";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.comboBoxSerialPorts);
            this.tabPage2.Controls.Add(this.buttonOpenOrCloseCom);
            this.tabPage2.Controls.Add(this.textBoxByTimeSend);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.checkBoxByTimeSend);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(206, 204);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "串口设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxParity);
            this.groupBox1.Controls.Add(this.comboBoxStopBits);
            this.groupBox1.Controls.Add(this.comboBoxWordLength);
            this.groupBox1.Controls.Add(this.comboBoxBaudRate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(15, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 114);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口参数设置";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.comboBoxParity.Location = new System.Drawing.Point(67, 80);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(91, 20);
            this.comboBoxParity.TabIndex = 9;
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBoxStopBits.Location = new System.Drawing.Point(67, 59);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(91, 20);
            this.comboBoxStopBits.TabIndex = 8;
            // 
            // comboBoxWordLength
            // 
            this.comboBoxWordLength.FormattingEnabled = true;
            this.comboBoxWordLength.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxWordLength.Location = new System.Drawing.Point(67, 39);
            this.comboBoxWordLength.Name = "comboBoxWordLength";
            this.comboBoxWordLength.Size = new System.Drawing.Size(91, 20);
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
            this.comboBoxBaudRate.Location = new System.Drawing.Point(67, 18);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(91, 20);
            this.comboBoxBaudRate.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "校验位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "停止位";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "数据位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "波特率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "串口号:";
            // 
            // comboBoxSerialPorts
            // 
            this.comboBoxSerialPorts.FormattingEnabled = true;
            this.comboBoxSerialPorts.Location = new System.Drawing.Point(53, 16);
            this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            this.comboBoxSerialPorts.Size = new System.Drawing.Size(66, 20);
            this.comboBoxSerialPorts.TabIndex = 23;
            // 
            // buttonOpenOrCloseCom
            // 
            this.buttonOpenOrCloseCom.Location = new System.Drawing.Point(130, 15);
            this.buttonOpenOrCloseCom.Name = "buttonOpenOrCloseCom";
            this.buttonOpenOrCloseCom.Size = new System.Drawing.Size(66, 23);
            this.buttonOpenOrCloseCom.TabIndex = 24;
            this.buttonOpenOrCloseCom.Text = "打开串口";
            this.buttonOpenOrCloseCom.UseVisualStyleBackColor = true;
            this.buttonOpenOrCloseCom.Click += new System.EventHandler(this.buttonOpenOrCloseCom_Click);
            // 
            // textBoxByTimeSend
            // 
            this.textBoxByTimeSend.Location = new System.Drawing.Point(89, 164);
            this.textBoxByTimeSend.Name = "textBoxByTimeSend";
            this.textBoxByTimeSend.Size = new System.Drawing.Size(59, 21);
            this.textBoxByTimeSend.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(154, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "ms/次";
            // 
            // checkBoxByTimeSend
            // 
            this.checkBoxByTimeSend.AutoSize = true;
            this.checkBoxByTimeSend.Location = new System.Drawing.Point(15, 166);
            this.checkBoxByTimeSend.Name = "checkBoxByTimeSend";
            this.checkBoxByTimeSend.Size = new System.Drawing.Size(72, 16);
            this.checkBoxByTimeSend.TabIndex = 21;
            this.checkBoxByTimeSend.Text = "定时发送";
            this.checkBoxByTimeSend.UseVisualStyleBackColor = true;
            // 
            // Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(743, 417);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBoxRxtData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBoxkeywrite);
            this.Controls.Add(this.radioButtonKeyA);
            this.Controls.Add(this.radioButtonKeyB);
            this.Controls.Add(this.labelTagType);
            this.Controls.Add(this.labelWakeUp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonGetUID);
            this.Controls.Add(this.labelReadData);
            this.Controls.Add(this.labelRead);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.labelWrite);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxWritedata);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelVerifyKeyA);
            this.Controls.Add(this.labelUID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.buttonVerifyKeyA);
            this.Controls.Add(this.buttonWakeUp);
            this.Controls.Add(this.buttonCleanWindows);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Alarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基于Verilog的大件贵重物品安保系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmSystem_FormClosing);
            this.Load += new System.EventHandler(this.AlarmSystem_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button buttonWakeUp;
        private System.Windows.Forms.ToolStripStatusLabel tsSend;
        private System.Windows.Forms.ToolStripStatusLabel tsRec;
        private System.Windows.Forms.Button buttonVerifyKeyA;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelUID;
        private System.Windows.Forms.Label labelVerifyKeyA;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxWritedata;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelWrite;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelRead;
        private System.Windows.Forms.Label labelReadData;
        private System.Windows.Forms.Button buttonGetUID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelWakeUp;
        private System.Windows.Forms.Label labelTagType;
        private System.Windows.Forms.RadioButton radioButtonKeyA;
        private System.Windows.Forms.RadioButton radioButtonKeyB;
        private System.Windows.Forms.CheckBox checkBoxkeywrite;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtBoxRxtData;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
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
    }
}

