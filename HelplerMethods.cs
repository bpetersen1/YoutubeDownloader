using System.IO;
using System.Text.RegularExpressions;

namespace YouTube_Downloader
{
    public class HelplerMethods
    {
        public static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }
    }
}
