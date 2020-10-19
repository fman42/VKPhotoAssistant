using CommandLine;

namespace VKPhotoAssistant.Utilities.Album.Options
{
    public class DownloadOptions
    {
        [Value(0, Required = true)]
        public long AlbumId { get; set; }

        [Option("limit", Required = false, Default = 10)]
        public ulong? Limit { get; set; }
   
        [Option("offset", Required = false, Default = 0)]
        public ulong? Offset { get; set; }
    }
}
