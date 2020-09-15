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
    internal class Get : BaseCommandParser<GetTokenOptions>, ICommand
    {
        #region Vars
        public string HelpMessage => "vktoken get <file index>";

        private TokenStorage Storage { get; }
        #endregion

        #region Init
        public Get() => Storage = new TokenStorage();
        #endregion

        #region Methods
        public async Task ExecuteAsync(IEnumerable<string> args) => TryParseAsync(args,
            async (options) => {
                if (options.Index is { })
                    await GetTokenByIndex(options.Index);
                else await GetAllTokens();
            },
            async (IEnumerable<Error> errors) => Console.WriteLine(HelpMessage)
        );

        private async Task GetAllTokens()
        {
            foreach (string filename in Storage.GetStorageFiles())
                Console.WriteLine(await Storage.ReadFileAsync($"{filename}"));
        }

        private async Task GetTokenByIndex(int fileIndex)
        {
            string fileIndexToName = $"{fileIndex}";
            if (Storage.FileExists(fileIndexToName))
                Console.WriteLine(await Storage.ReadFileAsync($"{fileIndexToName}"));

            else Console.WriteLine("Данный файл не существует");
        }
        #endregion
    }
}
