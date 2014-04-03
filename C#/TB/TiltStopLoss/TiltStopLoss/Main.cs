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
        private Double version = 1.63;
        private String urldownload = "http://bit.ly/1aSxGIA";
        private String urlxml = "https://dl.dropboxusercontent.com/u/24467236/versionstoploss.xml";
        //sounds
        private String soundloss = "alarm.wav";
        private String soundtime = "alarm.wav";
        private String soundwin = "alarm.wav";
        private String soundhands = "alarm.wav";
        private String soundinternediatewin = "ring.wav";
        private String soundinternediateloss = "alarm.wav";
        //history value
        private Double histbbsloss = 0;
        private Int32 histhands = 0;
        private Int32 histtime = 0;
        private Double histbbsmax = 0;
        private Boolean repeat = true;
        //mouse
        private String help;
        
        public Main()
        {
            InitializeComponent();
            labelVersion.Text = "v" + version.ToString().Replace(',', '.');
            //como mudei os sound elimino onde estava o original inicialmente
            new Utils().deleteSound();
            new Utils().changeFileConfig();
            //aqui vou ver se existe update ou não
            checkupdate();
            //por defeito a combobox no NO
            comboBoxBRM.SelectedIndex = 0;
            comboBoxLanguage.SelectedIndex = 0;
            comboBoxSnoozeMinute.SelectedIndex = 0;
            comboBoxSnoozeMinute.Enabled = false;
            //depois disso volto ao soft caso diz que não
            loadconfig();
            //abro no separador conf stop se já foi configurado a DB
            if (!textBoxPlayer.Text.Equals(""))
            {
                tabControlMain.SelectedIndex = 1;
            }
            //o resto
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
            String log = "";
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
                                case "log":
                                    if (reader.Read())
                                    {
                                        log += reader.Value.Trim().ToString()+ "\r\n";
                                    }
                                    break;
                            }
                        }
                    }
                }
                if (version < newversion)
                {
                    DialogResult dialogResult = MessageBox.Show("Actual version: " + version.ToString().Replace(',', '.') + "\r\nNew Version: " + newversion.ToString().Replace(',', '.') + "\r\n\r\nNew:\r\n"+ log +"\r\nGo to download page?", "Update", MessageBoxButtons.YesNo);
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
            if (textBoxDb.Text.Equals(""))
            {
                MessageBox.Show("Fill Database please.");
            }
            else
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
            Double intwin = new Utils().stringtoDouble(textBoxStopWinIntermediate.Text);
            if (intwin != 0 && intwin >= new Utils().stringtoDouble(textBoxStopWin.Text))
            {
                if (comboBoxLanguage.SelectedIndex == 0)
                {
                    MessageBox.Show("Stopwin intermediate don't superior at stopwin");
                }
                if (comboBoxLanguage.SelectedIndex == 1)
                {
                    MessageBox.Show("Stopgain intermédiaire ne peux pas être supérieur a stopwin");
                }
                if (comboBoxLanguage.SelectedIndex == 2)
                {
                    MessageBox.Show("Stopganhos intermédios não pode ser superior a stopganhos");
                }                
                stop = true;            
            }
            double intloss = new Utils().stringtoDouble(textBoxStopLossIntermediate.Text);
            if (intloss != 0 && intloss >= new Utils().stringtoDouble(textBoxStopLoss.Text))
            {
                if (comboBoxLanguage.SelectedIndex == 0)
                {
                    MessageBox.Show("StopLoss intermediate don't superior at stopLoss");
                }
                if (comboBoxLanguage.SelectedIndex == 1)
                {
                    MessageBox.Show("Stopperte intermédiaire ne peux pas être supérieur a stopperte");
                }
                if (comboBoxLanguage.SelectedIndex == 2)
                {
                    MessageBox.Show("Stoppercas intermédios não pode ser superior a stoppercas");
                }
                stop = true;
            }
            //se dá erro a me ligar a DB não faço mais nada
            //aqui tenho de abrir a outra janela que vai ficar a funcar em paralela dessa
            try
            {
                if (checkBoxCloseSkype.Checked)
                {
                    new Utils().detectApps("Skype");
                }

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
                        //em vez de mandar só string crio um array do que preciso
                        String[] data = { textBoxStopLoss.Text, textBoxStopHand.Text, textBoxStopTime.Text, textBoxStopWin.Text, textBoxStopLossPeak.Text, textBoxPeakOver.Text, textBoxStopLossIntermediate.Text, textBoxStopWinIntermediate.Text };
                        String[] sounds = { soundloss, soundtime, soundwin, soundhands, soundinternediateloss, soundinternediatewin };
                        Boolean[] checkb = { checkBoxHideBbbs.Checked, checkBoxButtonSet.Checked, checkBoxVerifyApplication.Checked, checkBoxRageQuit.Checked, repeat, checkBoxSnoozeSound.Checked };
                        //para o limit
                        Int32 limit;
                        if (comboBoxBRM.SelectedIndex == 0)
                        {
                            limit = 0;
                        }
                        else
                        {
                            limit = new Utils().stringtoInt32(comboBoxBRM.SelectedItem.ToString());
                        }
                        Int32 minutesnooze = new Utils().stringtoInt32(comboBoxSnoozeMinute.SelectedItem.ToString());
                        //
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
                                sl = new Stoploss(this, playeralias, db, data, checkb, limit, minutesnooze, sounds, 1);
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
                                sl = new Stoploss(this, playeralias, db, data, checkb, limit, minutesnooze, sounds, 2);
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
                            sl = new Stoploss(this, playeralias, db, data, checkb, limit, minutesnooze, sounds, 4);
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
            String filepath = path + "/config/config_main.txt";
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
            else
            {
                //aqui vou por uma form a pedir a lingua
                //this.Visible = false;
                FormInit fi = new FormInit(this);
                fi.Show();
                //depois ao voltar do form peço se querem ver a ajuda                
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
                case "StopLossIntermediate":
                    textBoxStopLossIntermediate.Text = line[1].ToString();
                    break;
                case "StopWinIntermediate":
                    textBoxStopWinIntermediate.Text = line[1].ToString();
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
                case "soundloss":
                    soundloss = line[1].ToString();
                    break;
                case "soundtime":
                    soundtime = line[1].ToString();
                    break;
                case "soundwin":
                    soundwin = line[1].ToString();
                    break;
                case "soundhands":
                    soundhands = line[1].ToString();
                    break;
                case "Skype":
                    if (line[1].ToString().Equals("True"))
                    {
                        checkBoxCloseSkype.Checked = true;
                    }
                    else
                    {
                        checkBoxCloseSkype.Checked = false;
                    }
                    break;
                case "historybbsloss":
                    histbbsloss = new Utils().stringtoDouble(line[1].ToString());
                    textBoxHistoryBbsloss.Text = line[1].ToString();
                    break;
                case "historytimer":
                    histtime = new Utils().stringtoInt32(line[1].ToString());
                    textBoxHistoryTime.Text = new Utils().intToStringTimer(histtime);
                    break;
                case "historyhands":
                    histhands = new Utils().stringtoInt32(line[1].ToString());
                    textBoxHistoryHands.Text = line[1].ToString();
                    break;
                case "historybbsmax":
                    histbbsmax = new Utils().stringtoDouble(line[1].ToString());
                    textBoxHistoryBbsMax.Text = line[1].ToString();
                    break;
                case "Buttonset":
                    if (line[1].ToString().Equals("True"))
                    {
                        checkBoxButtonSet.Checked = true;
                    }
                    else
                    {
                        checkBoxButtonSet.Checked = false;
                    }
                    break;
                case "ComboboxBRM":
                    comboBoxBRM.SelectedIndex = new Utils().stringtoInt32(line[1].ToString());
                    break;
                case "ComboboxLanguage":
                    comboBoxLanguage.SelectedIndex = new Utils().stringtoInt32(line[1].ToString());
                    break;
                case "Verifyapp":
                    if (line[1].ToString().Equals("True"))
                    {
                        checkBoxVerifyApplication.Checked = true;
                    }
                    else
                    {
                        checkBoxVerifyApplication.Checked = false;
                    }
                    break;
                case "Ragequit":
                    if (line[1].ToString().Equals("True"))
                    {
                        checkBoxRageQuit.Checked = true;
                    }
                    else
                    {
                        checkBoxRageQuit.Checked = false;
                    }
                    break;
                case "repeatsound":
                    if (line[1].ToString().Equals("True"))
                    {
                        repeat = true;
                    }
                    else
                    {
                        repeat = false;
                    }
                    break;
                case "Snooze":
                    if (line[1].ToString().Equals("True"))
                    {
                        checkBoxSnoozeSound.Checked = true;
                        comboBoxSnoozeMinute.Enabled = true;
                    }
                    else
                    {
                        checkBoxSnoozeSound.Checked = false;
                        comboBoxSnoozeMinute.Enabled = false;
                    }
                    break;
                case "Snoozeminute":
                    comboBoxSnoozeMinute.SelectedIndex = new Utils().stringtoInt32(line[1].ToString());
                    break;
                default:
                    break;
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            String location = this.Location.X.ToString() + ',' + this.Location.Y.ToString();
            String path = Directory.GetCurrentDirectory();
            StreamWriter w = new StreamWriter(path + "/config/config_main.txt", false);
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
            w.Write("soundloss=" + soundloss);
            w.WriteLine();
            w.Write("soundtime=" + soundtime);
            w.WriteLine();
            w.Write("soundwin=" + soundwin);
            w.WriteLine();
            w.Write("soundhands=" + soundhands);
            w.WriteLine();
            w.Write("Skype=" + checkBoxCloseSkype.Checked.ToString());
            w.WriteLine();
            w.Write("historybbsloss=" + histbbsloss.ToString());
            w.WriteLine();
            w.Write("historytimer=" + histtime.ToString());
            w.WriteLine();
            w.Write("historyhands=" + histhands.ToString());
            w.WriteLine();
            w.Write("historybbsmax=" + histbbsmax.ToString());
            w.WriteLine();
            w.Write("Buttonset=" + checkBoxButtonSet.Checked.ToString());
            w.WriteLine();
            w.Write("ComboboxBRM=" + comboBoxBRM.SelectedIndex);
            w.WriteLine();
            w.Write("ComboboxLanguage=" + comboBoxLanguage.SelectedIndex);
            w.WriteLine();  
            w.Write("StopLossIntermediate=" + textBoxStopLossIntermediate.Text.ToString());
            w.WriteLine();
            w.Write("StopWinIntermediate=" + textBoxStopWinIntermediate.Text.ToString());
            w.WriteLine();
            w.Write("Verifyapp=" + checkBoxVerifyApplication.Checked.ToString());
            w.WriteLine();
            w.Write("Ragequit=" + checkBoxRageQuit.Checked.ToString());
            w.WriteLine();
            w.Write("repeatsound=" + repeat.ToString());
            w.WriteLine();
            w.Write("Snooze=" + checkBoxSnoozeSound.Checked.ToString());
            w.WriteLine();
            w.Write("Snoozeminute=" + comboBoxSnoozeMinute.SelectedIndex);
            w.WriteLine();            
            w.Close();
            //test
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
        public void setNewValue(String hand, String loss, String time, String win, String losspeak, String peakover, Boolean hidebb, String wininter, String lossinter)
        {
            textBoxStopLoss.Text = loss;
            textBoxStopHand.Text = hand;
            textBoxStopTime.Text = time;
            textBoxStopWin.Text = win;
            textBoxStopLossPeak.Text = losspeak;
            textBoxPeakOver.Text = peakover;
            textBoxStopLossIntermediate.Text = lossinter;
            textBoxStopWinIntermediate.Text = wininter;
            if (hidebb)
            {
                checkBoxHideBbbs.Checked = true;
            }
            else
            {
                checkBoxHideBbbs.Checked = false;
            }
        }

        /// <summary>
        /// Ressume da sessão
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="loss"></param>
        /// <param name="time"></param>
        public void setValueSession(String hand, String time, Double bbs, Double bbmax, Double bb100)
        {
            if (resumesession)
            {
                textBoxRsHands.Text = hand;
                if (String.IsNullOrEmpty(time))
                {
                    textBoxRsTime.Text = "00:00:00";
                }
                else
                {
                    textBoxRsTime.Text = time;
                }                
                textBoxBbsMax.Text = bbmax.ToString();
                if (bbmax > 0)
                {
                    textBoxBbsMax.ForeColor = Color.Green;
                    labelBbsMax.ForeColor = Color.Green;
                }
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
                if (bb100 < 0)
                {
                    textBoxbb100.Text = bb100.ToString();
                    textBoxbb100.ForeColor = Color.Red;
                    labelbb100.ForeColor = Color.Red;
                }
                else
                {
                    textBoxbb100.Text = bb100.ToString();
                    textBoxbb100.ForeColor = Color.Green;
                    labelbb100.ForeColor = Color.Green;
                }
                tabControlMain.SelectedIndex = 2;
            }
            //mas faço na mesma o history
            Int32 handsession = new Utils().stringtoInt32(hand);
            Int32 timesession = new Utils().stringTimeToMinute(time);
            if (handsession > histhands)
            {
                histhands = handsession;
                textBoxHistoryHands.Text = handsession.ToString();
            }
            if (timesession > histtime)
            {
                histtime = timesession;
                textBoxHistoryTime.Text = new Utils().intToStringTimer(timesession);
            }
            if (bbs < histbbsloss)
            {
                histbbsloss = bbs;
                textBoxHistoryBbsloss.Text = bbs.ToString();
            }
            if (bbs > histbbsmax)
            {
                histbbsmax = bbs;
                textBoxHistoryBbsMax.Text = bbs.ToString();
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

        private void textBoxPeakOver_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Utils().onlynumeric(e);
        }

        private void textBoxStopLossIntermediate_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Utils().onlynumeric(e);
        }

        private void textBoxStopWinIntermediate_KeyPress(object sender, KeyPressEventArgs e)
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

        /// <summary>
        /// call form for select sounds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChoiceSounds_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            String[] sound = new String[] { soundloss, soundtime, soundwin, soundhands };
            FormSounds fs = new FormSounds(this, sound, repeat);
            fs.Show();
        }

        /// <summary>
        /// set value for sounds
        /// </summary>
        /// <param name="loss"></param>
        /// <param name="hands"></param>
        /// <param name="time"></param>
        /// <param name="win"></param>
        public void setSounds(String loss, String hands, String time, String win, Boolean repeatsounds)
        {
            soundloss = loss;
            soundtime = time;
            soundwin = win;
            soundhands = hands;
            repeat = repeatsounds;
        }

        /// <summary>
        /// Send mail to support
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelFeedback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:stoploss59@gmail.com");
        }

        /// <summary>
        /// Link to help browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String pathfinal = Directory.GetCurrentDirectory();
            System.Diagnostics.Process.Start(pathfinal + help);
        }

        /// <summary>
        /// le choix de la langue plus facil dans le soft.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLanguage.SelectedIndex == 0)//english
            {
                linkLabelHelp.Text = "Help";
                linkLabelHelp2.Text = "Help";
                labelPlayer.Text = "Player";
                labelServer.Text = "Server";
                labelPort.Text = "Port";
                labelDb.Text = "DataBase";
                labelUserDb.Text = "UserDb";
                labePassword.Text = "Password";
                labelTitleDB.Text = "Database Config";
                help = "/help/header_en.html";
                labelStoploss.Text = "StopLoss:";
                labelStopLossPeak.Text = "StopLossPeak";
                labelBbOver.Text = "BBs Over";
                labelStophands.Text = "StopHands";
                labelStopTime.Text = "StopTime";
                labelStopWin.Text = "StopWin:";
                labelResumeOnStop.Text = "Resume on Stop";
                labelHideBbs.Text = "Hide BBs";
                labelCloseSkype.Text = "Close Skype?";
                labelActiveSet.Text = "Activate Button Set?";
                labelBrm.Text = "Block Limit Above";
                buttonChoiceSounds.Text = "Sounds";
                labelInfo.Text = "View help please";
                labelInfo2.Text = "View help please";
                labelInfo3.Text = "View help please";
                labelInfo4.Text = "View help please";
                labelResumeSession.Text = "Resume Session";
                labelHistoryMax.Text = "History";
                labelStoplossIntermediate.Text = "Intermediate";
                labelStopWinIntermediate.Text = "Intermediate";
                labelVerifyApp.Text = "Verify application?";
                labelSnoozeSounds.Text = "Snooze Sound";
            }
            if (comboBoxLanguage.SelectedIndex == 1)//french
            {
                linkLabelHelp.Text = "Aide";
                linkLabelHelp2.Text = "Aide";
                labelPlayer.Text = "Joueur";
                labelServer.Text = "Serveur";
                labelPort.Text = "Port";
                labelDb.Text = "Base de Donnée";
                labelUserDb.Text = "Utilisateur BD";
                labePassword.Text = "Mot de passe";
                labelTitleDB.Text = "Conf. Base de Donnée";
                help = "/help/header_fr.html";
                labelStoploss.Text = "StopPerte:";
                labelStopLossPeak.Text = "StopPertePic";
                labelBbOver.Text = "BBs au dessus de";
                labelStophands.Text = "StopMains";
                labelStopTime.Text = "StopTemps";
                labelStopWin.Text = "StopGain:";
                labelResumeOnStop.Text = "Resumé de session";
                labelHideBbs.Text = "Cacher les BBs";
                labelCloseSkype.Text = "Fermer Skype?";
                labelActiveSet.Text = "Activer Bouton Set?";
                labelBrm.Text = "Bloquer limite au dessus";
                buttonChoiceSounds.Text = "Sons";
                labelInfo.Text = "Voir l'aide svp";
                labelInfo2.Text = "Voir l'aide svp";
                labelInfo3.Text = "Voir l'aide svp";
                labelInfo4.Text = "Voir l'aide svp";
                labelResumeSession.Text = "Résumé de Session";
                labelHistoryMax.Text = "Historique";
                labelStoplossIntermediate.Text = "Intermédiaire";
                labelStopWinIntermediate.Text = "Intermédiaire";
                labelVerifyApp.Text = "Vérifier Applications?";
                labelSnoozeSounds.Text = "Snooze Son";
            }
            if (comboBoxLanguage.SelectedIndex == 2)//portugues
            {
                linkLabelHelp.Text = "Ajuda";
                linkLabelHelp2.Text = "Ajuda";
                labelPlayer.Text = "Jogador";
                labelServer.Text = "Servidor";
                labelPort.Text = "Porta";
                labelDb.Text = "Base Dados";
                labelUserDb.Text = "Utilizador BD";
                labePassword.Text = "Palavra passe";
                labelTitleDB.Text = "Conf. Base Dados";
                help = "/help/header_pt.html";
                labelStoploss.Text = "StopPercas:";
                labelStopLossPeak.Text = "StopPercasPico";
                labelBbOver.Text = "BBs acima de";
                labelStophands.Text = "StopMãos";
                labelStopTime.Text = "StopTempo";
                labelStopWin.Text = "StopGanhos:";
                labelResumeOnStop.Text = "Resumir a sessão";
                labelHideBbs.Text = "Esconder os BBs";
                labelCloseSkype.Text = "Fechar Skype?";
                labelActiveSet.Text = "Ativar botão Set?";
                labelBrm.Text = "Bloquear limite acima";
                buttonChoiceSounds.Text = "Sons";
                labelInfo.Text = "Ver a ajuda sff";
                labelInfo2.Text = "Ver a ajuda sff";
                labelInfo3.Text = "Ver a ajuda sff";
                labelInfo4.Text = "Ver a ajuda sff";
                labelResumeSession.Text = "Resumo da Sessão";
                labelHistoryMax.Text = "Histórico";
                labelStoplossIntermediate.Text = "Intermédio";
                labelStopWinIntermediate.Text = "Intermédio";
                labelVerifyApp.Text = "Verificar Applicações?";
                labelSnoozeSounds.Text = "Snooze Som";
            }
        }

        /// <summary>
        /// Link to help browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelHelp2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String pathfinal = Directory.GetCurrentDirectory();
            System.Diagnostics.Process.Start(pathfinal + help);
        }

        /// <summary>
        /// First start sfotware
        /// </summary>
        /// <param name="cb"></param>
        public void SelectLanguage(int cb)
        {
            comboBoxLanguage.SelectedIndex = cb;
            string helpstart = "";
            switch (comboBoxLanguage.SelectedIndex)
            {
                case 0:
                    helpstart = "View help?";
                    break;
                case 1:
                    helpstart = "Voir l'aide?";
                    break;
                case 2:
                    helpstart = "Ver a ajuda?";
                    break;
            }
            DialogResult dialogResult = MessageBox.Show(helpstart, "StopLoss", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                String pathfinal = Directory.GetCurrentDirectory();
                System.Diagnostics.Process.Start(pathfinal + help);
            }
        }

        /// <summary>
        /// para ativar a combobox dos minutos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxSnoozeSound_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSnoozeSound.Checked)
            {
                comboBoxSnoozeMinute.Enabled = true;
            }
            else
            {
                comboBoxSnoozeMinute.Enabled = false;
            }
        }

        
    }
}
