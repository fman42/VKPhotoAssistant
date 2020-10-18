using VKPhotoAssistant.Interfaces.Utility;
using System.Threading.Tasks;
using System.Collections.Generic;
using VKPhotoAssistant.Utilities.Base;
using VKPhotoAssistant.Options;

namespace VKPhotoAssistant.Commands
{
    public class Help : BaseCommandParser<HelpTokenOptions>, ICommand
    {
        public async Task ExecuteAsync(IEnumerable<string> args) => TryParseAsync(args, null);
    }
}
