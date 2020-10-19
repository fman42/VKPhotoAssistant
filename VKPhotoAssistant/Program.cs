using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VKPhotoAssistant.Interfaces.Utility;
using MainUtility = VKPhotoAssistant.Utilities.Main;
using System.Linq;

namespace VKPhotoAssistant
{
    public class Program
    {
        #region Var
        private static Dictionary<string, Type> UtilitiesDictionary => new Dictionary<string, Type>(StringComparer.InvariantCultureIgnoreCase)
        {
            { "vk", typeof(Utilities.VKToken.Main)},
            { "album", typeof(Utilities.Album.Main) }
        };
        #endregion

        #region Entry Point
        static async Task Main(string[] args)
        {
            args = new string[] { "album", "download", "271683977" };
            if (args.Length < 2 || !UtilitiesDictionary.ContainsKey(args[0]))
            {
                await new MainUtility.Main().DefineCommandAsync("Help", args);
                return;
            }

            IUtility utility = (IUtility) Activator.CreateInstance(UtilitiesDictionary[args[0]]);
            await utility.DefineCommandAsync(args[1], args.Skip(2));
        }
        #endregion
    }
}
