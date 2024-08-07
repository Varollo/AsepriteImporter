using Newtonsoft.Json;

namespace Varollo.AsepriteImporter.Serialization
{
    internal struct SerializedRect
    {
        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public int? X { get; set; }

        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public int? Y { get; set; }

        [JsonProperty("w", NullValueHandling = NullValueHandling.Ignore)]
        public int? W { get; set; }

        [JsonProperty("h", NullValueHandling = NullValueHandling.Ignore)]
        public int? H { get; set; }
    }
}
