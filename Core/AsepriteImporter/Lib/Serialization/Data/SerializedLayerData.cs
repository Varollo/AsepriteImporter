using Newtonsoft.Json;

namespace Varollo.AsepriteImporter.Serialization
{
    internal struct SerializedLayerData
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; set; }

        [JsonProperty("opacity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Opacity { get; set; }

        [JsonProperty("blendMode", NullValueHandling = NullValueHandling.Ignore)]
        public string BlendMode { get; set; }
    }
}
