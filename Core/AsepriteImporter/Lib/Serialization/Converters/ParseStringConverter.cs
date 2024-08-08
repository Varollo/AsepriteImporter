using Newtonsoft.Json;
using System;

namespace Varollo.AsepriteImporter.Serialization.Converters
{
    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(int) || t == typeof(int?) || t == typeof(double) || t == typeof(double?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);

            if (int.TryParse(value, out int l))
                return l;

            if (double.TryParse(value, out double d))
                return d;

            int comma = value.IndexOf(',');
            value = value.Remove(comma, 1);
            value = value.Insert(comma, ".");

            if (double.TryParse(value, out d))
                return d;

            throw new Exception("Cannot unmarshal type int or double");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            if (untypedValue is int i)
                serializer.Serialize(writer, i.ToString());

            else if (untypedValue is double d)
                serializer.Serialize(writer, d.ToString(System.Globalization.CultureInfo.InvariantCulture));

            return;
        }

        internal static readonly ParseStringConverter Singleton = new();
    }
}
