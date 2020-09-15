using CommandLine;

namespace VKPhotoAssistant.Utilities.VKToken.Options
{
    internal class RemoveTokenOptions
    {
        [Value(0, Required = true)]
        public int Index { get; set; }
    }
}
