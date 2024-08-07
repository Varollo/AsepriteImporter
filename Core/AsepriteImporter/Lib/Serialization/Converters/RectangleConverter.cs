using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;

namespace Varollo.AsepriteImporter.Serialization.Converters
{
    internal class RectangleConverter : ObjectConverterBase<Rectangle>
    {
        private const string X_PROP_NAME = "x";
        private const string Y_PROP_NAME = "y";
        private const string W_PROP_NAME = "w";
        private const string H_PROP_NAME = "h";

        public override Rectangle ReadJson(JsonReader reader, Type objectType, Rectangle existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject obj = serializer.Deserialize<JObject>(reader);

            int x = GetPropertyValue<int>(obj, X_PROP_NAME);
            int y = GetPropertyValue<int>(obj, Y_PROP_NAME);
            int w = GetPropertyValue<int>(obj, W_PROP_NAME);
            int h = GetPropertyValue<int>(obj, H_PROP_NAME);

            return new Rectangle(x, y, w, h);
        }

        protected override void WriteProperties(JsonWriter writer, Rectangle value)
        {
            writer.WritePropertyName(W_PROP_NAME);
            writer.WriteValue(value.Width);

            writer.WritePropertyName(H_PROP_NAME);
            writer.WriteValue(value.Height);
        }
    }
}