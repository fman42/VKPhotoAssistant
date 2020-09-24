using CommandLine;

namespace VKPhotoAssistant.Utilities.VKToken.Options
{
    internal class SetTokenOptions
    {
        [Option('i', "index", Required = false, HelpText = "Уствновить индекс, где изменить токен")]
        public int? TokenIndex { get; set; }

        [Value(0, Required = true, HelpText = "Значение токена")]
        public string TokenValue { get; set; }
    }
}
