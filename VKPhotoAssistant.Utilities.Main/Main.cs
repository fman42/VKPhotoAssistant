using System.Collections.Generic;
using VKPhotoAssistant.Utilities.Main.Commands;
using VKPhotoAssistant.Interfaces.Utility;

namespace VKPhotoAssistant.Utilities.Main
{
    public class Main : IUtility
    {
        #region Var
        public string Name => "VKPhotoAssistant";
        #endregion

        #region Methods
        public void DefineCommand(string commandName, IEnumerable<string> args) => new Help().ExecuteAsync(args);
        #endregion
    }
}
