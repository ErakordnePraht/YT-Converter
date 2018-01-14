using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

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
        }

        private void checkKonsool_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tõmba_Click(object sender, EventArgs e)
        {
            int protsent = 0;
            if (string.IsNullOrWhiteSpace(path))
            {
                path = Directory.GetCurrentDirectory();
            }

            if (Convert.ToString(formatBox.SelectedItem) != "" || link != "")
            {
                formaat = Convert.ToString(formatBox.SelectedItem);
                Process convert = new Process();
                convert.StartInfo.FileName = "youtube-dl.exe";
                SetStartInfo set = new SetStartInfo();
                var failiNimi = set.SetArgument(convert, formaat, path, link);

                if (!File.Exists(path + @"\" + failiNimi + "." + formaat) || !File.Exists(path + @"\" + failiNimi + ".mp4"))
                {
                    if (!checkKonsool.Checked)
                    {
                        convert.StartInfo.UseShellExecute = false;
                        convert.StartInfo.CreateNoWindow = true;
                        convert.StartInfo.RedirectStandardOutput = true;
                        convert.Start();
                        if (!link.Contains("list"))
                        {
                            for (int a = 0; a < 6; a++)
                            {
                                kõik = convert.StandardOutput.ReadLine();
                            }
                            playlistVideoNumber = 1;
                        }
                        else
                        {
                            for (int a = 0; a < 13; a++)
                            {
                                kõik = convert.StandardOutput.ReadLine();
                                string videodeNumber = Regex.Match(kõik, @"\d+").Value;
                                if (kõik.Contains("Downloading " + videodeNumber + " videos") && !esimeneValueOlemas)
                                {
                                    if (kõik != "")
                                    {
                                        playlistVideoNumber = Int32.Parse(videodeNumber);
                                        esimeneValueOlemas = true;
                                    }
                                }
                            }
                        }
                        for (int i = 0; i < playlistVideoNumber; i++)
                        {
                            while (protsent != 100)
                            {
                                kõik = convert.StandardOutput.ReadLine();
                                if (kõik != null)
                                {
                                    string Protsenttekst = kõik.Substring(11, 6);
                                    Protsenttekst = Regex.Match(Protsenttekst, @"\d+").Value;
                                    try
                                    {
                                        protsent = Int32.Parse(Protsenttekst);
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("See fail juba eksisteerib");
                                        throw;
                                    }
                                    progressBar1.Value = protsent;
                                }
                                else
                                {
                                    MessageBox.Show("Link ei tööta");
                                    playlistVideoNumber = 0;
                                    break;
                                }
                                if (protsent == 100 && link.Contains("list"))
                                {
                                    for (int b = 0; b < 10; b++)
                                    {
                                        kõik = convert.StandardOutput.ReadLine();
                                    }
                                }
                            }
                            protsent = 0;
                        }
                        convert.WaitForExit();
                    }
                    else
                    {
                        convert.Start();
                        convert.WaitForExit();
                    }
                    if (!link.Contains("list"))
                    {
                        if (File.Exists(path + @"\" + failiNimi + "." + formaat) || File.Exists(path + @"\" + failiNimi + ".mp4"))
                        {
                            MessageBox.Show("Fail lõpetas tõmbamise");
                            progressBar1.Value = 0;
                        }
                        else
                        {
                            MessageBox.Show("Miski on valesti");
                            progressBar1.Value = 0;
                        }  
                    }
                    else
                    {
                        MessageBox.Show("Fail lõpetas tõmbamise");
                        progressBar1.Value = 0;
                    }
                }
                else
                {
                    MessageBox.Show("See fail juba eksisteerib");
                }
            }
            else
            {
                MessageBox.Show("Palun täida kõik väljad");
            }
        }
    }
    class SetStartInfo
    {
        public string SetArgument(Process convert, string formaat, string path, string link)
        {
            string failiNimi = "wololololo";
            if (!link.Contains("list"))
            {
                var fileName = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "youtube-dl.exe",
                        Arguments = "--get-filename " + link,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                fileName.Start();
                failiNimi = fileName.StandardOutput.ReadToEnd();
                fileName.WaitForExit();
                failiNimi = failiNimi.Replace("\n", "");

                if (formaat == "mp3" || formaat == "m4a" || formaat == "wav")
                {
                    convert.StartInfo.Arguments = "--extract-audio --audio-format " + formaat + " -o \"" + path + @"\" + failiNimi + "\"" + " " + link;
                }
                else
                {
                    int indexNumber = failiNimi.IndexOf(".");
                    if (indexNumber > 0)
                    {
                        failiNimi = failiNimi.Substring(0, indexNumber);
                    }
                    failiNimi = failiNimi + ".mp4";
                    if (formaat == "mp4@720p")
                    {
                        convert.StartInfo.Arguments = "-f 22 -o \"" + path + @"\" + failiNimi + "\"" + " " + link;
                    }
                    else
                    {
                        convert.StartInfo.Arguments = "-f 18 -o \"" + path + @"\" + failiNimi + "\"" + " " + link;
                    }
                }
                int indexNumber2 = failiNimi.IndexOf(".");
                if (indexNumber2 > 0)
                {
                    failiNimi = failiNimi.Substring(0, indexNumber2);
                } 
            }
            else
            {
                if (formaat == "mp3" || formaat == "m4a" || formaat == "wav")
                {
                    convert.StartInfo.Arguments = "--extract-audio --audio-format " + formaat + " " + link;
                }
                else
                {
                    if (formaat == "mp4@720p")
                    {
                        convert.StartInfo.Arguments = "-f 22 " + link;
                    }
                    else
                    {
                        convert.StartInfo.Arguments = "-f 18 " + link;
                    }
                }
            }
            return failiNimi;
        }
    }
}
