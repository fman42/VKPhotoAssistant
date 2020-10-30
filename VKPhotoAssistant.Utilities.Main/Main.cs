using System;
using System.Collections.Generic;
using VKPhotoAssistant.Interfaces.Utility;

namespace VKPhotoAssistant.Utilities.Main
{
    public class Main : IUtility
    {
        #region Var
        public string Name => "VKPhotoAssistant";

        public string HelpMessage => "vk --help | Получить информацию по работе с хранилищем токенов \n" +
            "album --help | Получить информацию по работе с альбомами ВК";
        #endregion

        #region Methods
        public void DefineCommand(string commandName, IEnumerable<string> args) => Console.WriteLine(HelpMessage);
        #endregion
    }
}
