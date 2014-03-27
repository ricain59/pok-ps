namespace TiltStopLoss
{
    public partial class Main
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.linkLabelHelp = new System.Windows.Forms.LinkLabel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelAlertDb = new System.Windows.Forms.Label();
            this.checkBoxPt4 = new System.Windows.Forms.CheckBox();
            this.checkBoxHem2 = new System.Windows.Forms.CheckBox();
            this.checkBoxHem1 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayerID = new System.Windows.Forms.TextBox();
            this.buttonTestDb = new System.Windows.Forms.Button();
            this.labePassword = new System.Windows.Forms.Label();
            this.labelUserDb = new System.Windows.Forms.Label();
            this.labelDb = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxDb = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.labelTitleDB = new System.Windows.Forms.Label();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.textBoxPlayer = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linkLabelHelp2 = new System.Windows.Forms.LinkLabel();
            this.comboBoxBRM = new System.Windows.Forms.ComboBox();
            this.labelBrm = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.checkBoxButtonSet = new System.Windows.Forms.CheckBox();
            this.labelActiveSet = new System.Windows.Forms.Label();
            this.checkBoxCloseSkype = new System.Windows.Forms.CheckBox();
            this.labelCloseSkype = new System.Windows.Forms.Label();
            this.buttonChoiceSounds = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxPeakOver = new System.Windows.Forms.TextBox();
            this.checkBoxHideBbbs = new System.Windows.Forms.CheckBox();
            this.labelHideBbs = new System.Windows.Forms.Label();
            this.labelBbOver = new System.Windows.Forms.Label();
            this.textBoxStopLossPeak = new System.Windows.Forms.TextBox();
            this.labelStopLossPeak = new System.Windows.Forms.Label();
            this.labelResumeOnStop = new System.Windows.Forms.Label();
            this.checkBoxResumeSession = new System.Windows.Forms.CheckBox();
            this.textBoxStopWin = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.labelStopWin = new System.Windows.Forms.Label();
            this.textBoxStopTime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.labelStopTime = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxStopHand = new System.Windows.Forms.TextBox();
            this.labelStophands = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxStopLoss = new System.Windows.Forms.TextBox();
            this.labelStoploss = new System.Windows.Forms.Label();
            this.tabResumeSession = new System.Windows.Forms.TabPage();
            this.textBoxbb100 = new System.Windows.Forms.TextBox();
            this.labelbb100 = new System.Windows.Forms.Label();
            this.labelResumeSession = new System.Windows.Forms.Label();
            this.textBoxHistoryBbsMax = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxHistoryTime = new System.Windows.Forms.TextBox();
            this.textBoxHistoryHands = new System.Windows.Forms.TextBox();
            this.textBoxHistoryBbsloss = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.labelHistoryMax = new System.Windows.Forms.Label();
            this.textBoxBbsMax = new System.Windows.Forms.TextBox();
            this.labelBbsMax = new System.Windows.Forms.Label();
            this.textBoxRsTime = new System.Windows.Forms.TextBox();
            this.textBoxRsHands = new System.Windows.Forms.TextBox();
            this.textBoxRsBbs = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labelSessionBBs = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linkLabelFeedback = new System.Windows.Forms.LinkLabel();
            this.buttonDonate = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.openFileDialogSound = new System.Windows.Forms.OpenFileDialog();
            this.toolTipHelpText = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlMain.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabResumeSession.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabDatabase);
            this.tabControlMain.Controls.Add(this.tabPage3);
            this.tabControlMain.Controls.Add(this.tabResumeSession);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Location = new System.Drawing.Point(4, 2);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(334, 369);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabDatabase
            // 
            this.tabDatabase.Controls.Add(this.comboBoxLanguage);
            this.tabDatabase.Controls.Add(this.linkLabelHelp);
            this.tabDatabase.Controls.Add(this.labelVersion);
            this.tabDatabase.Controls.Add(this.labelAlertDb);
            this.tabDatabase.Controls.Add(this.checkBoxPt4);
            this.tabDatabase.Controls.Add(this.checkBoxHem2);
            this.tabDatabase.Controls.Add(this.checkBoxHem1);
            this.tabDatabase.Controls.Add(this.textBoxPlayerID);
            this.tabDatabase.Controls.Add(this.buttonTestDb);
            this.tabDatabase.Controls.Add(this.labePassword);
            this.tabDatabase.Controls.Add(this.labelUserDb);
            this.tabDatabase.Controls.Add(this.labelDb);
            this.tabDatabase.Controls.Add(this.labelPort);
            this.tabDatabase.Controls.Add(this.textBoxPass);
            this.tabDatabase.Controls.Add(this.textBoxUser);
            this.tabDatabase.Controls.Add(this.textBoxDb);
            this.tabDatabase.Controls.Add(this.textBoxPort);
            this.tabDatabase.Controls.Add(this.textBoxServer);
            this.tabDatabase.Controls.Add(this.labelServer);
            this.tabDatabase.Controls.Add(this.labelTitleDB);
            this.tabDatabase.Controls.Add(this.labelPlayer);
            this.tabDatabase.Controls.Add(this.textBoxPlayer);
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(326, 343);
            this.tabDatabase.TabIndex = 0;
            this.tabDatabase.Text = "Database";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "English",
            "Français",
            "Português"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(9, 6);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(130, 21);
            this.comboBoxLanguage.TabIndex = 30;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // linkLabelHelp
            // 
            this.linkLabelHelp.AutoSize = true;
            this.linkLabelHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelHelp.Location = new System.Drawing.Point(260, 11);
            this.linkLabelHelp.Name = "linkLabelHelp";
            this.linkLabelHelp.Size = new System.Drawing.Size(37, 16);
            this.linkLabelHelp.TabIndex = 29;
            this.linkLabelHelp.TabStop = true;
            this.linkLabelHelp.Text = "Help";
            this.linkLabelHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHelp_LinkClicked);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(292, 316);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(28, 13);
            this.labelVersion.TabIndex = 21;
            this.labelVersion.Text = "v1.4";
            // 
            // labelAlertDb
            // 
            this.labelAlertDb.AutoSize = true;
            this.labelAlertDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlertDb.ForeColor = System.Drawing.Color.Red;
            this.labelAlertDb.Location = new System.Drawing.Point(183, 130);
            this.labelAlertDb.Name = "labelAlertDb";
            this.labelAlertDb.Size = new System.Drawing.Size(22, 13);
            this.labelAlertDb.TabIndex = 20;
            this.labelAlertDb.Text = "     ";
            this.labelAlertDb.Visible = false;
            // 
            // checkBoxPt4
            // 
            this.checkBoxPt4.AutoSize = true;
            this.checkBoxPt4.Location = new System.Drawing.Point(142, 130);
            this.checkBoxPt4.Name = "checkBoxPt4";
            this.checkBoxPt4.Size = new System.Drawing.Size(46, 17);
            this.checkBoxPt4.TabIndex = 19;
            this.checkBoxPt4.Text = "PT4";
            this.checkBoxPt4.UseVisualStyleBackColor = true;
            this.checkBoxPt4.CheckedChanged += new System.EventHandler(this.checkBoxPt4_CheckedChanged);
            // 
            // checkBoxHem2
            // 
            this.checkBoxHem2.AutoSize = true;
            this.checkBoxHem2.Location = new System.Drawing.Point(80, 130);
            this.checkBoxHem2.Name = "checkBoxHem2";
            this.checkBoxHem2.Size = new System.Drawing.Size(56, 17);
            this.checkBoxHem2.TabIndex = 18;
            this.checkBoxHem2.Text = "HEM2";
            this.checkBoxHem2.UseVisualStyleBackColor = true;
            this.checkBoxHem2.CheckedChanged += new System.EventHandler(this.checkBoxHem2_CheckedChanged);
            // 
            // checkBoxHem1
            // 
            this.checkBoxHem1.AutoSize = true;
            this.checkBoxHem1.Location = new System.Drawing.Point(19, 129);
            this.checkBoxHem1.Name = "checkBoxHem1";
            this.checkBoxHem1.Size = new System.Drawing.Size(56, 17);
            this.checkBoxHem1.TabIndex = 17;
            this.checkBoxHem1.Text = "HEM1";
            this.checkBoxHem1.UseVisualStyleBackColor = true;
            this.checkBoxHem1.CheckedChanged += new System.EventHandler(this.checkBoxHem1_CheckedChanged);
            // 
            // textBoxPlayerID
            // 
            this.textBoxPlayerID.Enabled = false;
            this.textBoxPlayerID.Location = new System.Drawing.Point(120, 51);
            this.textBoxPlayerID.Name = "textBoxPlayerID";
            this.textBoxPlayerID.Size = new System.Drawing.Size(39, 20);
            this.textBoxPlayerID.TabIndex = 15;
            // 
            // buttonTestDb
            // 
            this.buttonTestDb.Location = new System.Drawing.Point(141, 293);
            this.buttonTestDb.Name = "buttonTestDb";
            this.buttonTestDb.Size = new System.Drawing.Size(75, 23);
            this.buttonTestDb.TabIndex = 13;
            this.buttonTestDb.Text = "Test";
            this.buttonTestDb.UseVisualStyleBackColor = true;
            this.buttonTestDb.Click += new System.EventHandler(this.buttonTestDb_Click);
            // 
            // labePassword
            // 
            this.labePassword.AutoSize = true;
            this.labePassword.Location = new System.Drawing.Point(6, 273);
            this.labePassword.Name = "labePassword";
            this.labePassword.Size = new System.Drawing.Size(53, 13);
            this.labePassword.TabIndex = 12;
            this.labePassword.Text = "Password";
            // 
            // labelUserDb
            // 
            this.labelUserDb.AutoSize = true;
            this.labelUserDb.Location = new System.Drawing.Point(6, 246);
            this.labelUserDb.Name = "labelUserDb";
            this.labelUserDb.Size = new System.Drawing.Size(43, 13);
            this.labelUserDb.TabIndex = 11;
            this.labelUserDb.Text = "UserDb";
            // 
            // labelDb
            // 
            this.labelDb.AutoSize = true;
            this.labelDb.Location = new System.Drawing.Point(6, 219);
            this.labelDb.Name = "labelDb";
            this.labelDb.Size = new System.Drawing.Size(53, 13);
            this.labelDb.TabIndex = 10;
            this.labelDb.Text = "Database";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(6, 192);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(26, 13);
            this.labelPort.TabIndex = 9;
            this.labelPort.Text = "Port";
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(120, 267);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(177, 20);
            this.textBoxPass.TabIndex = 8;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(120, 240);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(177, 20);
            this.textBoxUser.TabIndex = 7;
            // 
            // textBoxDb
            // 
            this.textBoxDb.Location = new System.Drawing.Point(120, 213);
            this.textBoxDb.Name = "textBoxDb";
            this.textBoxDb.Size = new System.Drawing.Size(177, 20);
            this.textBoxDb.TabIndex = 6;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(120, 186);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(177, 20);
            this.textBoxPort.TabIndex = 5;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(120, 159);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(177, 20);
            this.textBoxServer.TabIndex = 4;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(6, 166);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(38, 13);
            this.labelServer.TabIndex = 3;
            this.labelServer.Text = "Server";
            // 
            // labelTitleDB
            // 
            this.labelTitleDB.AutoSize = true;
            this.labelTitleDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleDB.Location = new System.Drawing.Point(84, 98);
            this.labelTitleDB.Name = "labelTitleDB";
            this.labelTitleDB.Size = new System.Drawing.Size(144, 20);
            this.labelTitleDB.TabIndex = 2;
            this.labelTitleDB.Text = "Database Config";
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Location = new System.Drawing.Point(6, 58);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(36, 13);
            this.labelPlayer.TabIndex = 1;
            this.labelPlayer.Text = "Player";
            // 
            // textBoxPlayer
            // 
            this.textBoxPlayer.Location = new System.Drawing.Point(165, 51);
            this.textBoxPlayer.Name = "textBoxPlayer";
            this.textBoxPlayer.Size = new System.Drawing.Size(132, 20);
            this.textBoxPlayer.TabIndex = 0;
            this.textBoxPlayer.Leave += new System.EventHandler(this.textBoxPlayer_Leave);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.linkLabelHelp2);
            this.tabPage3.Controls.Add(this.comboBoxBRM);
            this.tabPage3.Controls.Add(this.labelBrm);
            this.tabPage3.Controls.Add(this.labelInfo);
            this.tabPage3.Controls.Add(this.checkBoxButtonSet);
            this.tabPage3.Controls.Add(this.labelActiveSet);
            this.tabPage3.Controls.Add(this.checkBoxCloseSkype);
            this.tabPage3.Controls.Add(this.labelCloseSkype);
            this.tabPage3.Controls.Add(this.buttonChoiceSounds);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.textBoxPeakOver);
            this.tabPage3.Controls.Add(this.checkBoxHideBbbs);
            this.tabPage3.Controls.Add(this.labelHideBbs);
            this.tabPage3.Controls.Add(this.labelBbOver);
            this.tabPage3.Controls.Add(this.textBoxStopLossPeak);
            this.tabPage3.Controls.Add(this.labelStopLossPeak);
            this.tabPage3.Controls.Add(this.labelResumeOnStop);
            this.tabPage3.Controls.Add(this.checkBoxResumeSession);
            this.tabPage3.Controls.Add(this.textBoxStopWin);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.labelStopWin);
            this.tabPage3.Controls.Add(this.textBoxStopTime);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.labelStopTime);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.textBoxStopHand);
            this.tabPage3.Controls.Add(this.labelStophands);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.textBoxStopLoss);
            this.tabPage3.Controls.Add(this.labelStoploss);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(326, 343);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Conf. Stop";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // linkLabelHelp2
            // 
            this.linkLabelHelp2.AutoSize = true;
            this.linkLabelHelp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelHelp2.Location = new System.Drawing.Point(278, 11);
            this.linkLabelHelp2.Name = "linkLabelHelp2";
            this.linkLabelHelp2.Size = new System.Drawing.Size(37, 16);
            this.linkLabelHelp2.TabIndex = 44;
            this.linkLabelHelp2.TabStop = true;
            this.linkLabelHelp2.Text = "Help";
            this.linkLabelHelp2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHelp2_LinkClicked);
            // 
            // comboBoxBRM
            // 
            this.comboBoxBRM.FormattingEnabled = true;
            this.comboBoxBRM.Items.AddRange(new object[] {
            "NO",
            "2",
            "5",
            "10",
            "16",
            "20",
            "25",
            "50",
            "100",
            "200",
            "400",
            "500"});
            this.comboBoxBRM.Location = new System.Drawing.Point(161, 270);
            this.comboBoxBRM.Name = "comboBoxBRM";
            this.comboBoxBRM.Size = new System.Drawing.Size(45, 21);
            this.comboBoxBRM.TabIndex = 43;
            // 
            // labelBrm
            // 
            this.labelBrm.AutoSize = true;
            this.labelBrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBrm.Location = new System.Drawing.Point(6, 274);
            this.labelBrm.Name = "labelBrm";
            this.labelBrm.Size = new System.Drawing.Size(109, 13);
            this.labelBrm.TabIndex = 42;
            this.labelBrm.Text = "Block Limit Above";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(212, 274);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(87, 13);
            this.labelInfo.TabIndex = 41;
            this.labelInfo.Text = "View help please";
            // 
            // checkBoxButtonSet
            // 
            this.checkBoxButtonSet.AutoSize = true;
            this.checkBoxButtonSet.Location = new System.Drawing.Point(191, 250);
            this.checkBoxButtonSet.Name = "checkBoxButtonSet";
            this.checkBoxButtonSet.Size = new System.Drawing.Size(15, 14);
            this.checkBoxButtonSet.TabIndex = 39;
            this.checkBoxButtonSet.UseVisualStyleBackColor = true;
            // 
            // labelActiveSet
            // 
            this.labelActiveSet.AutoSize = true;
            this.labelActiveSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActiveSet.Location = new System.Drawing.Point(6, 250);
            this.labelActiveSet.Name = "labelActiveSet";
            this.labelActiveSet.Size = new System.Drawing.Size(122, 13);
            this.labelActiveSet.TabIndex = 38;
            this.labelActiveSet.Text = "Activate button set?";
            // 
            // checkBoxCloseSkype
            // 
            this.checkBoxCloseSkype.AutoSize = true;
            this.checkBoxCloseSkype.Location = new System.Drawing.Point(191, 224);
            this.checkBoxCloseSkype.Name = "checkBoxCloseSkype";
            this.checkBoxCloseSkype.Size = new System.Drawing.Size(15, 14);
            this.checkBoxCloseSkype.TabIndex = 35;
            this.checkBoxCloseSkype.UseVisualStyleBackColor = true;
            // 
            // labelCloseSkype
            // 
            this.labelCloseSkype.AutoSize = true;
            this.labelCloseSkype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCloseSkype.Location = new System.Drawing.Point(6, 224);
            this.labelCloseSkype.Name = "labelCloseSkype";
            this.labelCloseSkype.Size = new System.Drawing.Size(84, 13);
            this.labelCloseSkype.TabIndex = 34;
            this.labelCloseSkype.Text = "Close Skype?";
            // 
            // buttonChoiceSounds
            // 
            this.buttonChoiceSounds.Location = new System.Drawing.Point(19, 305);
            this.buttonChoiceSounds.Name = "buttonChoiceSounds";
            this.buttonChoiceSounds.Size = new System.Drawing.Size(75, 23);
            this.buttonChoiceSounds.TabIndex = 33;
            this.buttonChoiceSounds.Text = "Sounds";
            this.buttonChoiceSounds.UseVisualStyleBackColor = true;
            this.buttonChoiceSounds.Click += new System.EventHandler(this.buttonChoiceSounds_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(294, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 13);
            this.label21.TabIndex = 32;
            this.label21.Text = "BBs";
            // 
            // textBoxPeakOver
            // 
            this.textBoxPeakOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPeakOver.ForeColor = System.Drawing.Color.Red;
            this.textBoxPeakOver.Location = new System.Drawing.Point(253, 54);
            this.textBoxPeakOver.Name = "textBoxPeakOver";
            this.textBoxPeakOver.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxPeakOver.Size = new System.Drawing.Size(35, 20);
            this.textBoxPeakOver.TabIndex = 31;
            this.textBoxPeakOver.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxPeakOver.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // checkBoxHideBbbs
            // 
            this.checkBoxHideBbbs.AutoSize = true;
            this.checkBoxHideBbbs.Location = new System.Drawing.Point(191, 198);
            this.checkBoxHideBbbs.Name = "checkBoxHideBbbs";
            this.checkBoxHideBbbs.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHideBbbs.TabIndex = 29;
            this.checkBoxHideBbbs.UseVisualStyleBackColor = true;
            // 
            // labelHideBbs
            // 
            this.labelHideBbs.AutoSize = true;
            this.labelHideBbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHideBbs.Location = new System.Drawing.Point(6, 198);
            this.labelHideBbs.Name = "labelHideBbs";
            this.labelHideBbs.Size = new System.Drawing.Size(59, 13);
            this.labelHideBbs.TabIndex = 28;
            this.labelHideBbs.Text = "Hide BBs";
            // 
            // labelBbOver
            // 
            this.labelBbOver.AutoSize = true;
            this.labelBbOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBbOver.ForeColor = System.Drawing.Color.Red;
            this.labelBbOver.Location = new System.Drawing.Point(150, 61);
            this.labelBbOver.Name = "labelBbOver";
            this.labelBbOver.Size = new System.Drawing.Size(58, 13);
            this.labelBbOver.TabIndex = 26;
            this.labelBbOver.Text = "BBs over";
            // 
            // textBoxStopLossPeak
            // 
            this.textBoxStopLossPeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStopLossPeak.ForeColor = System.Drawing.Color.Red;
            this.textBoxStopLossPeak.Location = new System.Drawing.Point(110, 54);
            this.textBoxStopLossPeak.Name = "textBoxStopLossPeak";
            this.textBoxStopLossPeak.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxStopLossPeak.Size = new System.Drawing.Size(34, 20);
            this.textBoxStopLossPeak.TabIndex = 25;
            this.textBoxStopLossPeak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxStopLossPeak.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStopLossPeak_KeyPress);
            // 
            // labelStopLossPeak
            // 
            this.labelStopLossPeak.AutoSize = true;
            this.labelStopLossPeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStopLossPeak.ForeColor = System.Drawing.Color.Red;
            this.labelStopLossPeak.Location = new System.Drawing.Point(6, 60);
            this.labelStopLossPeak.Name = "labelStopLossPeak";
            this.labelStopLossPeak.Size = new System.Drawing.Size(88, 13);
            this.labelStopLossPeak.TabIndex = 24;
            this.labelStopLossPeak.Text = "StopLossPeak";
            // 
            // labelResumeOnStop
            // 
            this.labelResumeOnStop.AutoSize = true;
            this.labelResumeOnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResumeOnStop.Location = new System.Drawing.Point(6, 170);
            this.labelResumeOnStop.Name = "labelResumeOnStop";
            this.labelResumeOnStop.Size = new System.Drawing.Size(100, 13);
            this.labelResumeOnStop.TabIndex = 16;
            this.labelResumeOnStop.Text = "Resume on Stop";
            // 
            // checkBoxResumeSession
            // 
            this.checkBoxResumeSession.AutoSize = true;
            this.checkBoxResumeSession.Location = new System.Drawing.Point(191, 170);
            this.checkBoxResumeSession.Name = "checkBoxResumeSession";
            this.checkBoxResumeSession.Size = new System.Drawing.Size(15, 14);
            this.checkBoxResumeSession.TabIndex = 15;
            this.checkBoxResumeSession.UseVisualStyleBackColor = true;
            this.checkBoxResumeSession.CheckedChanged += new System.EventHandler(this.checkBoxResumeSession_CheckedChanged);
            // 
            // textBoxStopWin
            // 
            this.textBoxStopWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStopWin.ForeColor = System.Drawing.Color.Green;
            this.textBoxStopWin.Location = new System.Drawing.Point(110, 139);
            this.textBoxStopWin.Name = "textBoxStopWin";
            this.textBoxStopWin.Size = new System.Drawing.Size(71, 20);
            this.textBoxStopWin.TabIndex = 14;
            this.textBoxStopWin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxStopWin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStopWin_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Green;
            this.label14.Location = new System.Drawing.Point(191, 146);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "BBs";
            // 
            // labelStopWin
            // 
            this.labelStopWin.AutoSize = true;
            this.labelStopWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStopWin.ForeColor = System.Drawing.Color.Green;
            this.labelStopWin.Location = new System.Drawing.Point(6, 145);
            this.labelStopWin.Name = "labelStopWin";
            this.labelStopWin.Size = new System.Drawing.Size(55, 13);
            this.labelStopWin.TabIndex = 12;
            this.labelStopWin.Text = "StopWin";
            // 
            // textBoxStopTime
            // 
            this.textBoxStopTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStopTime.ForeColor = System.Drawing.Color.Blue;
            this.textBoxStopTime.Location = new System.Drawing.Point(110, 112);
            this.textBoxStopTime.Name = "textBoxStopTime";
            this.textBoxStopTime.Size = new System.Drawing.Size(71, 20);
            this.textBoxStopTime.TabIndex = 11;
            this.textBoxStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxStopTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStopTime_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(191, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Minutes";
            // 
            // labelStopTime
            // 
            this.labelStopTime.AutoSize = true;
            this.labelStopTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStopTime.ForeColor = System.Drawing.Color.Blue;
            this.labelStopTime.Location = new System.Drawing.Point(6, 118);
            this.labelStopTime.Name = "labelStopTime";
            this.labelStopTime.Size = new System.Drawing.Size(60, 13);
            this.labelStopTime.TabIndex = 9;
            this.labelStopTime.Text = "StopTime";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(191, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Hands";
            // 
            // textBoxStopHand
            // 
            this.textBoxStopHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStopHand.Location = new System.Drawing.Point(110, 84);
            this.textBoxStopHand.Name = "textBoxStopHand";
            this.textBoxStopHand.Size = new System.Drawing.Size(71, 20);
            this.textBoxStopHand.TabIndex = 7;
            this.textBoxStopHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxStopHand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStopHand_KeyPress);
            // 
            // labelStophands
            // 
            this.labelStophands.AutoSize = true;
            this.labelStophands.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStophands.Location = new System.Drawing.Point(6, 90);
            this.labelStophands.Name = "labelStophands";
            this.labelStophands.Size = new System.Drawing.Size(69, 13);
            this.labelStophands.TabIndex = 6;
            this.labelStophands.Text = "StopHands";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(188, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "BBs";
            // 
            // textBoxStopLoss
            // 
            this.textBoxStopLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStopLoss.ForeColor = System.Drawing.Color.Red;
            this.textBoxStopLoss.Location = new System.Drawing.Point(110, 25);
            this.textBoxStopLoss.Name = "textBoxStopLoss";
            this.textBoxStopLoss.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxStopLoss.Size = new System.Drawing.Size(71, 20);
            this.textBoxStopLoss.TabIndex = 3;
            this.textBoxStopLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxStopLoss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStopLoss_KeyPress);
            // 
            // labelStoploss
            // 
            this.labelStoploss.AutoSize = true;
            this.labelStoploss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStoploss.ForeColor = System.Drawing.Color.Red;
            this.labelStoploss.Location = new System.Drawing.Point(6, 31);
            this.labelStoploss.Name = "labelStoploss";
            this.labelStoploss.Size = new System.Drawing.Size(59, 13);
            this.labelStoploss.TabIndex = 1;
            this.labelStoploss.Text = "StopLoss";
            // 
            // tabResumeSession
            // 
            this.tabResumeSession.Controls.Add(this.textBoxbb100);
            this.tabResumeSession.Controls.Add(this.labelbb100);
            this.tabResumeSession.Controls.Add(this.labelResumeSession);
            this.tabResumeSession.Controls.Add(this.textBoxHistoryBbsMax);
            this.tabResumeSession.Controls.Add(this.label24);
            this.tabResumeSession.Controls.Add(this.textBoxHistoryTime);
            this.tabResumeSession.Controls.Add(this.textBoxHistoryHands);
            this.tabResumeSession.Controls.Add(this.textBoxHistoryBbsloss);
            this.tabResumeSession.Controls.Add(this.label25);
            this.tabResumeSession.Controls.Add(this.label26);
            this.tabResumeSession.Controls.Add(this.label27);
            this.tabResumeSession.Controls.Add(this.labelHistoryMax);
            this.tabResumeSession.Controls.Add(this.textBoxBbsMax);
            this.tabResumeSession.Controls.Add(this.labelBbsMax);
            this.tabResumeSession.Controls.Add(this.textBoxRsTime);
            this.tabResumeSession.Controls.Add(this.textBoxRsHands);
            this.tabResumeSession.Controls.Add(this.textBoxRsBbs);
            this.tabResumeSession.Controls.Add(this.label17);
            this.tabResumeSession.Controls.Add(this.label16);
            this.tabResumeSession.Controls.Add(this.labelSessionBBs);
            this.tabResumeSession.Location = new System.Drawing.Point(4, 22);
            this.tabResumeSession.Name = "tabResumeSession";
            this.tabResumeSession.Size = new System.Drawing.Size(326, 343);
            this.tabResumeSession.TabIndex = 3;
            this.tabResumeSession.Text = "Resume Session";
            this.tabResumeSession.UseVisualStyleBackColor = true;
            // 
            // textBoxbb100
            // 
            this.textBoxbb100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxbb100.Location = new System.Drawing.Point(154, 80);
            this.textBoxbb100.Name = "textBoxbb100";
            this.textBoxbb100.Size = new System.Drawing.Size(70, 20);
            this.textBoxbb100.TabIndex = 19;
            this.textBoxbb100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelbb100
            // 
            this.labelbb100.AutoSize = true;
            this.labelbb100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbb100.Location = new System.Drawing.Point(92, 83);
            this.labelbb100.Name = "labelbb100";
            this.labelbb100.Size = new System.Drawing.Size(48, 13);
            this.labelbb100.TabIndex = 18;
            this.labelbb100.Text = "bb/100";
            // 
            // labelResumeSession
            // 
            this.labelResumeSession.AutoSize = true;
            this.labelResumeSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResumeSession.Location = new System.Drawing.Point(99, 23);
            this.labelResumeSession.Name = "labelResumeSession";
            this.labelResumeSession.Size = new System.Drawing.Size(125, 16);
            this.labelResumeSession.TabIndex = 17;
            this.labelResumeSession.Text = "Resume Session";
            // 
            // textBoxHistoryBbsMax
            // 
            this.textBoxHistoryBbsMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHistoryBbsMax.ForeColor = System.Drawing.Color.Green;
            this.textBoxHistoryBbsMax.Location = new System.Drawing.Point(154, 298);
            this.textBoxHistoryBbsMax.Name = "textBoxHistoryBbsMax";
            this.textBoxHistoryBbsMax.Size = new System.Drawing.Size(70, 20);
            this.textBoxHistoryBbsMax.TabIndex = 16;
            this.textBoxHistoryBbsMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Green;
            this.label24.Location = new System.Drawing.Point(92, 301);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 13);
            this.label24.TabIndex = 15;
            this.label24.Text = "BBs Win";
            // 
            // textBoxHistoryTime
            // 
            this.textBoxHistoryTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHistoryTime.ForeColor = System.Drawing.Color.Blue;
            this.textBoxHistoryTime.Location = new System.Drawing.Point(154, 272);
            this.textBoxHistoryTime.Name = "textBoxHistoryTime";
            this.textBoxHistoryTime.Size = new System.Drawing.Size(70, 20);
            this.textBoxHistoryTime.TabIndex = 14;
            this.textBoxHistoryTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxHistoryHands
            // 
            this.textBoxHistoryHands.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHistoryHands.Location = new System.Drawing.Point(154, 246);
            this.textBoxHistoryHands.Name = "textBoxHistoryHands";
            this.textBoxHistoryHands.Size = new System.Drawing.Size(70, 20);
            this.textBoxHistoryHands.TabIndex = 13;
            this.textBoxHistoryHands.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxHistoryBbsloss
            // 
            this.textBoxHistoryBbsloss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHistoryBbsloss.ForeColor = System.Drawing.Color.Red;
            this.textBoxHistoryBbsloss.Location = new System.Drawing.Point(154, 220);
            this.textBoxHistoryBbsloss.Name = "textBoxHistoryBbsloss";
            this.textBoxHistoryBbsloss.Size = new System.Drawing.Size(70, 20);
            this.textBoxHistoryBbsloss.TabIndex = 12;
            this.textBoxHistoryBbsloss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Blue;
            this.label25.Location = new System.Drawing.Point(92, 275);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(34, 13);
            this.label25.TabIndex = 11;
            this.label25.Text = "Time";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(92, 249);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 13);
            this.label26.TabIndex = 10;
            this.label26.Text = "Hands";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Red;
            this.label27.Location = new System.Drawing.Point(92, 223);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 13);
            this.label27.TabIndex = 9;
            this.label27.Text = "BBs Loss";
            // 
            // labelHistoryMax
            // 
            this.labelHistoryMax.AutoSize = true;
            this.labelHistoryMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHistoryMax.ForeColor = System.Drawing.Color.Magenta;
            this.labelHistoryMax.Location = new System.Drawing.Point(135, 191);
            this.labelHistoryMax.Name = "labelHistoryMax";
            this.labelHistoryMax.Size = new System.Drawing.Size(89, 16);
            this.labelHistoryMax.TabIndex = 8;
            this.labelHistoryMax.Text = "History Max";
            // 
            // textBoxBbsMax
            // 
            this.textBoxBbsMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBbsMax.Location = new System.Drawing.Point(154, 159);
            this.textBoxBbsMax.Name = "textBoxBbsMax";
            this.textBoxBbsMax.Size = new System.Drawing.Size(70, 20);
            this.textBoxBbsMax.TabIndex = 7;
            this.textBoxBbsMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelBbsMax
            // 
            this.labelBbsMax.AutoSize = true;
            this.labelBbsMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBbsMax.Location = new System.Drawing.Point(92, 162);
            this.labelBbsMax.Name = "labelBbsMax";
            this.labelBbsMax.Size = new System.Drawing.Size(56, 13);
            this.labelBbsMax.TabIndex = 6;
            this.labelBbsMax.Text = "BBs Max";
            // 
            // textBoxRsTime
            // 
            this.textBoxRsTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRsTime.ForeColor = System.Drawing.Color.Blue;
            this.textBoxRsTime.Location = new System.Drawing.Point(154, 133);
            this.textBoxRsTime.Name = "textBoxRsTime";
            this.textBoxRsTime.Size = new System.Drawing.Size(70, 20);
            this.textBoxRsTime.TabIndex = 5;
            this.textBoxRsTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxRsHands
            // 
            this.textBoxRsHands.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRsHands.Location = new System.Drawing.Point(154, 107);
            this.textBoxRsHands.Name = "textBoxRsHands";
            this.textBoxRsHands.Size = new System.Drawing.Size(70, 20);
            this.textBoxRsHands.TabIndex = 4;
            this.textBoxRsHands.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxRsBbs
            // 
            this.textBoxRsBbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRsBbs.Location = new System.Drawing.Point(154, 54);
            this.textBoxRsBbs.Name = "textBoxRsBbs";
            this.textBoxRsBbs.Size = new System.Drawing.Size(70, 20);
            this.textBoxRsBbs.TabIndex = 3;
            this.textBoxRsBbs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Blue;
            this.label17.Location = new System.Drawing.Point(92, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Time";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(92, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Hands";
            // 
            // labelSessionBBs
            // 
            this.labelSessionBBs.AutoSize = true;
            this.labelSessionBBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSessionBBs.Location = new System.Drawing.Point(92, 57);
            this.labelSessionBBs.Name = "labelSessionBBs";
            this.labelSessionBBs.Size = new System.Drawing.Size(29, 13);
            this.labelSessionBBs.TabIndex = 0;
            this.labelSessionBBs.Text = "BBs";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.linkLabelFeedback);
            this.tabPage2.Controls.Add(this.buttonDonate);
            this.tabPage2.Controls.Add(this.buttonStart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(326, 343);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Start";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabelFeedback
            // 
            this.linkLabelFeedback.AutoSize = true;
            this.linkLabelFeedback.Location = new System.Drawing.Point(151, 316);
            this.linkLabelFeedback.Name = "linkLabelFeedback";
            this.linkLabelFeedback.Size = new System.Drawing.Size(169, 13);
            this.linkLabelFeedback.TabIndex = 2;
            this.linkLabelFeedback.TabStop = true;
            this.linkLabelFeedback.Text = "Feedback: stoploss59@gmail.com";
            this.linkLabelFeedback.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFeedback_LinkClicked);
            // 
            // buttonDonate
            // 
            this.buttonDonate.Image = ((System.Drawing.Image)(resources.GetObject("buttonDonate.Image")));
            this.buttonDonate.Location = new System.Drawing.Point(92, 194);
            this.buttonDonate.Name = "buttonDonate";
            this.buttonDonate.Size = new System.Drawing.Size(143, 89);
            this.buttonDonate.TabIndex = 1;
            this.buttonDonate.UseVisualStyleBackColor = true;
            this.buttonDonate.Click += new System.EventHandler(this.buttonDonate_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(92, 37);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(143, 76);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // openFileDialogSound
            // 
            this.openFileDialogSound.FileName = "openFileDialogSound";
            this.openFileDialogSound.InitialDirectory = "c:";
            this.openFileDialogSound.Title = "Search Sound";
            // 
            // toolTipHelpText
            // 
            this.toolTipHelpText.AutomaticDelay = 100;
            this.toolTipHelpText.AutoPopDelay = 5000;
            this.toolTipHelpText.InitialDelay = 100;
            this.toolTipHelpText.ReshowDelay = 20;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 376);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "StopLoss";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.tabControlMain.ResumeLayout(false);
            this.tabDatabase.ResumeLayout(false);
            this.tabDatabase.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabResumeSession.ResumeLayout(false);
            this.tabResumeSession.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControlMain;
        public System.Windows.Forms.TabPage tabDatabase;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Label labelTitleDB;
        public System.Windows.Forms.Label labelPlayer;
        public System.Windows.Forms.TextBox textBoxPlayer;
        public System.Windows.Forms.TextBox textBoxServer;
        public System.Windows.Forms.Label labelServer;
        public System.Windows.Forms.Button buttonTestDb;
        public System.Windows.Forms.Label labePassword;
        public System.Windows.Forms.Label labelUserDb;
        public System.Windows.Forms.Label labelDb;
        public System.Windows.Forms.Label labelPort;
        public System.Windows.Forms.TextBox textBoxPass;
        public System.Windows.Forms.TextBox textBoxUser;
        public System.Windows.Forms.TextBox textBoxDb;
        public System.Windows.Forms.TextBox textBoxPort;
        public System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxPlayerID;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxStopHand;
        private System.Windows.Forms.Label labelStophands;
        private System.Windows.Forms.TextBox textBoxStopTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelStopTime;
        private System.Windows.Forms.TextBox textBoxStopWin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelStopWin;
        private System.Windows.Forms.OpenFileDialog openFileDialogSound;
        private System.Windows.Forms.CheckBox checkBoxHem2;
        private System.Windows.Forms.CheckBox checkBoxHem1;
        private System.Windows.Forms.TabPage tabResumeSession;
        private System.Windows.Forms.TextBox textBoxRsTime;
        private System.Windows.Forms.TextBox textBoxRsHands;
        private System.Windows.Forms.TextBox textBoxRsBbs;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label labelSessionBBs;
        private System.Windows.Forms.CheckBox checkBoxPt4;
        private System.Windows.Forms.Label labelAlertDb;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelResumeOnStop;
        private System.Windows.Forms.CheckBox checkBoxResumeSession;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolTip toolTipHelpText;
        private System.Windows.Forms.Label labelBbOver;
        private System.Windows.Forms.TextBox textBoxStopLossPeak;
        private System.Windows.Forms.Label labelStopLossPeak;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxStopLoss;
        private System.Windows.Forms.Label labelStoploss;
        private System.Windows.Forms.CheckBox checkBoxHideBbbs;
        private System.Windows.Forms.Label labelHideBbs;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBoxPeakOver;
        private System.Windows.Forms.Button buttonDonate;
        private System.Windows.Forms.Button buttonChoiceSounds;
        private System.Windows.Forms.TextBox textBoxBbsMax;
        private System.Windows.Forms.Label labelBbsMax;
        private System.Windows.Forms.CheckBox checkBoxCloseSkype;
        private System.Windows.Forms.Label labelCloseSkype;
        private System.Windows.Forms.LinkLabel linkLabelFeedback;
        private System.Windows.Forms.TextBox textBoxHistoryBbsMax;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxHistoryTime;
        private System.Windows.Forms.TextBox textBoxHistoryHands;
        private System.Windows.Forms.TextBox textBoxHistoryBbsloss;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label labelHistoryMax;
        private System.Windows.Forms.CheckBox checkBoxButtonSet;
        private System.Windows.Forms.Label labelActiveSet;
        private System.Windows.Forms.LinkLabel linkLabelHelp;
        private System.Windows.Forms.ComboBox comboBoxBRM;
        private System.Windows.Forms.Label labelBrm;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelResumeSession;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.LinkLabel linkLabelHelp2;
        private System.Windows.Forms.TextBox textBoxbb100;
        private System.Windows.Forms.Label labelbb100;
    }
}

