using System;
using System.Collections.Generic;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Base;

namespace VKPhotoAssistant.Utilities.Album
{
    public class Main : BaseUtilityRouter<Main>, IUtility
    {
        #region Var
        public string Name { get; } = "Album";

        public string HelpMessage { get; } = "album get --index | Получить информацию по всем альбомам или альбому \n" +
            "album download [albumId] --limit --offset | Начать скачивание альбома в локальную папку";
        #endregion

        #region Action
        public void DefineCommand(string commandName, IEnumerable<string> args)
        {
            if (commandName == "--help")
            {
                Console.WriteLine(HelpMessage);
                return;
            }

            ICommand command = TryCallCommand(commandName);
            if (command is { })
                command.ExecuteAsync(args);
        }
        #endregion
    }
}
