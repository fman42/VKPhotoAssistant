using System.Threading.Tasks;
using System.Collections.Generic;

namespace VKPhotoAssistant.Interfaces.Utility
{
    public interface ICommand
    {
        Task ExecuteAsync(IEnumerable<string> args);
    }
}
