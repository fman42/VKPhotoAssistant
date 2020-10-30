using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Storage;
using VKPhotoAssistant.Utilities.Base;
using VKPhotoAssistant.Utilities.VKToken.Options;

namespace VKPhotoAssistant.Utilities.VKToken.Commands
{
    internal class Get : BaseCommandParser<GetTokenOptions>, ICommand
    {
        #region Vars
        private JsonStorage Storage { get; }
        #endregion

        #region Init
        public Get() => Storage = JsonStorage.GetInstance();
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
            List<string> tokens = Storage.Read().VKTokens.ToList();
            for (int i = 0; i < tokens.Count(); i++)
                Console.WriteLine($"{i}: " + $"{tokens[i]}");
        }

        private void GetTokenByIndex(int index)
        {
            List<string> tokens = Storage.Read().VKTokens.ToList();
            if (tokens.Count() >= index)
                Console.WriteLine(tokens[index]);

            else Console.WriteLine("Токен не найден");
        }
        #endregion
    }
}
