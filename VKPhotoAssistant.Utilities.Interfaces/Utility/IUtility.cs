using System.Collections.Generic;

namespace VKPhotoAssistant.Interfaces.Utility
{
    public interface IUtility
    {
        string Name { get; }

        string HelpMessage { get; }

        void DefineCommand(string commandName, IEnumerable<string> args);
    }
}
