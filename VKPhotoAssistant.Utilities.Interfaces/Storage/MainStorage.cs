using System.Collections.Generic;

namespace VKPhotoAssistant.Interfaces.Storage
{
    public class MainStorage
    {
        public string CurrentVKToken { get; set; } = string.Empty;

        public List<string> VKTokens { get; set; } = new List<string>();
    }
}
