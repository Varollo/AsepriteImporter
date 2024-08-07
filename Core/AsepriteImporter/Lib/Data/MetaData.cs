using Newtonsoft.Json;
using System;
using System.Drawing;
using Varollo.AsepriteImporter.Serialization.Converters;

namespace Varollo.AsepriteImporter.Data
{
    public struct MetaData
    {
        [JsonProperty("app", NullValueHandling = NullValueHandling.Ignore)]
        public Uri App { get; internal set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; internal set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; internal set; }

        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; internal set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public Point Size { get; internal set; }

        [JsonProperty("scale", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public int Scale { get; internal set; }

        [JsonProperty("frameTags", NullValueHandling = NullValueHandling.Ignore)]
        public TagData[] Tags { get; internal set; }

        [JsonProperty("layers", NullValueHandling = NullValueHandling.Ignore)]
        public LayerData[] Layers { get; internal set; }

        // TODO
        //[JsonProperty("slices", NullValueHandling = NullValueHandling.Ignore)]
        //public SliceData[] Slices { get; internal set; }
    }
}