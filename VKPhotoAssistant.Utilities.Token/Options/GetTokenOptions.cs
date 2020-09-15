using CommandLine;

namespace VKPhotoAssistant.Utilities.VKToken.Options
{
    internal class GetTokenOptions
    {
        [Value(0, Required = false)]
        public int Index { get; set; }
    }
}
