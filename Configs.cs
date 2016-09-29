using System;
using System.Configuration;

namespace YouTube_Downloader
{
    public static class Configs
    {
        public static int VideoResolution { get { return Convert.ToInt32(ConfigurationManager.AppSettings["VideoResolution"].ToString());}}

        public static string Savepath { get { return ConfigurationManager.AppSettings["SavePath"].ToString(); } }

        public static string ListFileName { get { return ConfigurationManager.AppSettings["YoutubeListFileName"].ToString(); } }

        public static string FullPathToList { get { return AppDomain.CurrentDomain.BaseDirectory + ListFileName; } }
    }
}
