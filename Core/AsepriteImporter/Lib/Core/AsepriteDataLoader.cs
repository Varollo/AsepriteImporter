using Newtonsoft.Json;
using System.IO;

namespace Varollo.AsepriteImporter
{
    public static class AsepriteDataLoader
    {
        public static AsepriteSheet ParseJsonData(string json)
        {
            return JsonConvert.DeserializeObject<AsepriteSheet>(json);
        }

        public static AsepriteSheet LoadJsonData(string path)
        {
            using FileStream stream = new(path, FileMode.Open);
            using StreamReader reader = new(stream);

            string json = reader.ReadToEnd();

            return ParseJsonData(json);
        }
    }
}
