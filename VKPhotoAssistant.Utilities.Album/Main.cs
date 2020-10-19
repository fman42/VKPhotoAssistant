using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Base;

namespace VKPhotoAssistant.Utilities.Album
{
    public class Main : BaseUtilityRouter<Main>, IUtility
    {
        #region Var
        public string Name { get; } = "Album";

        private IConfiguration Configuration { get; }
        #endregion

        #region Init
        public Main(IConfiguration configuration) => Configuration = configuration;
        #endregion

        #region Action
        public async Task DefineCommandAsync(string commandName, IEnumerable<string> args)
        {
            ICommand command = TryCallCommand(commandName);
            if (command is { })
                await command.ExecuteAsync(args, Configuration);
        }
        #endregion
    }
}
