using System.Collections.Generic;
using System.Threading.Tasks;

namespace VKPhotoAssistant.Utilities
{
    public interface ICommand
    {
        string Name { get; }

        string Help { get; }

        Task Execute(IEnumerable<string> args);
    }
}
