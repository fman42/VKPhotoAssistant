using CommandLine;

namespace VKPhotoAssistant.Utilities.Main.Options
{
    public class HelpTokenOptions
    {
        [Value(0, HelpText = "Установить или получить токен ВК из хранилища")]
        public bool VK { get; set; }

        [Value(1, HelpText = "Работа с альбомом ВК")]
        public bool VKAlbum { get; set; }
    }
}
