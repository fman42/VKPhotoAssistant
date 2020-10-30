using System.Collections.Generic;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Base;

namespace VKPhotoAssistant.Utilities.Album
{
    public class Main : BaseUtilityRouter<Main>, IUtility
    {
        #region Var
        public string Name { get; } = "Album";
        #endregion

        #region Action
        public void DefineCommand(string commandName, IEnumerable<string> args)
        {
            ICommand command = TryCallCommand(commandName);
            if (command is { })
                command.ExecuteAsync(args);
        }
        #endregion
    }
}
