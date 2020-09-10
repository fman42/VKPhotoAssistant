using System;
using VKPhotoAssistant.Tools.Storage;
using System.Threading.Tasks;
using System.Collections.Generic;
using VKPhotoAssistant.Options;
using CommandLine;

namespace VKPhotoAssistant.Utilities
{
    public class TokenUtility : ICommand
    {
        #region Var
        public string Name => "Token";

        public string Help => "token [--get|--set] [value]";

        private TokenStorage Storage { get; }

        private ParserResult<TokenOptions> Options { get; set; }
        #endregion

        #region Init
        public TokenUtility() => Storage = new TokenStorage();
        #endregion

        #region Methods
        public async Task Execute(IEnumerable<string> args)
        {
            Options = Parser.Default.ParseArguments<TokenOptions>(args);
            Options.WithParsed(async (TokenOptions obj) =>
            {
                // bruh, i'll rewrite these lines
                if (obj.SetToken is { } && obj.SetTokenIndex is null)
                    await Set(obj.SetToken);
                else if (obj.SetToken is { } && obj.SetTokenIndex is { })
                    await Set((int)obj.SetTokenIndex, obj.SetToken);
                else if (obj.GetTokens == true)
                    await Get();
                else if (obj.GetTokenIndex is { })
                    await Get((int)obj.GetTokenIndex);
                else if (obj.ClearStorage == true)
                    Clear();
                else if (obj.RemoveTokenIndex is { })
                    Remove((int)obj.RemoveTokenIndex);
                else Console.WriteLine(Help);
            });
        }

        private async Task Set(int index, string key) => await Storage.WriteValueInFileAsync($"{index}", key);

        private async Task Set(string key) => await Set(Storage.GetStorageFiles().Count, key);

        private async Task Get()
        {
            foreach (string file in Storage.GetStorageFiles())
                Console.WriteLine($"{file} {await Storage.ReadFileAsync(file)}");
        }

        private async Task Get(int index)
        {
            if (!Storage.FileExists($"{index}"))
            {
                Console.WriteLine($"Token with index {index} is not found in local storage");
                return;
            }

            Console.WriteLine($"{await Storage.ReadFileAsync($"{index}")}");
        }

        private void Remove(int index)
        {
            if (!Storage.FileExists($"{index}"))
            {
                Console.WriteLine($"Token with index {index} is not found in local storage");
                return;
            }

            Storage.DeleteFile($"{index}");
        }

        private void Clear()
        {
            foreach (string file in Storage.GetStorageFiles())
                Storage.DeleteFile(file);
        }
        #endregion
    }
}
