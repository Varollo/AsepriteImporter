using System;
using Newtonsoft.Json;

namespace Varollo.AsepriteImporter.Serialization
{
    internal struct SerializedMetaData
    {
        [JsonProperty("app", NullValueHandling = NullValueHandling.Ignore)]
        internal Uri App { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        internal string Version { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        internal string Image { get; set; }

        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        internal string Format { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        internal SerializedSize Size { get; set; }

        [JsonProperty("scale", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SerializationHelpers.ParseStringConverter))]
        internal int? Scale { get; set; }

        [JsonProperty("frameTags", NullValueHandling = NullValueHandling.Ignore)]
        internal SerializedTagData[] FrameTags { get; set; }

        [JsonProperty("layers", NullValueHandling = NullValueHandling.Ignore)]
        internal SerializedLayerData[] Layers { get; set; }

        [JsonProperty("slices", NullValueHandling = NullValueHandling.Ignore)]
        internal object[] Slices { get; set; }

        public override readonly string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
