using System;
using VKPhotoAssistant.Tools.Storage;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace VKPhotoAssistant.Utilities
{
    public class HelpUtility : ICommand
    {
        public string Name => "Help";

        public string Help => "test";

        public async Task Execute(IEnumerable<string> args)
        {
            Console.WriteLine("okey bho");
        }
    }
}
