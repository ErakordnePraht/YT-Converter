using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace YT_Converter
{
    class StartConverter
    {
        public void Start(Process convert, TextBox linkBox, ProgressBar progressBar1, string link, string TXTFail)
        {
            int playlistVideoNumber = 1;
            int protsent = 0;
            string kõik;
            bool esimeneValueOlemas = false;

            convert.StartInfo.UseShellExecute = false;
            convert.StartInfo.CreateNoWindow = true;
            convert.StartInfo.RedirectStandardOutput = true;
            convert.Start();
            if (string.IsNullOrWhiteSpace(TXTFail))
            {
                for (int a = 0; a < 6; a++)
                {
                    kõik = convert.StandardOutput.ReadLine();
                }
            }
            else if (!string.IsNullOrWhiteSpace(TXTFail))
            {
                for (int a = 0; a < 6; a++)
                {
                    kõik = convert.StandardOutput.ReadLine();
                }
                if (!string.IsNullOrWhiteSpace(TXTFail))
                {
                    playlistVideoNumber = File.ReadLines(TXTFail).Count();
                }
            }
            else if (link.Contains("playlist"))
            {
                for (int a = 0; a < 6; a++)
                {
                    kõik = convert.StandardOutput.ReadLine();
                }
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
                    try
                    {
                        if (convert.StandardOutput.ReadLine().Substring(11, 6).Contains("%"))
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
                                linkBox.Text = "";
                                break;
                            }
                            if (protsent == 100 && link.Contains("playlist"))
                            {
                                for (int b = 0; b < 10; b++)
                                {
                                    kõik = convert.StandardOutput.ReadLine();
                                }
                            }
                            else if (protsent == 100 && !string.IsNullOrWhiteSpace(TXTFail))
                            {
                                for (int b = 0; b < 8; b++)
                                {
                                    kõik = convert.StandardOutput.ReadLine();
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //ignorein seda, sest kui output on lühem kui substring tahab et see oleks siis see crashib
                    }
                }
                protsent = 0;
            }
            convert.WaitForExit();
        }
    }
}
