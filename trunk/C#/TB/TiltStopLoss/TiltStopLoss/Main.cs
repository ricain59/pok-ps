using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Npgsql;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
using StopLoss;

namespace TiltStopLoss
{
    public partial class Main : Form
    {
        private Db db = new Db();
        private Boolean alias = false;
        private Boolean start = true;
        private Boolean resumesession = false;
        private Double version = 1.44;
        private String urldownload = "http://bit.ly/1aSxGIA";
        private String urlxml = "https://dl.dropboxusercontent.com/u/24467236/versionstoploss.xml";
        
        public Main()
        {
            InitializeComponent();
            labelVersion.Text = "v"+version.ToString().Replace(',', '.');
            //aqui vou ver se existe update ou não
            checkupdate();            
            //depois disso volto ao soft caso diz que não
            loadconfig();
            start = false;
            db.getData(textBoxUser.Text, textBoxServer.Text, textBoxPort.Text, textBoxPass.Text, textBoxDb.Text, textBoxPlayer.Text);
            textBoxPlayer.Enabled = false;
            if (!textBoxServer.Text.Equals(""))
            {
                textBoxPlayer.Enabled = true;
                fillTextboxPlayer();
            }
        }

        /// <summary>
        /// Verifica se existe update ou não
        /// </summary>
        /// <returns></returns>
        private void checkupdate()
        {
            Double newversion = version;
            try
            {
                using (XmlReader reader = XmlReader.Create(urlxml))
                {
                    while (reader.Read())
                    {
                        // Only detect start elements.
                        if (reader.IsStartElement())
                        {
                            // Get element name and switch on it.
                            switch (reader.Name)
                            {
                                case "number":
                                    if (reader.Read())
                                    {
                                        newversion = Convert.ToDouble(reader.Value.Trim().ToString().Replace('.', ','));
                                    }
                                    break;
                            }
                        }
                    }
                }
                if (version < newversion)
                {
                    DialogResult dialogResult = MessageBox.Show("Actual version: " + version.ToString().Replace(',', '.') + "\r\nNew Version: " + newversion.ToString().Replace(',', '.') + "\r\nGo to download page?", "Update", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something
                        Process.Start(urldownload);
                    }
                }
            }
            catch (Exception e)
            {
                new Debug().LogMessage(e.ToString());
            }
        }

        private void buttonTestDb_Click(object sender, EventArgs e)
        {
            db.getData(textBoxUser.Text, textBoxServer.Text, textBoxPort.Text, textBoxPass.Text, textBoxDb.Text, textBoxPlayer.Text);
            String testconnect = db.testconnectDb();
            if (testconnect.Equals(""))
            {
                MessageBox.Show("Test connection OK.\r\n This windows is closed, open it for selected player.");
                this.Close();              
            }
            else
            {
                MessageBox.Show(testconnect);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Boolean stop = false;
            String con = db.connectDb();
            if (!con.Equals(""))
            {
                MessageBox.Show(con.ToString());
                stop = true;
            }
            //se dá erro a me ligar a DB não faço mais nada
            //aqui tenho de abrir a outra janela que vai ficar a funcar em paralela dessa
            try
            {
                if (!stop)
                {
                    int stoplosspeak = new Utils().stringtoInt32(textBoxStopLossPeak.Text);
                    int overpeak = new Utils().stringtoInt32(textBoxPeakOver.Text);
                    if (textBoxPlayer.Text.Equals("") || (stoplosspeak > 0 && overpeak == 0))
                    {
                        if (textBoxPlayer.Text.Equals(""))
                        {
                            MessageBox.Show("Fill player name please.");
                            tabControlMain.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("Fill peak over please.");
                            tabControlMain.SelectedIndex = 1;
                        }
                    }
                    else
                    {
                        this.Visible = false;
                        Stoploss sl;
                        List<Tuple<String, String>> playeralias;
                        if (checkBoxHem1.Checked || checkBoxHem2.Checked)
                        {
                            if (checkBoxHem1.Checked)//hem1
                            {
                                //ver se é um alias ou não
                                if (alias)
                                {
                                    playeralias = db.isAlias(textBoxPlayerID.Text);
                                }
                                else
                                {
                                    playeralias = new List<Tuple<String, String>>();
                                    playeralias.Add(Tuple.Create(textBoxPlayerID.Text, textBoxPlayer.Text));
                                    //sl = new Stoploss(this, textBoxPlayerID.Text, db, textBoxPlayer.Text, textBoxStopLoss.Text, textBoxStopHand.Text, textBoxStopTime.Text, textBoxStopWin.Text, 2);
                                }
                                sl = new Stoploss(this, playeralias, db, textBoxStopLoss.Text, textBoxStopHand.Text, textBoxStopTime.Text, textBoxStopWin.Text, textBoxStopLossPeak.Text, textBoxPeakOver.Text, checkBoxHideBbbs.Checked, 1);
                            }
                            else //hem2
                            {
                                //ver se é um alias ou não
                                if (alias)
                                {
                                    playeralias = db.isAlias(textBoxPlayerID.Text);
                                }
                                else
                                {
                                    playeralias = new List<Tuple<String, String>>();
                                    playeralias.Add(Tuple.Create(textBoxPlayerID.Text, textBoxPlayer.Text));
                                    //sl = new Stoploss(this, textBoxPlayerID.Text, db, textBoxPlayer.Text, textBoxStopLoss.Text, textBoxStopHand.Text, textBoxStopTime.Text, textBoxStopWin.Text, 2);
                                }
                                sl = new Stoploss(this, playeralias, db, textBoxStopLoss.Text, textBoxStopHand.Text, textBoxStopTime.Text, textBoxStopWin.Text, textBoxStopLossPeak.Text, textBoxPeakOver.Text, checkBoxHideBbbs.Checked, 2);
                            }
                        }
                        else //pt4
                        {
                            if (alias)
                            {
                                playeralias = db.isAliasPt4(textBoxPlayerID.Text);
                            }
                            else
                            {
                                playeralias = new List<Tuple<String, String>>();
                                playeralias.Add(Tuple.Create(textBoxPlayerID.Text, textBoxPlayer.Text));
                                //sl = new Stoploss(this, textBoxPlayerID.Text, db, textBoxPlayer.Text, textBoxStopLoss.Text, textBoxStopHand.Text, textBoxStopTime.Text, textBoxStopWin.Text, 2);
                            }
                            sl = new Stoploss(this, playeralias, db, textBoxStopLoss.Text, textBoxStopHand.Text, textBoxStopTime.Text, textBoxStopWin.Text, textBoxStopLossPeak.Text, textBoxPeakOver.Text, checkBoxHideBbbs.Checked, 4);
                        }
                        sl.Show();                        
                    }
                }
            }
            catch (Exception ex)
            {
                new Debug().LogMessage(ex.ToString());
            }
        }

        #region Save and load config

        /// <summary>
        /// Permite guardar os dados inseridos no software
        /// </summary>
        private void loadconfig()
        {
            String path = Directory.GetCurrentDirectory();
            String filepath = path + "/config.txt";
            if (File.Exists(filepath))
            {
                string line;
                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader(filepath);
                while ((line = file.ReadLine()) != null)
                {
                    String[] array = line.Split('=');
                    configframe(array);
                }
                file.Close();
            }
        }

        private void configframe(String[] line)
        {
            switch (line[0])
            {
                case "Location":
                    String[] loc = line[1].Split(',');
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(int.Parse(loc[0]), int.Parse(loc[1]));
                    break;
                case "Player":
                    textBoxPlayer.Text = line[1].ToString();
                    break;
                case "Server":
                    textBoxServer.Text = line[1].ToString();
                    break;
                case "Port":
                    textBoxPort.Text = line[1].ToString();
                    break;
                case "Database":
                    textBoxDb.Text = line[1].ToString();
                    break;
                case "UserDb":
                    textBoxUser.Text = line[1].ToString();
                    break;
                case "PasswordDB":
                    textBoxPass.Text = line[1].ToString();
                    break;
                case "PlayerID":
                    textBoxPlayerID.Text = line[1].ToString();
                    break;
                case "Stoploss":
                    textBoxStopLoss.Text = line[1].ToString();
                    break;
                case "StopHands":
                    textBoxStopHand.Text = line[1].ToString();
                    break;
                case "StopTime":
                    textBoxStopTime.Text = line[1].ToString();
                    break;
                case "StopWin":
                    textBoxStopWin.Text = line[1].ToString();
                    break;
                case "StopLossPeakOver":
                    textBoxPeakOver.Text = line[1].ToString();
                    break;
                case "StopLossPeak":
                    textBoxStopLossPeak.Text = line[1].ToString();
                    break;
                case "Hem1":
                    if(line[1].ToString().Equals("True"))
                    {
                        checkBoxHem1.Checked = true;
                    }else{
                        checkBoxHem1.Checked = false;
                    }
                    break;
                case "Hem2":
                    if (line[1].ToString().Equals("True"))
                    {
                        checkBoxHem2.Checked = true;
                    }
                    else
                    {
                        checkBoxHem2.Checked = false;
                    }
                    break;
                case "Pt4":
                    if (line[1].ToString().Equals("True"))
                    {
                        checkBoxPt4.Checked = true;
                    }
                    else
                    {
                        checkBoxPt4.Checked = false;
                    }
                    break;
                case "Alias":
                    if (line[1].ToString().Equals("True"))
                    {
                        alias = true;
                    }
                    else
                    {
                        alias = false;
                    }
                    break;
                case "Resumesession":
                    if (line[1].ToString().Equals("True"))
                    {
                        resumesession = true;
                        checkBoxResumeSession.Checked = true;
                    }
                    else
                    {
                        resumesession = false;
                        checkBoxResumeSession.Checked = false;
                    }
                    break;
                case "Hidebbs":
                    if (line[1].ToString().Equals("True"))
                    {
                        checkBoxHideBbbs.Checked = true;
                    }
                    else
                    {
                        checkBoxHideBbbs.Checked = false;
                    }
                    break;
                default:
                    break;
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            String location = this.Location.X.ToString() + ',' + this.Location.Y.ToString();
            String path = Directory.GetCurrentDirectory();
            StreamWriter w = new StreamWriter(path + "/config.txt", false);
            w.Write("Location=" + location);
            w.WriteLine();
            w.Write("Player=" + textBoxPlayer.Text.ToString());
            w.WriteLine();
            w.Write("Server=" + textBoxServer.Text.ToString());
            w.WriteLine();
            w.Write("Port=" + textBoxPort.Text.ToString());
            w.WriteLine();
            w.Write("Database=" + textBoxDb.Text.ToString());
            w.WriteLine();
            w.Write("UserDb=" + textBoxUser.Text.ToString());
            w.WriteLine();
            w.Write("PasswordDB=" + textBoxPass.Text.ToString());
            w.WriteLine();
            w.Write("PlayerID=" + textBoxPlayerID.Text.ToString());
            w.WriteLine();
            w.Write("Stoploss=" + textBoxStopLoss.Text.ToString());
            w.WriteLine();
            w.Write("StopHands=" + textBoxStopHand.Text.ToString());
            w.WriteLine();
            w.Write("StopTime=" + textBoxStopTime.Text.ToString());
            w.WriteLine();
            w.Write("StopWin=" + textBoxStopWin.Text.ToString());
            w.WriteLine();
            w.Write("Hem1=" + checkBoxHem1.Checked.ToString());
            w.WriteLine();
            w.Write("Hem2=" + checkBoxHem2.Checked.ToString());
            w.WriteLine();
            w.Write("Alias=" + alias.ToString());
            w.WriteLine();
            w.Write("Pt4=" + checkBoxPt4.Checked.ToString());
            w.WriteLine();
            w.Write("Resumesession=" + checkBoxResumeSession.Checked.ToString());
            w.WriteLine();
            w.Write("StopLossPeak=" + textBoxStopLossPeak.Text.ToString());
            w.WriteLine();
            w.Write("Hidebbs=" + checkBoxHideBbbs.Checked.ToString());
            w.WriteLine();
            w.Write("StopLossPeakOver=" + textBoxPeakOver.Text.ToString());
            w.WriteLine();            
            w.Close();
        }

        #endregion

        /// <summary>
        /// Vou procurar o id do nome inserido no textbox do player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPlayer_Leave(object sender, EventArgs e)
        {
            if (!textBoxPlayer.Text.Equals(""))
            {
                string query = "";
                if (checkBoxHem1.Checked || checkBoxHem2.Checked)
                {
                    if (checkBoxHem1.Checked)//hem1
                    {
                        query = "select player_id, site_id from players where playername = '" + textBoxPlayer.Text.ToString() + "'";
                    }
                    else
                    {
                        query = "select player_id, pokersite_id from players where playername = '" + textBoxPlayer.Text.ToString() + "'";
                    }

                    db.connectDb();
                    NpgsqlCommand command = new NpgsqlCommand(query, db.conn);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        textBoxPlayerID.Text = dr[0].ToString();
                        if (dr[1].ToString().Equals("-1"))
                        {
                            alias = true;
                        }
                        else
                        {
                            alias = false;
                        }
                    }
                    dr.Close();
                    db.closeconDb();
                }
                else //pt4
                {
                    query = "select id_player, player_name, id_player_alias from player where player_name = '" + textBoxPlayer.Text.ToString() + "'";
                    db.connectDb();
                    NpgsqlCommand command = new NpgsqlCommand(query, db.conn);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    String id_alias = "";
                    while (dr.Read())
                    {
                        textBoxPlayerID.Text = dr[0].ToString();
                        id_alias = dr[0].ToString();
                    }
                    dr.Close();
                    query = "select id_player, player_name, id_player_alias from player where id_player_alias = " + id_alias;
                    command = new NpgsqlCommand(query, db.conn);
                    dr = command.ExecuteReader();
                    alias = false;
                    while (dr.Read())
                    {
                        alias = true;
                    }
                    dr.Close();
                    db.closeconDb();
                }
            }
        }

        /// <summary>
        /// Se quando estamos a jogar alteramos os valores inseridos anteriomente
        /// Altero tambem aqui
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="loss"></param>
        /// <param name="time"></param>
        public void setNewValue(String hand, String loss, String time, String win, String losspeak)
        {
            textBoxStopLoss.Text = loss;
            textBoxStopHand.Text = hand;
            textBoxStopTime.Text = time;
            textBoxStopWin.Text = win;
            textBoxStopLossPeak.Text = losspeak;            
        }

        /// <summary>
        /// Ressume da sessão
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="loss"></param>
        /// <param name="time"></param>
        public void setValueSession(String hand, String time, Double bbs)
        {
            if (resumesession)
            {
                textBoxRsHands.Text = hand;
                textBoxRsTime.Text = time;
                if (bbs < 0)
                {
                    textBoxRsBbs.Text = bbs.ToString();
                    textBoxRsBbs.ForeColor = Color.Red;
                    labelSessionBBs.ForeColor = Color.Red;
                }
                else
                {
                    textBoxRsBbs.Text = bbs.ToString();
                    textBoxRsBbs.ForeColor = Color.Green;
                    labelSessionBBs.ForeColor = Color.Green;
                }
                tabControlMain.SelectedIndex = 2;
            }
        }

        /// <summary>
        /// Fill textbox player from databse
        /// </summary>
        private void fillTextboxPlayer()
        {
            
            try
            {
                textBoxPlayer.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBoxPlayer.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                string query = "";
                db.connectDb();
                if (checkBoxHem1.Checked || checkBoxHem2.Checked)
                {
                    query = "select player_id, playername from players ";
                }
                else
                {
                    query = "select id_player, player_name from player";
                }
                NpgsqlCommand command = new NpgsqlCommand(query, db.conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    col.Add(dr[1].ToString());
                }
                dr.Close();
                textBoxPlayer.AutoCompleteCustomSource = col;
                db.closeconDb();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception==" + ex);
            }
            
        }

        #region tab conf stop

        private void textBoxStopLoss_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Utils().onlynumeric(e);
        }

        private void textBoxStopHand_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Utils().onlynumeric(e);
        }

        private void textBoxStopTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Utils().onlynumeric(e);
        }

        private void textBoxStopWin_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Utils().onlynumeric(e);
        }

        private void textBoxStopLossPeak_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Utils().onlynumeric(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Utils().onlynumeric(e);
        }

        private void checkBoxResumeSession_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxResumeSession.Checked)
            {
                resumesession = true;
            }
            else
            {
                resumesession = false;
            }            
        }

        #endregion

        #region checkbox tracker

        /// <summary>
        /// Only one DB checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxHem1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHem1.Checked)
            {
                checkBoxHem2.Checked = false;
                checkBoxPt4.Checked = false;
                if (!start)
                {
                    labelAlertDb.Text = "Attention DB name";
                    labelAlertDb.Visible = true;
                }
            }
        }

        /// <summary>
        /// Only one DB checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxHem2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHem2.Checked)
            {
                checkBoxHem1.Checked = false;
                checkBoxPt4.Checked = false;
                if (!start)
                {
                    labelAlertDb.Text = "Attention DB name";
                    labelAlertDb.Visible = true;
                }
            }
        }

        /// <summary>
        /// Only one DB checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxPt4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPt4.Checked)
            {
                checkBoxHem1.Checked = false;
                checkBoxHem2.Checked = false;
                if (!start)
                {
                    labelAlertDb.Text = "Attention DB name";
                    labelAlertDb.Visible = true;
                }
            }
        }

        #endregion

        #region Help mouse over image

        private void pictureBoxPlayer_MouseHover(object sender, EventArgs e)
        {
            toolTipHelpText.SetToolTip(this.pictureBoxPlayer, "First fill database and after software close, re-open and fill this");
        }

        private void pictureBoxTracker_MouseHover(object sender, EventArgs e)
        {
            toolTipHelpText.SetToolTip(this.pictureBoxTracker, "Choose your tracker");
        }

        private void pictureBoxServer_MouseHover(object sender, EventArgs e)
        {
            toolTipHelpText.SetToolTip(this.pictureBoxServer, "Default: 127.0.0.1");
        }

        private void pictureBoxPort_MouseHover(object sender, EventArgs e)
        {
            toolTipHelpText.SetToolTip(this.pictureBoxPort, "Default: 5432");
        }

        private void pictureBoxDatabase_MouseHover(object sender, EventArgs e)
        {
            toolTipHelpText.SetToolTip(this.pictureBoxDatabase, "Name Database Tracker (click on database on tracker)");
        }

        private void pictureBoxUserDb_MouseHover(object sender, EventArgs e)
        {
            toolTipHelpText.SetToolTip(this.pictureBoxUserDb, "Default: postgres");
        }

        private void pictureBoxPassword_MouseHover(object sender, EventArgs e)
        {
            toolTipHelpText.SetToolTip(this.pictureBoxPassword, "Default: postgrespass or dbpass");
        }

        private void pictureBoxResumeSession_MouseHover(object sender, EventArgs e)
        {
            toolTipHelpText.SetToolTip(this.pictureBoxResumeSession, "If checked resume session on stop");
        }

        private void pictureBoxLossPeak_MouseHover(object sender, EventArgs e)
        {
            toolTipHelpText.SetToolTip(this.pictureBoxLossPeak, "Difference between max win session and bb actual.\r\nOnly if peak session >= over.\r\nIf peak defined, over also");
        }

        private void pictureBoxHideBbbs_MouseHover(object sender, EventArgs e)
        {
            toolTipHelpText.SetToolTip(this.pictureBoxHideBbbs, "If checked, not show BBs on mouse over");
        }

        #endregion

        /// <summary>
        /// Code for donate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDonate_Click(object sender, EventArgs e)
        {
            FormDonate fd = new FormDonate();
            fd.Show();
        }

               
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    openFileDialogSound.Filter = "Sound Wave|*.wav";
        //    openFileDialogSound.ShowDialog();
        //    textBoxSound.Text = openFileDialogSound.FileName;
        //    //comment l'envoyer pour la faire sonner?
        //    //List<Tuple<String, int>> list;
        //    //list.Add(Tuple.Create(table, 0));
        //    //ou pelo um array não sei.
        //}  
        
    }
}
