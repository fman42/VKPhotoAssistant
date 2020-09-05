using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VKPhotoAssistant.Tools.Storage
{
    public abstract class BaseStorage<TValue>
    {
        #region Var
        private const string BasePath = "storage";

        private const string Extension = "storage";

        private HashSet<string> HiddenFiles { get; } = new HashSet<string>() { ".DS_Store" };

        protected abstract string StorageName { get; }
        #endregion

        #region Public Methods
        public IReadOnlyCollection<string> GetStorageFiles()
        {
            if (string.IsNullOrEmpty(StorageName))
                throw new NullReferenceException("Variable StorageName is null");

            if (!Directory.Exists(GetDirectoryPath()))
                return new string[] { };

            return Directory.GetFiles(GetDirectoryPath())
                .Where(x => !HiddenFiles.Contains(Path.GetFileName(x)))
                .ToList()
                .AsReadOnly();
        }

        public void FlushStorage()
        {
            foreach (string filename in GetStorageFiles())
                File.Delete(filename);
        }

        public void DeleteFile(string filename)
        {
            if (File.Exists(GetFilePath(filename)))
            {
                File.Delete(filename);
            }
        }

        public abstract Task<TValue> ReadFileAsync(string filename);

        public abstract Task WriteValueInFileAsync(string filename, TValue value);
        #endregion

        #region Protected methods
        protected void TryCreateStorage()
        {
            string directoryPath = GetDirectoryPath();

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }

        protected string GetFilePath(string filename) => $"{BasePath}/{StorageName}/{filename}.{Extension}".ToLower();
        #endregion

        #region Private methods
        private string GetDirectoryPath() => $"{BasePath}/{StorageName}".ToLower();
        #endregion
    }
}
