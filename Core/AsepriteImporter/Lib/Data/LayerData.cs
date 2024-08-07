using Newtonsoft.Json;

namespace Varollo.AsepriteImporter.Data
{
    public struct LayerData
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; internal set; }

        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; internal set; }

        [JsonProperty("opacity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Opacity { get; internal set; }

        [JsonProperty("blendMode", NullValueHandling = NullValueHandling.Ignore)]
        public string BlendMode { get; internal set; }
    }
}
