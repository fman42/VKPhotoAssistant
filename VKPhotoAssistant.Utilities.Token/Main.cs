using System;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Base;
using System.Collections.Generic;

namespace VKPhotoAssistant.Utilities.VKToken
{
    public class Main : BaseUtilityRouter<Main>, IUtility
    {
        #region Var
        public string Name { get; } = "VKToken";

        public string HelpMessage { get; } = "vk set [value] | Установить токен в локальное хранилище\n" +
            "vk get --index [value] | Получить все токены или токен из хранилища по ключу\n" +
            "vk remove [index] | Удалить токен из хранилища\n" +
            "vk apply [value] | Установить токен как основной";
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
