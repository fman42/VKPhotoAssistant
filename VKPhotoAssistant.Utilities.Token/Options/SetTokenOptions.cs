using CommandLine;

namespace VKPhotoAssistant.Utilities.VKToken.Options
{
    internal class SetTokenOptions
    {
        [Option('i', "index", Required = false)]
        public int? TokenIndex { get; set; }

        [Value(0, Required = true)]
        public string TokenValue { get; set; }
    }
}
