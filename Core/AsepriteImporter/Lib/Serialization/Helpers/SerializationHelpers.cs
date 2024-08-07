using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Varollo.AsepriteImporter.Serialization
{
    internal static class SerializationHelpers
    {
        internal static readonly JsonSerializerSettings SerializerSettings = new()
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        internal class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(int) || t == typeof(int?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);

                if (int.TryParse(value, out int l))
                    return l;

                throw new Exception("Cannot unmarshal type int");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (int)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            internal static readonly ParseStringConverter Singleton = new();
        }
    }    
}
