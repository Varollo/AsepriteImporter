using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Varollo.AsepriteImporter.Serialization.Converters
{
    internal class AnimationDirectionConverter : JsonConverter<AnimationDirection>
    {
        public override AnimationDirection ReadJson(JsonReader reader, Type objectType, AnimationDirection existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString() switch
            {
                "forward" => AnimationDirection.Forward,
                "reverse" => AnimationDirection.Reverse,
                "pingpong" => AnimationDirection.PingPong,
                "pingpong_reverse" => AnimationDirection.PingPongReverse,
                _ => (AnimationDirection)Enum.Parse(typeof(AnimationDirection), StringToPascal(reader.Value.ToString()))
            };
        }

        public override void WriteJson(JsonWriter writer, AnimationDirection value, JsonSerializer serializer)
        {
            writer.WriteValue(value switch
            {
                AnimationDirection.Forward => "forward",
                AnimationDirection.Reverse => "reverse",
                AnimationDirection.PingPong => "pingpong",
                AnimationDirection.PingPongReverse => "pingpong_reverse",
                _ => value.ToString(),
            });
        }

        private static string StringToPascal(string s) => CultureInfo.InvariantCulture.TextInfo
            .ToTitleCase(s.Replace('-', ' ')).Replace(" ", string.Empty);
    }
}