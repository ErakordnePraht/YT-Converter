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
        public void StartLink(Process convert, TextBox linkBox, ProgressBar progressBar1, string link)
        {
            int safeGuard = 0;
            int protsent = 0;
            string consOutput = "";

            convert.StartInfo.UseShellExecute = false;
            convert.StartInfo.CreateNoWindow = true;
            convert.StartInfo.RedirectStandardOutput = true;
            convert.Start();

            for (int a = 0; a < 6; a++)
            {
                consOutput = convert.StandardOutput.ReadLine();
            }

            while (protsent != 100)
            {
                if (string.IsNullOrWhiteSpace(consOutput))
                {
                    safeGuard++;
                    if (safeGuard == 5)
                    {
                        MessageBox.Show("Miski on valesti");
                        break;
                    }
                }
                try
                {
                    if (convert.StandardOutput.ReadLine().Substring(11, 6).Contains("%"))
                    {
                        consOutput = convert.StandardOutput.ReadLine();
                        string Protsenttekst = consOutput.Substring(11, 6);
                        Protsenttekst = Regex.Match(Protsenttekst, @"\d+").Value;
                        protsent = Int32.Parse(Protsenttekst);
                        progressBar1.Value = protsent;
                    }
                }
                catch (Exception)
                {
                    //ignorein seda, sest kui output on lühem kui substring tahab et see oleks siis see crashib
                }
            }
            convert.WaitForExit();
        }
        public void StartPlaylist(Process convert, TextBox linkBox, ProgressBar progressBar1, string link)
        {
            int playlistVideoNumber = 1;
            int protsent = 0;
            string consOutput;
            bool esimeneValueOlemas = false;

            convert.StartInfo.UseShellExecute = false;
            convert.StartInfo.CreateNoWindow = true;
            convert.StartInfo.RedirectStandardOutput = true;
            convert.Start();

            for (int a = 0; a < 13; a++)
            {
                consOutput = convert.StandardOutput.ReadLine();
                string videodeNumber = Regex.Match(consOutput, @"\d+").Value;
                if (consOutput.Contains("Downloading " + videodeNumber + " videos") && !esimeneValueOlemas)
                {
                    if (consOutput != "")
                    {
                        playlistVideoNumber = Int32.Parse(videodeNumber);
                        esimeneValueOlemas = true;
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
                            consOutput = convert.StandardOutput.ReadLine();
                            string Protsenttekst = consOutput.Substring(11, 6);
                            Protsenttekst = Regex.Match(Protsenttekst, @"\d+").Value;
                            protsent = Int32.Parse(Protsenttekst);
                            progressBar1.Value = protsent;
                            if (protsent == 100)
                            {
                                for (int b = 0; b < 10; b++)
                                {
                                    consOutput = convert.StandardOutput.ReadLine();
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
        public void StartTXTFile(Process convert, TextBox linkBox, ProgressBar progressBar1, string link, string TXTFile)
        {
            int playlistVideoNumber = 1;
            int protsent = 0;
            string consOutput;

            convert.StartInfo.UseShellExecute = false;
            convert.StartInfo.CreateNoWindow = true;
            convert.StartInfo.RedirectStandardOutput = true;
            convert.Start();

            for (int a = 0; a < 6; a++)
            {
                consOutput = convert.StandardOutput.ReadLine();
            }
            playlistVideoNumber = File.ReadLines(TXTFile).Count();

            for (int i = 0; i < playlistVideoNumber; i++)
            {
                while (protsent != 100)
                {
                    try
                    {
                        if (convert.StandardOutput.ReadLine().Substring(11, 6).Contains("%"))
                        {
                            consOutput = convert.StandardOutput.ReadLine();
                            string Protsenttekst = consOutput.Substring(11, 6);
                            Protsenttekst = Regex.Match(Protsenttekst, @"\d+").Value;
                            protsent = Int32.Parse(Protsenttekst);
                            progressBar1.Value = protsent;
                            if (protsent == 100)
                            {
                                for (int b = 0; b < 8; b++)
                                {
                                    consOutput = convert.StandardOutput.ReadLine();
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
            TXTFile = string.Empty;
        }
    }
}
