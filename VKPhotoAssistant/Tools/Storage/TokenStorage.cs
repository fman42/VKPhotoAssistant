using System;
using System.IO;
using System.Threading.Tasks;

namespace VKPhotoAssistant.Tools.Storage
{
    public class TokenStorage : BaseStorage<string>
    {
        #region Var
        protected override string StorageName { get; } = "Token";
        #endregion

        #region Init
        public TokenStorage() => TryCreateStorage();
        #endregion

        #region Methods
        public override async Task<string> ReadFileAsync(string filename)
        {
            using (StreamReader reader = new StreamReader(GetFilePath(filename)))
                return await reader.ReadToEndAsync();
        }

        public override async Task WriteValueInFileAsync(string filename, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("value is null");

            string filePath = GetFilePath(filename);
            if (File.Exists(GetFilePath(filePath)))
                File.Create(filePath);

            using (StreamWriter writer = new StreamWriter(filePath))
                await writer.WriteAsync(value);
        }
        #endregion
    }
}
