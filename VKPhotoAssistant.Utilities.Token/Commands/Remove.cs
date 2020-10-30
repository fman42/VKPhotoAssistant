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
    internal class Remove : BaseCommandParser<RemoveTokenOptions>, ICommand
    {
        #region Vars
        private JsonStorage Storage { get; }
        #endregion

        #region Init
        public Remove() => Storage = new JsonStorage();
        #endregion

        #region Methods
        public void ExecuteAsync(IEnumerable<string> args) => TryParseAsync(args, Action);

        private Task Action(RemoveTokenOptions options)
        {
            MainStorage storage = Storage.Read();

            if (storage.VKTokens.Count() >= options.Index)
            {
                storage.VKTokens.ToList().RemoveAt(options.Index);
                Storage.Write(storage);

                Console.WriteLine($"Токен с индексом {options.Index} был удален из хранилища");
            }
            else Console.WriteLine("Такой токен не существует");

            return Task.CompletedTask;
        }
        #endregion
    }
}
