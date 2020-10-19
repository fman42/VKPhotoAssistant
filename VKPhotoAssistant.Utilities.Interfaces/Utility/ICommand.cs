using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace VKPhotoAssistant.Interfaces.Utility
{
    public interface ICommand
    {
        Task ExecuteAsync(IEnumerable<string> args, IConfiguration configuration);
    }
}
