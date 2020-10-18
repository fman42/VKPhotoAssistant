using VKPhotoAssistant.Interfaces.Utility;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace VKPhotoAssistant.Utilities.Base
{
    public class BaseUtilityRouter<T> where T : IUtility
    {
        #region Var
        private const string CommandNameSpaceFragment = "Commands";
        #endregion

        #region Methods
        protected ICommand TryCallCommand(string command)
        {
            var x = Assembly.GetCallingAssembly().GetTypes();
            
            Type? commandClassName = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(x => command.Equals(x.Name, StringComparison.CurrentCultureIgnoreCase)
                   && x.Namespace.Contains(CommandNameSpaceFragment)
                );

            if (commandClassName is null)
                return null;

            return (ICommand) Activator.CreateInstance(commandClassName);
        }
        #endregion
    }
}
