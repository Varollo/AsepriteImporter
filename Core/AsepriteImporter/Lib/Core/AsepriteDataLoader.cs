using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Varollo.AsepriteImporter.Serialization;

namespace Varollo.AsepriteImporter
{
    public static class AsepriteDataLoader
    {
        public static AsepriteSheet ParseJsonData(string json)
        {
            SerializedSheetData data = JsonConvert.DeserializeObject<SerializedSheetData>(json);

            MetaData? meta = data.Meta.HasValue ? new(data.Meta.Value) : null;
            AsepriteFrame[] frames = data.Frames.Select(frame => new AsepriteFrame(frame)).ToArray();

            return new(frames, meta);
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
