﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKPhotoAssistant.Interfaces.Utility;
using VKPhotoAssistant.Storage;
using VKPhotoAssistant.Interfaces.Storage;
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
            JsonStorage storage = JsonStorage.GetInstance();
            if (!storage.Exists())
                storage.Write(new MainStorage());

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
