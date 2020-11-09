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
        private JsonStorage StorageInstance { get; }

        private MainStorage MainStorage { get; }
        #endregion

        #region Init
        public Set()
        {
            StorageInstance = JsonStorage.GetInstance();
            MainStorage = StorageInstance.Read();
        }
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

            if (MainStorage.VKTokens.IndexOf(token) != -1)
            {
                Console.WriteLine("Данный токен уже находится в хранилище");
                return Task.CompletedTask;
            }

            UpdateStorage(options.TokenIndex, token);
            return Task.CompletedTask;
        }

        private void UpdateStorage(int? index, string token)
        {
            if (index is { })
                MainStorage.VKTokens[(int)index] = token;
            else
                MainStorage.VKTokens.Add(token);

            StorageInstance.Write(MainStorage);
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
