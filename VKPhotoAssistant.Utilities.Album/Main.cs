using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Base;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VKPhotoAssistant.Utilities.Album
{
    public class Main : BaseUtilityRouter<Main>, IUtility
    {
        public string Name { get; } = "Album";

        public async Task DefineCommandAsync(string commandName, IEnumerable<string> args)
        {
            ICommand command = TryCallCommand(commandName);
            if (command is { })
                await command.ExecuteAsync(args);
        }
    }
}
