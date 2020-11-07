using CommandLine;

namespace VKPhotoAssistant.Utilities.Album.Options
{
    public class DownloadOptions
    {
        [Value(0, Required = true)]
        public long AlbumId { get; set; }

        [Option("limit", Required = false, Default = 1000)]
        public int? Limit { get; set; }
   
        [Option("offset", Required = false, Default = 0)]
        public int? Offset { get; set; }

        [Option("output", Required = false, Default = null)]
        public string Output { get; set; }
    }
}
