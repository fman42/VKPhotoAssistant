using CommandLine;

namespace VKPhotoAssistant.Options
{
    public class TokenOptions
    {
        [Option('s', "set", Required = false, HelpText = "Set a new token from VK in local storage")]
        public string SetToken { get; set; }

        [Option(longName: "set-index", Required = false, HelpText = "Rewrite existed tolen in local storage")]
        public int? SetTokenIndex { get; set; }

        [Option('g', "get", Required = false, Default = false, HelpText = "Get all tokens from local storage")]
        public bool GetTokens { get; set; }

        [Option(longName: "get-index", Required = false, HelpText = "Get token with a specified index from local storage")]
        public int? GetTokenIndex { get; set; }

        [Option('c', "clear", Required = false, HelpText = "Clear all storage")]
        public bool ClearStorage { get; set; }

        [Option('r', "remove", Required = false, HelpText = "Remove token with specified token in local storage")]
        public int? RemoveTokenIndex { get; set; }
    }
}
