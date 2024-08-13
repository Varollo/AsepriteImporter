using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Varollo.AsepriteImporter.Serialization.Converters
{
    internal abstract class ObjectConverterBase<TResult> : JsonConverter<TResult>
    {
        public override void WriteJson(JsonWriter writer, TResult value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            WriteProperties(writer, value);
            writer.WriteEndObject();
        }

        protected static T GetPropertyValue<T>(JObject obj, string propName) where T : IConvertible
        {
            return (T)Convert.ChangeType(obj[propName].ToString(), typeof(T));
        }

        protected abstract void WriteProperties(JsonWriter writer, TResult value);
    }
}