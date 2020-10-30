using System;
using VKPhotoAssistant.Interfaces.Utility;
using System.Collections.Generic;
using VKPhotoAssistant.Utilities.Base;
using VKPhotoAssistant.Utilities.Main.Options;
using System.Threading.Tasks;

namespace VKPhotoAssistant.Utilities.Main.Commands
{
    public class Help : BaseCommandParser<HelpTokenOptions>, ICommand
    {
        #region Methods
        public void ExecuteAsync(IEnumerable<string> args)
            => TryParseAsync(args, Action);

        private Task Action(HelpTokenOptions options)
        {
            DrawUtilityInfo();
            return Task.CompletedTask;
        }

        private void DrawUtilityInfo()
        {
            Console.WriteLine("vk --help | Получить информацию по работе с хранилищем токенов");
            Console.WriteLine("album --help | Получить информацию по работе с альбомами ВК");
        }
        #endregion
    }
}
