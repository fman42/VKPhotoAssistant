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
    internal class Apply : BaseCommandParser<ApplyTokenOptions>, ICommand
    {
        #region Vars
        private JsonStorage Storage { get; }
        #endregion

        #region Init
        public Apply() => Storage = JsonStorage.GetInstance();
        #endregion

        #region Methods
        public void ExecuteAsync(IEnumerable<string> args) => TryParseAsync(args, Action);

        private Task Action(ApplyTokenOptions options)
        {
            MainStorage storage = Storage.Read();
            List<string> tokens = storage.VKTokens.ToList();

            if (tokens.Count() >= options.Index)
            {
                storage.CurrentVKToken = tokens[options.Index];
                Storage.Write(storage);
                Console.WriteLine("Вы успешно применили токен в хранилище");
            }
            else Console.WriteLine("Токен в хранилище не найден");

            return Task.CompletedTask;
        }
        #endregion
    }
}
