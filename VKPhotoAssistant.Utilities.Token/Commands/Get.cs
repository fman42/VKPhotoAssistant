using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKPhotoAssistant.Interfaces.Storage;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Storage;
using VKPhotoAssistant.Utilities.Base;
using VKPhotoAssistant.Utilities.VKToken.Options;

namespace VKPhotoAssistant.Utilities.VKToken.Commands
{
    internal class Get : BaseCommandParser<GetTokenOptions>, ICommand
    {
        #region Vars
        private MainStorage Storage { get; }
        #endregion

        #region Init
        public Get() => Storage = JsonStorage.GetInstance().Read();
        #endregion

        #region Methods
        public void ExecuteAsync(IEnumerable<string> args) => TryParseAsync(args, Action);

        private Task Action(GetTokenOptions options)
        {
            if (options.Index is { })
                GetTokenByIndex((int)options.Index);
            else GetAllTokens();

            return Task.CompletedTask;
        }

        private void GetAllTokens()
        {
            for (int i = 0; i < Storage.VKTokens.Count(); i++)
            {
                string storageRow = $"{i}: {Storage.VKTokens[i]}";

                if (Storage.VKTokens[i] == Storage.CurrentVKToken)
                    Console.WriteLine($"{storageRow} <-- Установлен как основной");
                else
                    Console.WriteLine(storageRow);
            }
        }

        private void GetTokenByIndex(int index)
        {
            if (Storage.VKTokens.Count() >= index)
                Console.WriteLine(Storage.VKTokens[index]);

            else Console.WriteLine("Токен не найден");
        }
        #endregion
    }
}
