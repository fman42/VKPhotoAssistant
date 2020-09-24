using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Base;
using VKPhotoAssistant.Utilities.VKToken.Options;
using VKPhotoAssistant.Utilities.VKToken.Tools.Storage;

namespace VKPhotoAssistant.Utilities.VKToken.Commands
{
    internal class Remove : BaseCommandParser<RemoveTokenOptions>, ICommand
    {
        #region Vars
        private TokenStorage Storage { get; }
        #endregion

        #region Init
        public Remove() => Storage = new TokenStorage();
        #endregion

        #region Methods
        public async Task ExecuteAsync(IEnumerable<string> args) => TryParseAsync(args,
            async (options) => {
                string fileIndexToName = $"{options.Index}";

                if (Storage.FileExists(fileIndexToName))
                {
                    Storage.DeleteFile(fileIndexToName);
                    Console.WriteLine($"Токен с индексом {options.Index} был удален из хранилища");
                } else {
                    Console.WriteLine("Такой токен не существует");
                }
            }
        );
        #endregion
    }
}
