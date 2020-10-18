using CommandLine;

namespace VKPhotoAssistant.Utilities.Album.Options
{
    public class GetTokenOptions
    {
        [Option("id", Required = false, Default = null)]
        public long? AlbumId { get; set; }
    }
}
