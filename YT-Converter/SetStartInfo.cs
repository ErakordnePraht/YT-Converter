using System;
using System.Diagnostics;

namespace YT_Converter
{
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
                failiNimi = failiNimi.Substring(0, failiNimi.LastIndexOf("-"));

                if (formaat == "mp3" || formaat == "m4a" || formaat == "wav")
                {
                    convert.StartInfo.Arguments = "--extract-audio --audio-format " + formaat + " -o \"" + path + @"\" + failiNimi + "." + formaat + "\"" + " " + link;
                }
                else
                {
                    failiNimi = failiNimi + ".mp4";
                    if (formaat == "mp4@720p")
                    {
                        convert.StartInfo.Arguments = "-f 22 -o \"" + path + @"\" + failiNimi + "\"" + " " + link;
                    }
                    else
                    {
                        convert.StartInfo.Arguments = "-f 18 -o \"" + path + @"\" + failiNimi + "\"" + " " + link;
                    }
                    failiNimi = failiNimi.Substring(0, failiNimi.LastIndexOf("."));
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
