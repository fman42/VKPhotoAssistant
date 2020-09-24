using CommandLine;

namespace VKPhotoAssistant.Utilities.VKToken.Options
{
    internal class GetTokenOptions
    {
        [Option('i', "index", Default = null, Required = false)]
        public int? Index { get; set; }
    }
}
