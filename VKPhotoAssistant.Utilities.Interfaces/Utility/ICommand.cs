using System.Threading.Tasks;
using System.Collections.Generic;

namespace VKPhotoAssistant.Interfaces.Utility
{
    public interface ICommand
    {
        string HelpMessage { get; }

        Task ExecuteAsync(IEnumerable<string> args);
    }
}
