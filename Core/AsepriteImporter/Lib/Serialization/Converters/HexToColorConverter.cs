using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Varollo.AsepriteImporter.Serialization.Converters
{
    internal class HexToColorConverter : JsonConverter<Color>
    {
        private readonly ColorConverter _converter = new();

        public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var hex = reader.Value.ToString();
            var col = (Color)_converter.ConvertFromString(hex);

            return col;
        }

        public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
        {
            writer.WritePropertyName("color");
            writer.WriteValue(_converter.ConvertToString(value)); // not sure if'd work, but we don't serialize the data anyway.
        }
    }
}