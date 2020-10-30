using System.Collections.Generic;
using System.Linq;

namespace VKPhotoAssistant.Interfaces.Storage
{
    public class MainStorage
    {
        public string CurrentVKToken { get; set; } = string.Empty;

        public IEnumerable<string> VKTokens { get; set; } = Enumerable.Empty<string>();
    }
}
