﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Utilities.Base;
using VKPhotoAssistant.Utilities.VKToken.Options;
using VKPhotoAssistant.Utilities.VKToken.Tools.Storage;
using Microsoft.Extensions.Configuration;

namespace VKPhotoAssistant.Utilities.VKToken.Commands
{
    internal class Set : BaseCommandParser<SetTokenOptions>, ICommand
    {
        #region Vars
        private TokenStorage Storage { get; }
        #endregion

        #region Init
        public Set() => Storage = new TokenStorage();
        #endregion

        #region Methods
        public async Task ExecuteAsync(IEnumerable<string> args, IConfiguration configuration) => TryParseAsync(args, SetValueToToken);

        private async Task SetValueToToken(SetTokenOptions options)
        {
            if (options.TokenIndex is { })
                await Storage.WriteValueInFileAsync($"{options.TokenIndex}", options.TokenValue);
            else await CreateNewToken(options.TokenValue);
        }

        private async Task CreateNewToken(string value)
        {
            int currentCountFiles = Storage.GetStorageFiles().Count;
            await Storage.WriteValueInFileAsync($"{currentCountFiles}", value);
        }
        #endregion
    }
}
