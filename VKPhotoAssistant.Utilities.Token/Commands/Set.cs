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
            MainStorage storage = Storage.Read();

            if (options.TokenIndex is { })
            {
                storage.VKTokens.ToList().Add(options.TokenValue);
                Storage.Write(storage);
            }
            else storage.VKTokens.ToList()[(int)options.TokenIndex] = options.TokenValue;

            return Task.CompletedTask;
        }
        #endregion
    }
}
