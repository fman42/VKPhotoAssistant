using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Base;
using System.Collections.Generic;

namespace VKPhotoAssistant.Utilities.VKToken
{
    public class Main : BaseUtilityRouter<Main>, IUtility
    {
        #region Var
        public string Name { get; } = "VKToken";
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
