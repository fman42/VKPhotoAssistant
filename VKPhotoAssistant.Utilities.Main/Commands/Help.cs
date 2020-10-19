using VKPhotoAssistant.Interfaces.Utility;
using System.Threading.Tasks;
using System.Collections.Generic;
using VKPhotoAssistant.Utilities.Base;
using VKPhotoAssistant.Utilities.Main.Options;
using Microsoft.Extensions.Configuration;

namespace VKPhotoAssistant.Utilities.Main.Commands
{
    public class Help : BaseCommandParser<HelpTokenOptions>, ICommand
    {
        public async Task ExecuteAsync(IEnumerable<string> args, IConfiguration configuration)
            => TryParseAsync(args, null);
    }
}
