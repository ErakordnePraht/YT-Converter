using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace YT_Converter
{
    public partial class Form1 : Form
    {
        public string path;
        public string link;
        public string formaat;
        public string kõik;
        public int playlistVideoNumber;
        public bool esimeneValueOlemas = false;

        public Form1()
        {
            InitializeComponent();
            formatBox.Items.Add("m4a");
            formatBox.Items.Add("mp3");
            formatBox.Items.Add("wav");
            formatBox.Items.Add("mp4@720p");
            formatBox.Items.Add("mp4@360p");
        }
        private void linkBox_TextChanged(object sender, EventArgs e)
        {
            link = linkBox.Text;
        }

        private void formatBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chooseDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            File.WriteAllText("Directory.txt", path);
        }

        private void checkKonsool_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tõmba_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(path) && !File.Exists("Directory.txt"))
            {
                path = Directory.GetCurrentDirectory();
            }
            else if (File.Exists("Directory.txt"))
            {
                path = File.ReadAllText("Directory.txt");
            }

            if (Convert.ToString(formatBox.SelectedItem) != "" || link != "")
            {
                Process convert = new Process();
                SetStartInfo set = new SetStartInfo();
                FileExists fileExists = new FileExists();

                formaat = Convert.ToString(formatBox.SelectedItem);
                convert.StartInfo.FileName = "youtube-dl.exe";
                var failiNimi = set.SetArgument(convert, formaat, path, link);

                if (!fileExists.Exist(failiNimi, formaat, path))
                {
                    if (!checkKonsool.Checked)
                    {
                        StartConverter startConverter1 = new StartConverter();
                        startConverter1.Start(convert, linkBox, progressBar1, link);
                    }
                    else
                    {
                        convert.Start();
                        convert.WaitForExit();
                    }
                    if (!link.Contains("list"))
                    {
                        if (fileExists.Exist(failiNimi, formaat, path))
                        {
                            MessageBox.Show("Fail lõpetas tõmbamise");
                            progressBar1.Value = 0;
                            linkBox.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Miski on valesti");
                            progressBar1.Value = 0;
                            linkBox.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fail lõpetas tõmbamise");
                        progressBar1.Value = 0;
                        linkBox.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("See fail juba eksisteerib");
                    linkBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Palun täida kõik väljad");
            }
        }
    }
}
