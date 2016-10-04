using System;
using System.Collections.Generic;
using System.IO;
using YouTube_Downloader.Objects;

namespace YouTube_Downloader
{
    public static class FileReader
    {
        public static List<Url> GetYoutubreUrls()
        {
            var urls = new List<Url>();
            var line = string.Empty;
            using (var sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + Configs.ListFileName))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    var u = new Url
                    {
                        YoutubeUrl = line
                    };

                    urls.Add(u);
                }

                return urls;
            }
        }
    }
}