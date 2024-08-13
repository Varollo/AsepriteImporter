using Newtonsoft.Json;
using System;
using System.Globalization;
using Varollo.AsepriteImporter.MetaData;

namespace Varollo.AsepriteImporter.Serialization.Converters
{
    internal class AnimationDirectionConverter : JsonConverter<AsepriteAnimationDirection>
    {
        public override AsepriteAnimationDirection ReadJson(JsonReader reader, Type objectType, AsepriteAnimationDirection existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString() switch
            {
                "forward" => AsepriteAnimationDirection.Forward,
                "reverse" => AsepriteAnimationDirection.Reverse,
                "pingpong" => AsepriteAnimationDirection.PingPong,
                "pingpong_reverse" => AsepriteAnimationDirection.PingPongReverse,
                _ => (AsepriteAnimationDirection)Enum.Parse(typeof(AsepriteAnimationDirection), StringToPascal(reader.Value.ToString()))
            };
        }

        public override void WriteJson(JsonWriter writer, AsepriteAnimationDirection value, JsonSerializer serializer)
        {
            writer.WriteValue(value switch
            {
                AsepriteAnimationDirection.Forward => "forward",
                AsepriteAnimationDirection.Reverse => "reverse",
                AsepriteAnimationDirection.PingPong => "pingpong",
                AsepriteAnimationDirection.PingPongReverse => "pingpong_reverse",
                _ => value.ToString(),
            });
        }

        private static string StringToPascal(string s) => CultureInfo.InvariantCulture.TextInfo
            .ToTitleCase(s.Replace('-', ' ')).Replace(" ", string.Empty);
    }
}