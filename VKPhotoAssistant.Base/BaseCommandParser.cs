using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace VKPhotoAssistant.Utilities.Base
{
    public class BaseCommandParser<T> where T : class
    {
        public void TryParseAsync(IEnumerable<string> args, Func<T, Task> success)
        {
            ParserResult<T> result = Parser.Default.ParseArguments<T>(args);
            result.WithParsedAsync(success);
            result.WithNotParsed((IEnumerable<Error> errors) => DisplayHelp(result, errors));
        }

        private void DisplayHelp(ParserResult<T> result, IEnumerable<Error> errors)
        {
            HelpText helpText = HelpText.AutoBuild(result, h =>
            {
                h.AdditionalNewLineAfterOption = false;
                h.AutoVersion = false;
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e);

            Console.WriteLine(helpText);
        }
    }
}
