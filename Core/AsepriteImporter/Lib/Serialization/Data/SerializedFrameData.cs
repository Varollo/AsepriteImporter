using Newtonsoft.Json;

namespace Varollo.AsepriteImporter.Serialization
{
    internal struct SerializedFrameData
    {
        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }

        [JsonProperty("frame", NullValueHandling = NullValueHandling.Ignore)]
        public SerializedRect Frame { get; set; }

        [JsonProperty("rotated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rotated { get; set; }

        [JsonProperty("trimmed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Trimmed { get; set; }

        [JsonProperty("spriteSourceSize", NullValueHandling = NullValueHandling.Ignore)]
        public SerializedRect SpriteSourceSize { get; set; }

        [JsonProperty("sourceSize", NullValueHandling = NullValueHandling.Ignore)]
        public SerializedSize SourceSize { get; set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public int? Duration { get; set; }
    }
}
