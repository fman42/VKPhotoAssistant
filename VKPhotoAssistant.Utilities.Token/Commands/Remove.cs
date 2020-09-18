using System;
using CommandLine;
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
        public string HelpMessage => "vktoken remove <file index>";

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
                } else {
                    Console.WriteLine("Данный файл не существует");
                }
            }
        );
        #endregion
    }
}
