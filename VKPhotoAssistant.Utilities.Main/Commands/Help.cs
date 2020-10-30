using VKPhotoAssistant.Interfaces.Utility;
using System.Collections.Generic;
using VKPhotoAssistant.Utilities.Base;
using VKPhotoAssistant.Utilities.Main.Options;

namespace VKPhotoAssistant.Utilities.Main.Commands
{
    public class Help : BaseCommandParser<HelpTokenOptions>, ICommand
    {
        public void ExecuteAsync(IEnumerable<string> args)
            => TryParseAsync(args, null);
    }
}
