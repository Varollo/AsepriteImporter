using Newtonsoft.Json;
using System.IO;

namespace Varollo.AsepriteImporter
{
    /// <summary>
    /// Loads JSON data generated from a Aseprite Sprite Sheet
    /// </summary>
    public static class AsepriteDataLoader
    {
        /// <summary>
        /// Parses JSON data into a a <see cref="AsepriteSheet"/> object.
        /// </summary>
        /// <param name="json"> String containing JSON data to be parsed into a <see cref="AsepriteSheet"/> object. </param>
        /// <returns></returns>
        public static AsepriteSheet ParseJsonData(string json)
        {
            return JsonConvert.DeserializeObject<AsepriteSheet>(json);
        }

        /// <summary>
        /// Loads a JSON file at <paramref name="path"/> and parses it into a <see cref="AsepriteSheet"/> object.
        /// </summary>
        /// <param name="path"> String containing the path to the JSON file generated with a Aseprite Sprite Sheet. </param>
        /// <returns> Parsed JSON data. </returns>
        public static AsepriteSheet LoadJsonData(string path)
        {
            using var stream = new FileStream(path, FileMode.Open);
            using var reader = new StreamReader(stream);

            string json = reader.ReadToEnd();

            return ParseJsonData(json);
        }
    }
}
