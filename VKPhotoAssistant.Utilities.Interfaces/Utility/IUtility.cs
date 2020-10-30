using System.Threading.Tasks;
using System.Collections.Generic;

namespace VKPhotoAssistant.Interfaces.Utility
{
    public interface IUtility
    {
        string Name { get; }

        void DefineCommand(string commandName, IEnumerable<string> args);
    }
}
