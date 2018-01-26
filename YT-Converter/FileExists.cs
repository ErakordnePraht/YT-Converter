using System;
using System.IO;

namespace YT_Converter
{
    class FileExists
    {
        public bool Exist(string failiNimi, string formaat, string path)
        {
            if (File.Exists(path + @"\" + failiNimi + "." + formaat) || File.Exists(path + @"\" + failiNimi + ".mp4") || File.Exists(path + @"\" + failiNimi))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
