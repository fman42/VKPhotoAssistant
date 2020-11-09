using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;
using VKPhotoAssistant.Interfaces.Storage;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Storage;
using VKPhotoAssistant.Utilities.Base;
using VKPhotoAssistant.Utilities.VKToken.Options;

namespace VKPhotoAssistant.Utilities.VKToken.Commands
{
    internal class Set : BaseCommandParser<SetTokenOptions>, ICommand
    {
        #region Vars
        private JsonStorage Storage { get; }
        #endregion

        #region Init
        public Set() => Storage = JsonStorage.GetInstance();
        #endregion

        #region Methods
        public void ExecuteAsync(IEnumerable<string> args) => TryParseAsync(args, SetValueToToken);

        private Task SetValueToToken(SetTokenOptions options)
        {
            string token = ParseToken(options.TokenValue);
            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("Вы ввели неверный токен");
                return Task.CompletedTask;
            }

            UpdateStorage(options.TokenIndex, token);
            return Task.CompletedTask;
        }

        private void UpdateStorage(int? index, string token)
        {
            MainStorage storage = Storage.Read();

            if (index is { })
                storage.VKTokens[(int)index] = token;
            else
                storage.VKTokens.Add(token);

            Storage.Write(storage);
        }

        private static string ParseToken(string token)
        {
            if (token.Length == 85)
                return token;

            NameValueCollection queryParamsCollection = HttpUtility.ParseQueryString(token);
            if (queryParamsCollection.Count == 0)
                return null;

            return queryParamsCollection[0].TrimStart('#');
        }
        #endregion
    }
}
