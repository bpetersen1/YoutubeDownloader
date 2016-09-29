using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_Downloader
{
    public static class SystemCheck
    {

        public static void DoFilesystemCheck()
        {
            DirectoryInfo di = new DirectoryInfo(Configs.Savepath);

            FileInfo fi = new FileInfo(Configs.FullPathToList);

            CheckDirectoryExists(di);

            CheckListExists(fi);

            if (isListFileEmpty()) SystemMessage.WriteConsoleMessage($"{Configs.ListFileName} is empty please add some youtube url's", ColorEnum.Yellow, false, true);
        }

        private static void CheckDirectoryExists(DirectoryInfo di)
        {
            if (!di.Exists) di.Create();
        }

        private static void CheckListExists(FileInfo fi)
        {
            if (!fi.Exists) fi.Create().Dispose();
        }

        private static bool isListFileEmpty()
        {
            return new FileInfo(Configs.FullPathToList).Length < 1;
        }
    }
}
