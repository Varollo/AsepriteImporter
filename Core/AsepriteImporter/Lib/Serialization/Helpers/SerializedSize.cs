using Newtonsoft.Json;

namespace Varollo.AsepriteImporter.Serialization
{
    internal struct SerializedSize
    {
        [JsonProperty("w", NullValueHandling = NullValueHandling.Ignore)]
        public int? W { get; set; }

        [JsonProperty("h", NullValueHandling = NullValueHandling.Ignore)]
        public int? H { get; set; }
    }
}
