using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandLine;

namespace VKPhotoAssistant.Utilities.Base
{
    public class BaseCommandParser<T> where T : class
    {
        public void TryParseAsync(IEnumerable<string> args, Func<T, Task> success, Func<IEnumerable<Error>, Task> error = null)
        {
            ParserResult<T> result = Parser.Default.ParseArguments<T>(args);
            result.WithParsedAsync(success);
            result.WithNotParsedAsync(error);
        }
    }
}
