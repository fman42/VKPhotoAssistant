using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VKPhotoAssistant.Utilities.VKToken
{
    public class Main : BaseUtilityRouter<Main>, IUtility
    {
        public string Name { get; } = "VKToken";

        public async Task DefineCommandAsync(string commandName, IEnumerable<string> args)
        {
            ICommand command = TryCallCommand(commandName);
            if (command is { })
                await command.ExecuteAsync(args);
        }
    }
}
