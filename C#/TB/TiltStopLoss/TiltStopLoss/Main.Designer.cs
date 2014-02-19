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
            this.pictureBoxTracker = new System.Windows.Forms.PictureBox();
            this.pictureBoxPassword = new System.Windows.Forms.PictureBox();
            this.pictureBoxUserDb = new System.Windows.Forms.PictureBox();
            this.pictureBoxDatabase = new System.Windows.Forms.PictureBox();
            this.pictureBoxPort = new System.Windows.Forms.PictureBox();
            this.pictureBoxServer = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlayer = new System.Windows.Forms.PictureBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelAlertDb = new System.Windows.Forms.Label();
            this.checkBoxPt4 = new System.Windows.Forms.CheckBox();
            this.checkBoxHem2 = new System.Windows.Forms.CheckBox();
            this.checkBoxHem1 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayerID = new System.Windows.Forms.TextBox();
            this.buttonTestDb = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxDb = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPlayer = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBoxResumeSession = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxResumeSession = new System.Windows.Forms.CheckBox();
            this.textBoxStopWin = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxStopTime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxStopHand = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabResumeSession = new System.Windows.Forms.TabPage();
            this.textBoxRsTime = new System.Windows.Forms.TextBox();
            this.textBoxRsHands = new System.Windows.Forms.TextBox();
            this.textBoxRsBbs = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labelSessionBBs = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonStart = new System.Windows.Forms.Button();
            this.openFileDialogSound = new System.Windows.Forms.OpenFileDialog();
            this.toolTipHelpText = new System.Windows.Forms.ToolTip(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxStopLoss = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxStopLossPeak = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.pictureBoxLossPeak = new System.Windows.Forms.PictureBox();
            this.tabControlMain.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTracker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserDb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResumeSession)).BeginInit();
            this.tabResumeSession.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLossPeak)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabDatabase);
            this.tabControlMain.Controls.Add(this.tabPage3);
            this.tabControlMain.Controls.Add(this.tabResumeSession);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(320, 318);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabDatabase
            // 
            this.tabDatabase.Controls.Add(this.pictureBoxTracker);
            this.tabDatabase.Controls.Add(this.pictureBoxPassword);
            this.tabDatabase.Controls.Add(this.pictureBoxUserDb);
            this.tabDatabase.Controls.Add(this.pictureBoxDatabase);
            this.tabDatabase.Controls.Add(this.pictureBoxPort);
            this.tabDatabase.Controls.Add(this.pictureBoxServer);
            this.tabDatabase.Controls.Add(this.pictureBoxPlayer);
            this.tabDatabase.Controls.Add(this.labelVersion);
            this.tabDatabase.Controls.Add(this.labelAlertDb);
            this.tabDatabase.Controls.Add(this.checkBoxPt4);
            this.tabDatabase.Controls.Add(this.checkBoxHem2);
            this.tabDatabase.Controls.Add(this.checkBoxHem1);
            this.tabDatabase.Controls.Add(this.textBoxPlayerID);
            this.tabDatabase.Controls.Add(this.buttonTestDb);
            this.tabDatabase.Controls.Add(this.label6);
            this.tabDatabase.Controls.Add(this.label5);
            this.tabDatabase.Controls.Add(this.label4);
            this.tabDatabase.Controls.Add(this.labelPort);
            this.tabDatabase.Controls.Add(this.textBoxPass);
            this.tabDatabase.Controls.Add(this.textBoxUser);
            this.tabDatabase.Controls.Add(this.textBoxDb);
            this.tabDatabase.Controls.Add(this.textBoxPort);
            this.tabDatabase.Controls.Add(this.textBoxServer);
            this.tabDatabase.Controls.Add(this.label3);
            this.tabDatabase.Controls.Add(this.label2);
            this.tabDatabase.Controls.Add(this.label1);
            this.tabDatabase.Controls.Add(this.textBoxPlayer);
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(312, 292);
            this.tabDatabase.TabIndex = 0;
            this.tabDatabase.Text = "Database";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // pictureBoxTracker
            // 
            this.pictureBoxTracker.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTracker.Image")));
            this.pictureBoxTracker.Location = new System.Drawing.Point(280, 83);
            this.pictureBoxTracker.Name = "pictureBoxTracker";
            this.pictureBoxTracker.Size = new System.Drawing.Size(26, 20);
            this.pictureBoxTracker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTracker.TabIndex = 28;
            this.pictureBoxTracker.TabStop = false;
            this.pictureBoxTracker.MouseHover += new System.EventHandler(this.pictureBoxTracker_MouseHover);
            // 
            // pictureBoxPassword
            // 
            this.pictureBoxPassword.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPassword.Image")));
            this.pictureBoxPassword.Location = new System.Drawing.Point(280, 222);
            this.pictureBoxPassword.Name = "pictureBoxPassword";
            this.pictureBoxPassword.Size = new System.Drawing.Size(26, 20);
            this.pictureBoxPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPassword.TabIndex = 27;
            this.pictureBoxPassword.TabStop = false;
            this.pictureBoxPassword.MouseHover += new System.EventHandler(this.pictureBoxPassword_MouseHover);
            // 
            // pictureBoxUserDb
            // 
            this.pictureBoxUserDb.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUserDb.Image")));
            this.pictureBoxUserDb.Location = new System.Drawing.Point(280, 196);
            this.pictureBoxUserDb.Name = "pictureBoxUserDb";
            this.pictureBoxUserDb.Size = new System.Drawing.Size(26, 20);
            this.pictureBoxUserDb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUserDb.TabIndex = 26;
            this.pictureBoxUserDb.TabStop = false;
            this.pictureBoxUserDb.MouseHover += new System.EventHandler(this.pictureBoxUserDb_MouseHover);
            // 
            // pictureBoxDatabase
            // 
            this.pictureBoxDatabase.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDatabase.Image")));
            this.pictureBoxDatabase.Location = new System.Drawing.Point(280, 169);
            this.pictureBoxDatabase.Name = "pictureBoxDatabase";
            this.pictureBoxDatabase.Size = new System.Drawing.Size(26, 20);
            this.pictureBoxDatabase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDatabase.TabIndex = 25;
            this.pictureBoxDatabase.TabStop = false;
            this.pictureBoxDatabase.MouseHover += new System.EventHandler(this.pictureBoxDatabase_MouseHover);
            // 
            // pictureBoxPort
            // 
            this.pictureBoxPort.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPort.Image")));
            this.pictureBoxPort.Location = new System.Drawing.Point(280, 141);
            this.pictureBoxPort.Name = "pictureBoxPort";
            this.pictureBoxPort.Size = new System.Drawing.Size(26, 20);
            this.pictureBoxPort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPort.TabIndex = 24;
            this.pictureBoxPort.TabStop = false;
            this.pictureBoxPort.MouseHover += new System.EventHandler(this.pictureBoxPort_MouseHover);
            // 
            // pictureBoxServer
            // 
            this.pictureBoxServer.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxServer.Image")));
            this.pictureBoxServer.Location = new System.Drawing.Point(280, 115);
            this.pictureBoxServer.Name = "pictureBoxServer";
            this.pictureBoxServer.Size = new System.Drawing.Size(26, 20);
            this.pictureBoxServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxServer.TabIndex = 23;
            this.pictureBoxServer.TabStop = false;
            this.pictureBoxServer.MouseHover += new System.EventHandler(this.pictureBoxServer_MouseHover);
            // 
            // pictureBoxPlayer
            // 
            this.pictureBoxPlayer.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPlayer.Image")));
            this.pictureBoxPlayer.Location = new System.Drawing.Point(280, 22);
            this.pictureBoxPlayer.Name = "pictureBoxPlayer";
            this.pictureBoxPlayer.Size = new System.Drawing.Size(26, 20);
            this.pictureBoxPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPlayer.TabIndex = 22;
            this.pictureBoxPlayer.TabStop = false;
            this.pictureBoxPlayer.MouseHover += new System.EventHandler(this.pictureBoxPlayer_MouseHover);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(269, 278);
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
            this.labelAlertDb.Location = new System.Drawing.Point(183, 86);
            this.labelAlertDb.Name = "labelAlertDb";
            this.labelAlertDb.Size = new System.Drawing.Size(22, 13);
            this.labelAlertDb.TabIndex = 20;
            this.labelAlertDb.Text = "     ";
            this.labelAlertDb.Visible = false;
            // 
            // checkBoxPt4
            // 
            this.checkBoxPt4.AutoSize = true;
            this.checkBoxPt4.Location = new System.Drawing.Point(142, 86);
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
            this.checkBoxHem2.Location = new System.Drawing.Point(80, 86);
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
            this.checkBoxHem1.Location = new System.Drawing.Point(19, 85);
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
            this.textBoxPlayerID.Location = new System.Drawing.Point(88, 22);
            this.textBoxPlayerID.Name = "textBoxPlayerID";
            this.textBoxPlayerID.Size = new System.Drawing.Size(51, 20);
            this.textBoxPlayerID.TabIndex = 15;
            // 
            // buttonTestDb
            // 
            this.buttonTestDb.Location = new System.Drawing.Point(141, 249);
            this.buttonTestDb.Name = "buttonTestDb";
            this.buttonTestDb.Size = new System.Drawing.Size(75, 23);
            this.buttonTestDb.TabIndex = 13;
            this.buttonTestDb.Text = "Test";
            this.buttonTestDb.UseVisualStyleBackColor = true;
            this.buttonTestDb.Click += new System.EventHandler(this.buttonTestDb_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "UserDb";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Database";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(19, 148);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(26, 13);
            this.labelPort.TabIndex = 9;
            this.labelPort.Text = "Port";
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(88, 223);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(189, 20);
            this.textBoxPass.TabIndex = 8;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(88, 196);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(189, 20);
            this.textBoxUser.TabIndex = 7;
            // 
            // textBoxDb
            // 
            this.textBoxDb.Location = new System.Drawing.Point(88, 169);
            this.textBoxDb.Name = "textBoxDb";
            this.textBoxDb.Size = new System.Drawing.Size(189, 20);
            this.textBoxDb.TabIndex = 6;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(88, 142);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(189, 20);
            this.textBoxPort.TabIndex = 5;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(88, 115);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(189, 20);
            this.textBoxServer.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database Config";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player";
            // 
            // textBoxPlayer
            // 
            this.textBoxPlayer.Location = new System.Drawing.Point(145, 22);
            this.textBoxPlayer.Name = "textBoxPlayer";
            this.textBoxPlayer.Size = new System.Drawing.Size(132, 20);
            this.textBoxPlayer.TabIndex = 0;
            this.textBoxPlayer.Leave += new System.EventHandler(this.textBoxPlayer_Leave);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pictureBoxLossPeak);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.textBoxStopLossPeak);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.pictureBoxResumeSession);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.checkBoxResumeSession);
            this.tabPage3.Controls.Add(this.textBoxStopWin);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.textBoxStopTime);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.textBoxStopHand);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.textBoxStopLoss);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(312, 292);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Conf. Stop";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBoxResumeSession
            // 
            this.pictureBoxResumeSession.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxResumeSession.Image")));
            this.pictureBoxResumeSession.Location = new System.Drawing.Point(283, 181);
            this.pictureBoxResumeSession.Name = "pictureBoxResumeSession";
            this.pictureBoxResumeSession.Size = new System.Drawing.Size(26, 20);
            this.pictureBoxResumeSession.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxResumeSession.TabIndex = 23;
            this.pictureBoxResumeSession.TabStop = false;
            this.pictureBoxResumeSession.MouseHover += new System.EventHandler(this.pictureBoxResumeSession_MouseHover);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Resume on Stop";
            // 
            // checkBoxResumeSession
            // 
            this.checkBoxResumeSession.AutoSize = true;
            this.checkBoxResumeSession.Location = new System.Drawing.Point(166, 187);
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
            this.textBoxStopWin.Location = new System.Drawing.Point(110, 153);
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
            this.label14.Location = new System.Drawing.Point(191, 160);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "BBs";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Green;
            this.label15.Location = new System.Drawing.Point(21, 160);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "StopWin";
            // 
            // textBoxStopTime
            // 
            this.textBoxStopTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStopTime.ForeColor = System.Drawing.Color.Blue;
            this.textBoxStopTime.Location = new System.Drawing.Point(110, 121);
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
            this.label13.Location = new System.Drawing.Point(191, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Minutes";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(21, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "StopTime";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "StopHands";
            // 
            // tabResumeSession
            // 
            this.tabResumeSession.Controls.Add(this.textBoxRsTime);
            this.tabResumeSession.Controls.Add(this.textBoxRsHands);
            this.tabResumeSession.Controls.Add(this.textBoxRsBbs);
            this.tabResumeSession.Controls.Add(this.label17);
            this.tabResumeSession.Controls.Add(this.label16);
            this.tabResumeSession.Controls.Add(this.labelSessionBBs);
            this.tabResumeSession.Location = new System.Drawing.Point(4, 22);
            this.tabResumeSession.Name = "tabResumeSession";
            this.tabResumeSession.Size = new System.Drawing.Size(312, 292);
            this.tabResumeSession.TabIndex = 3;
            this.tabResumeSession.Text = "Resume Session";
            this.tabResumeSession.UseVisualStyleBackColor = true;
            // 
            // textBoxRsTime
            // 
            this.textBoxRsTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRsTime.ForeColor = System.Drawing.Color.Blue;
            this.textBoxRsTime.Location = new System.Drawing.Point(81, 83);
            this.textBoxRsTime.Name = "textBoxRsTime";
            this.textBoxRsTime.Size = new System.Drawing.Size(70, 20);
            this.textBoxRsTime.TabIndex = 5;
            this.textBoxRsTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxRsHands
            // 
            this.textBoxRsHands.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRsHands.Location = new System.Drawing.Point(81, 52);
            this.textBoxRsHands.Name = "textBoxRsHands";
            this.textBoxRsHands.Size = new System.Drawing.Size(70, 20);
            this.textBoxRsHands.TabIndex = 4;
            this.textBoxRsHands.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxRsBbs
            // 
            this.textBoxRsBbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRsBbs.Location = new System.Drawing.Point(81, 20);
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
            this.label17.Location = new System.Drawing.Point(19, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Time";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(19, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Hands";
            // 
            // labelSessionBBs
            // 
            this.labelSessionBBs.AutoSize = true;
            this.labelSessionBBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSessionBBs.Location = new System.Drawing.Point(19, 23);
            this.labelSessionBBs.Name = "labelSessionBBs";
            this.labelSessionBBs.Size = new System.Drawing.Size(29, 13);
            this.labelSessionBBs.TabIndex = 0;
            this.labelSessionBBs.Text = "BBs";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonStart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(312, 292);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Start";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(97, 108);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(117, 59);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(21, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "StopLoss";
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
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(188, 61);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 13);
            this.label18.TabIndex = 26;
            this.label18.Text = "BBs";
            // 
            // textBoxStopLossPeak
            // 
            this.textBoxStopLossPeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStopLossPeak.ForeColor = System.Drawing.Color.Red;
            this.textBoxStopLossPeak.Location = new System.Drawing.Point(110, 54);
            this.textBoxStopLossPeak.Name = "textBoxStopLossPeak";
            this.textBoxStopLossPeak.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxStopLossPeak.Size = new System.Drawing.Size(71, 20);
            this.textBoxStopLossPeak.TabIndex = 25;
            this.textBoxStopLossPeak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxStopLossPeak.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStopLossPeak_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(21, 61);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 13);
            this.label19.TabIndex = 24;
            this.label19.Text = "StopLossPeak";
            // 
            // pictureBoxLossPeak
            // 
            this.pictureBoxLossPeak.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLossPeak.Image")));
            this.pictureBoxLossPeak.Location = new System.Drawing.Point(283, 54);
            this.pictureBoxLossPeak.Name = "pictureBoxLossPeak";
            this.pictureBoxLossPeak.Size = new System.Drawing.Size(26, 20);
            this.pictureBoxLossPeak.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLossPeak.TabIndex = 27;
            this.pictureBoxLossPeak.TabStop = false;
            this.pictureBoxLossPeak.MouseHover += new System.EventHandler(this.pictureBoxLossPeak_MouseHover);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 334);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Stop Loss";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.tabControlMain.ResumeLayout(false);
            this.tabDatabase.ResumeLayout(false);
            this.tabDatabase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTracker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserDb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResumeSession)).EndInit();
            this.tabResumeSession.ResumeLayout(false);
            this.tabResumeSession.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLossPeak)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControlMain;
        public System.Windows.Forms.TabPage tabDatabase;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxPlayer;
        public System.Windows.Forms.TextBox textBoxServer;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button buttonTestDb;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxStopTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxStopWin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxResumeSession;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.PictureBox pictureBoxPlayer;
        private System.Windows.Forms.PictureBox pictureBoxPassword;
        private System.Windows.Forms.PictureBox pictureBoxUserDb;
        private System.Windows.Forms.PictureBox pictureBoxDatabase;
        private System.Windows.Forms.PictureBox pictureBoxPort;
        private System.Windows.Forms.PictureBox pictureBoxServer;
        private System.Windows.Forms.PictureBox pictureBoxTracker;
        private System.Windows.Forms.ToolTip toolTipHelpText;
        private System.Windows.Forms.PictureBox pictureBoxResumeSession;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxStopLossPeak;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxStopLoss;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBoxLossPeak;
    }
}

