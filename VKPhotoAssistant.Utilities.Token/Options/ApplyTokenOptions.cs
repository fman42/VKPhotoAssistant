using CommandLine;

namespace VKPhotoAssistant.Utilities.VKToken.Options
{
    internal class ApplyTokenOptions
    {
        [Value(0, Default = null, Required = true)]
        public int Index { get; set; }
    }
}
