﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VKPhotoAssistant.Commands;
using VKPhotoAssistant.Interfaces.Utility;

namespace VKPhotoAssistant
{
    public class Main : IUtility
    {
        #region Var
        public string Name => "VKPhotoAssistant";
        #endregion

        #region Methods
        public async Task DefineCommandAsync(string commandName, IEnumerable<string> args) => await new Help().ExecuteAsync(args);
        #endregion
    }
}
