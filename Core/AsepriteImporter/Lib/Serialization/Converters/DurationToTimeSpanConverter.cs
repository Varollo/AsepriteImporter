using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Varollo.AsepriteImporter.Serialization.Converters
{
    internal class DurationToTimeSpanConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return TimeSpan.FromMilliseconds((long)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WritePropertyName("duration");
            writer.WriteValue(((TimeSpan)value).Milliseconds);
        }
    }
}