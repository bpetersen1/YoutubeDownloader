using System;
using System.Collections.Generic;
using System.IO;
using YouTube_Downloader.Objects;

namespace YouTube_Downloader
{
    public static class FileReader
    {
        public static List<Url> GetYoutubreURLS()
        {
            List<Url> urls = new List<Url>();
            string line = string.Empty;
            using (var sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + Configs.ListFileName))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Url u = new Url {
                        YoutubeUrl = line
                    };

                    urls.Add(u);
                }

                return urls;
            }
        }
        
    }
}
