using System.Threading.Tasks;
using System.Collections.Generic;

namespace VKPhotoAssistant.Interfaces.Utility
{
    public interface ICommand
    {
        void ExecuteAsync(IEnumerable<string> args);
    }
}
