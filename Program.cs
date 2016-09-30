using System;
using YoutubeExtractor;
using System.IO;
using System.Diagnostics;




namespace YouTube_Downloader
{
    class Program
    {

        static void Main(string[] args)
        {
            Stopwatch totaltime = new Stopwatch();

            Console.Title = "Youtube Downloader by Bradley Petersen";

            SystemMessage.WriteConsoleMessage("Youtube Downloader", ColorEnum.Red, false, false);

            SystemMessage.WriteConsoleMessage($"By Bradley Petersen{Environment.NewLine}", ColorEnum.White, false, false);

            SystemCheck.DoFilesystemCheck();

            SystemMessage.WriteConsoleMessage($"Video's will be saved in the following directory : {Configs.Savepath}",ColorEnum.White,false,false);

            SystemMessage.WriteConsoleMessage("To cancel the download press CTRL+C", ColorEnum.White, false, false);

            totaltime.Start();

            //Pull down each video in the list
            foreach (var item in FileReader.GetYoutubreUrls())
            {
                try
                {
                    VideoInfo video = YoutubeVideoUtil.GetUserQualityOrDefault(item.YoutubeUrl);

                    SystemMessage.WriteConsoleMessage($"Downloading : {video.Title}",ColorEnum.White,false,false);
                    
                    if (video.RequiresDecryption) DownloadUrlResolver.DecryptDownloadUrl(video);

                    VideoDownloader videoDownloader = new VideoDownloader(video, Path.Combine(Configs.Savepath, HelplerMethods.RemoveIllegalPathCharacters(video.Title + video.VideoExtension)));

                    videoDownloader.DownloadProgressChanged += (sender, vargs) => Console.Title = $"Downloading : {video.Title} | {Math.Round(vargs.ProgressPercentage)}% Complete";

                    videoDownloader.Execute();
                }
                catch (Exception ex)
                {
                    SystemMessage.WriteConsoleMessage($"{Environment.NewLine}{ex.Message}", ColorEnum.Red, false, false);

                    SystemMessage.WriteConsoleMessage($"Moving on to the next video{Environment.NewLine}",ColorEnum.White,false,false);

                    continue;
                }

            }
            totaltime.Stop();

            TimeSpan ts = totaltime.Elapsed;
                       
            SystemMessage.WriteConsoleMessage($"All done. Download completed in {ts.Hours}:{ts.Minutes}:{ts.Seconds} {Environment.NewLine}", ColorEnum.Green, false, true);
         
        }
    }
}
