using System;
using System.Configuration;

namespace YouTube_Downloader
{
    public static class Configs
    {
        public static int VideoResolution => Convert.ToInt32(ConfigurationManager.AppSettings["VideoResolution"]);

        public static string Savepath => ConfigurationManager.AppSettings["SavePath"];

        public static string ListFileName => ConfigurationManager.AppSettings["YoutubeListFileName"];

        public static string FullPathToList => AppDomain.CurrentDomain.BaseDirectory + ListFileName;
    }
}
