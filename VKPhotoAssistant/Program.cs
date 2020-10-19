using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VKPhotoAssistant.Interfaces.Utility;
using MainUtility = VKPhotoAssistant.Utilities.Main;

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
            IConfiguration configuration = InitConfigurationFile();

            if (args.Length < 2 || !UtilitiesDictionary.ContainsKey(args[0]))
            {
                await new MainUtility.Main().DefineCommandAsync("Help", args);
                return;
            }

            IUtility utility = (IUtility) Activator.CreateInstance(UtilitiesDictionary[args[0]], configuration);
            await utility.DefineCommandAsync(args[1], args.Skip(2));
        }

        private static IConfiguration InitConfigurationFile()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
        #endregion
    }
}
