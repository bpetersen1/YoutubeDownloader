using System;
using System.Collections.Generic;
using System.Linq;
using YoutubeExtractor;

namespace YouTube_Downloader
{
   public static class YoutubeVideoUtil
    {
        public static VideoInfo GetUserQualityOrDefault(string youtubeUrl) {

            IEnumerable<VideoInfo> v = GetListFromYoutube(youtubeUrl);

            return SortedYoutubeObject(v);
        }


        private static IEnumerable<VideoInfo> GetListFromYoutube(string youtubeUrl) {

            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(youtubeUrl);

            return videoInfos;
        }

        private static VideoInfo SortedYoutubeObject(IEnumerable<VideoInfo> v) {

            //From the list of video's, find the quality of video the user wants based on the value from the config
            VideoInfo video = v
                .FirstOrDefault(info => info.VideoType == VideoType.Mp4 && info.Resolution == Configs.VideoResolution);

            //If no youtube video is found with the quality that the user wants, select the best quality from the list
            if (video == null)
            {
                video = v
               .OrderByDescending(x => x.Resolution)
               .First(info => info.VideoType == VideoType.Mp4);

                SystemMessage.WriteConsoleMessage($"{Environment.NewLine}Could not find a {Configs.VideoResolution}p version of the video you where looking for. Downloading a {video.Resolution}p version {Environment.NewLine}", ColorEnum.Yellow, false, false);
               
            }
            return video;
        }
    }
}
