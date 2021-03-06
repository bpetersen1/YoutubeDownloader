﻿using System.IO;

namespace YouTube_Downloader
{
    public static class SystemCheck
    {
        public static void DoFilesystemCheck()
        {
            var di = new DirectoryInfo(Configs.Savepath);

            var fi = new FileInfo(Configs.FullPathToList);

            CheckDirectoryExists(di);

            CheckListExists(fi);

            if (IsListFileEmpty())
                SystemMessage.WriteConsoleMessage($"{Configs.ListFileName} is empty please add some youtube url's",
                    ColorEnum.Yellow, false, true);
        }

        private static void CheckDirectoryExists(DirectoryInfo di)
        {
            if (!di.Exists) di.Create();
        }

        private static void CheckListExists(FileInfo fi)
        {
            if (!fi.Exists) fi.Create().Dispose();
        }

        private static bool IsListFileEmpty()
        {
            return new FileInfo(Configs.FullPathToList).Length < 1;
        }
    }
}