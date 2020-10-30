using System.IO;
using Newtonsoft.Json;
using VKPhotoAssistant.Interfaces.Storage;

namespace VKPhotoAssistant.Storage
{
    public class JsonStorage
    {
        private static JsonStorage instance;

        const string JSON_STORAGE_NAME = "storage.json";

        public MainStorage Read()
        {
            if (!File.Exists(JSON_STORAGE_NAME))
                return default;

            using (StreamReader reader = new StreamReader(JSON_STORAGE_NAME))
                return JsonConvert.DeserializeObject<MainStorage>(reader.ReadToEnd());
        }

        public void Write(MainStorage body)
        {
            string bodyToJson = JsonConvert.SerializeObject(body);
            File.Create(JSON_STORAGE_NAME);

            using (StreamWriter writer = new StreamWriter(JSON_STORAGE_NAME))
                writer.Write(bodyToJson);
        }

        public bool Exists() => File.Exists(JSON_STORAGE_NAME);

        public static JsonStorage GetInstance()
        {
            if (instance is null)
                instance = new JsonStorage();

            return instance;
        }
    }
}
