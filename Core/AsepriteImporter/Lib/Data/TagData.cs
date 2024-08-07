using Newtonsoft.Json;
using Varollo.AsepriteImporter.Serialization.Converters;

namespace Varollo.AsepriteImporter.Data
{
    public struct TagData
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; internal set; }

        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public int? From { get; internal set; }

        [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
        public int? To { get; internal set; }

        [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(AnimationDirectionConverter))]
        public AnimationDirection Direction { get; internal set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(HexToColorConverter))]
        public string Color { get; internal set; }
    }
}
