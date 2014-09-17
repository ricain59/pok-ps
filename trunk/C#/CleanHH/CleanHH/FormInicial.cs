using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CleanHH
{
    public partial class FormInicial : Form
    {
        private String folder;
        private String nickname;
        private String site;
        private int handnickname = 0;
        
        public FormInicial()
        {
            InitializeComponent();
            //eliminar ficheiros de erro com mais de 3 dias
            new Utils().deletefileerrors();
            //depois disso volto ao soft caso diz que não
            loadConfig();
        }

        #region Save and load config

        /// <summary>
        /// Permite guardar os dados inseridos no software
        /// </summary>
        private void loadConfig()
        {
            String path = Directory.GetCurrentDirectory();
            String filepath = path + "/config.txt";
            string line;
            // Read the file and display it line by line.
            if (File.Exists(filepath))
            {
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
                case "comboBoxSite":
                    comboBoxSite.SelectedIndex = new Utils().stringtoInt32(line[1].ToString());
                    site = comboBoxSite.SelectedItem.ToString();
                    break;
                case "textBoxFolder":
                    textBoxFolder.Text = line[1].ToString();
                    folder = line[1].ToString();
                    break;
                case "textBoxNickName":
                    textBoxNickName.Text = line[1].ToString();
                    nickname = line[1].ToString();
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
            w.Write("textBoxFolder=" + textBoxFolder.Text.ToString());
            w.WriteLine();
            w.Write("textBoxNickName=" + textBoxNickName.Text.ToString());
            w.WriteLine();
            w.Write("comboBoxSite=" + comboBoxSite.SelectedIndex);
            w.WriteLine();
            w.Close();
            //test
        }

        #endregion

        /// <summary>
        /// clean HH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClean_Click(object sender, EventArgs e)
        {
            if (textBoxFolder.Text.Equals(""))
            {
                MessageBox.Show("Choose folder files hands");
            }
            else
            {
                //criar a pasta new
                if (!Directory.Exists(folder + "/new"))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(folder + "/new");
                }

                //obter todos a lista de ficheiro
                string[] filePaths = Directory.GetFiles(@"" + folder, "*.txt");
                progressBarHand.TabIndex = filePaths.Count();
                String textfile = "";
                //int i = 1;
                foreach (String fi in filePaths)
                {
                    using (StreamReader streamReader = new StreamReader(fi, Encoding.UTF8))
                    {
                        textfile = streamReader.ReadToEnd();
                    }
                    cleanfile(textfile, Path.GetFileName(fi));
                    textfile = "";
                    progressBarHand.Value = progressBarHand.Value + 1;
                    //i++;                    
                }
                progressBarHand.Value = progressBarHand.TabIndex;
                MessageBox.Show("Finish Clean HH, Have " + handnickname + " hands with nickname");
            }
        }

        private void cleanfile(String file, String filename)
        {
            String[] splitfile = file.Split(new string[] { site }, StringSplitOptions.RemoveEmptyEntries);
            String filefinal = "";
            foreach (String fi in splitfile)
            {
                if (!fi.Contains(nickname))
                {
                    filefinal += site + fi;
                }
                else
                {
                    handnickname++;
                }
            }
            //aqui crio o novo ficheiro
            String icon_path = new Uri(folder + "/new").LocalPath;
            String dede = icon_path + "\\" + filename; 
            StreamWriter w = new StreamWriter(dede, true);
            w.Write(filefinal);
            w.WriteLine();
            w.Close();
        }

        /// <summary>
        /// choose folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChooseFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialogHand.ShowDialog();
            textBoxFolder.Text = folderBrowserDialogHand.SelectedPath.ToString();
            folder = folderBrowserDialogHand.SelectedPath.ToString();
        }

        



    }
}
