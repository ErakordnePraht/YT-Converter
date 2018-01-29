using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace YT_Converter
{
    class SetStartInfo
    {
        public string SetArgument(Process convert, string formaat, string path, string link, string TXTFail)
        {
            string failiNimi = "wololololo";
            if (string.IsNullOrWhiteSpace(link) && !string.IsNullOrWhiteSpace(TXTFail))
            {
                if (formaat == "wav" || formaat == "mp3" || formaat == "m4a")
                {
                    convert.StartInfo.Arguments = "--extract-audio --audio-format " + formaat + " -a " + TXTFail;
                }
                else
                {
                    convert.StartInfo.Arguments = "youtube-dl -f bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best -a " + TXTFail;
                }
            }
            else if (link.Contains("playlist"))
            {
                if (formaat == "mp3" || formaat == "m4a" || formaat == "wav")
                {
                    convert.StartInfo.Arguments = "--extract-audio --audio-format " + formaat + " " + link;
                }
                else
                {
                    convert.StartInfo.Arguments = "youtube-dl -f bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best " + link;
                }
            }
            else if (!string.IsNullOrWhiteSpace(link))
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
                string fileType = failiNimi.Substring(failiNimi.LastIndexOf("."));
                failiNimi = failiNimi.Substring(0, failiNimi.LastIndexOf("-"));

                if (formaat == "mp3" || formaat == "m4a" || formaat == "wav")
                {
                    failiNimi = failiNimi + fileType;
                    convert.StartInfo.Arguments = "--extract-audio --audio-format " + formaat + " -o \"" + path + @"\" + failiNimi + "\"" + " " + link;
                    failiNimi = failiNimi.Substring(0, failiNimi.LastIndexOf("."));
                }
                else
                {
                    failiNimi = failiNimi + ".mp4";
                    convert.StartInfo.Arguments = "-f bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best -o \"" + path + @"\" + failiNimi + "\"" + " " + link;
                    failiNimi = failiNimi.Substring(0, failiNimi.LastIndexOf("."));
                }
            }
            else
            {
                MessageBox.Show("Miski on valesti");
            }
            return failiNimi;
        }
    }
}
