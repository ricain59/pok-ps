﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Npgsql;

namespace TiltStopLoss
{
    public partial class Main : Form
    {
        private Db db = new Db();
        
        public Main()
        {
            InitializeComponent();
            loadconfig();
            db.getData(textBoxUser.Text, textBoxServer.Text, textBoxPort.Text, textBoxPass.Text, textBoxDb.Text, textBoxPlayer.Text);
            try
            {
                textBoxPlayer.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBoxPlayer.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                string query = "select player_id, playername from players ";
                db.connectDb();
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

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void buttonTestDb_Click(object sender, EventArgs e)
        {
            db.getData(textBoxUser.Text, textBoxServer.Text, textBoxPort.Text, textBoxPass.Text, textBoxDb.Text, textBoxPlayer.Text);
            String testconnect = db.testconnectDb();
            if (testconnect.Equals(""))
            {
                MessageBox.Show("Test connection OK");
            }
            else
            {
                MessageBox.Show(testconnect);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Boolean stop = false;
            //ligo me a DB para ir buscar o ultimo id inserido
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
                    this.Visible = false;
                    Stoploss sl = new Stoploss(this, textBoxPlayerID.Text, db, textBoxPlayer.Text, textBoxStopLoss.Text);
                    sl.Show();
                    //sl.beginBB(this, textBoxPlayer.Text, db);
                }
            }
            catch (Exception ex)
            {
                new Debug().LogMessage(ex.ToString());
            }
        }

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
            
            w.Close();
        }

        private void textBoxPlayer_Leave(object sender, EventArgs e)
        {
            string query = "select player_id from players where playername = '"+textBoxPlayer.Text.ToString()+"'";
            db.connectDb();
            NpgsqlCommand command = new NpgsqlCommand(query, db.conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                textBoxPlayerID.Text = dr[0].ToString();
            }
            dr.Close();
            db.closeconDb();
        }

    }
}
