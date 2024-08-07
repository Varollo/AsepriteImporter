using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;

namespace Varollo.AsepriteImporter.Serialization.Converters
{
    internal class SizeToPointConverter : ObjectConverterBase<Point>
    {
        protected const string W_PROP_NAME = "w";
        protected const string H_PROP_NAME = "h";

        public override Point ReadJson(JsonReader reader, Type objectType, Point existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject obj = serializer.Deserialize<JObject>(reader);

            int x = GetPropertyValue<int>(obj, W_PROP_NAME);
            int y = GetPropertyValue<int>(obj, H_PROP_NAME);

            return new(x, y);
        }

        protected override void WriteProperties(JsonWriter writer, Point value)
        {
            writer.WritePropertyName(W_PROP_NAME);
            writer.WriteValue(value.X);

            writer.WritePropertyName(H_PROP_NAME);
            writer.WriteValue(value.Y);
        }
    }
}