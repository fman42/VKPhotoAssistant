using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VKPhotoAssistant.Utilities;

namespace VKPhotoAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cliCommandArgs = new string[]
            {
                "token", "--set", "it is my api key"
            };

            Type? enteredType = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterfaces().Contains(typeof(ICommand)))
                .FirstOrDefault(x => x.Name.Equals($"{cliCommandArgs[0]}Utility", StringComparison.InvariantCultureIgnoreCase));

            ICommand runUtility = enteredType is null ? new HelpUtility() : Activator.CreateInstance(enteredType) as ICommand;
        }
    }
}
