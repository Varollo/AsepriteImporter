using Newtonsoft.Json;

namespace Varollo.AsepriteImporter.Serialization
{
    internal struct SerializedTagData
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public int? From { get; set; }

        [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
        public int? To { get; set; }

        [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(AnimationDirectionConverter))]
        public AnimationDirection Direction { get; set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }
    }
}
