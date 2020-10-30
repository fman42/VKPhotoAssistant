using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Base;
using VKPhotoAssistant.Utilities.VKToken.Options;
using VKPhotoAssistant.Utilities.VKToken.Tools.Storage;

namespace VKPhotoAssistant.Utilities.VKToken.Commands
{
    internal class Apply : BaseCommandParser<ApplyTokenOptions>, ICommand
    {
        #region Vars
        private TokenStorage Storage { get; }
        #endregion

        #region Init
        public Apply() => Storage = new TokenStorage();
        #endregion

        #region Methods
        public async Task ExecuteAsync(IEnumerable<string> args) => TryParseAsync(args,
            async (options) => {
                string fileIndexToName = $"{options.Index}";
                if (Storage.FileExists(fileIndexToName))
                {
                    //configuration["VKToken"] = await Storage.ReadFileAsync(fileIndexToName);
                    Console.WriteLine("Вы успешно применили токен в хранилище");
                }
                else Console.WriteLine("Токен в хранилище не найден");
            }
        );
        #endregion
    }
}
