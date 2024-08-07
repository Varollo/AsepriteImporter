using Newtonsoft.Json;
using System;
using System.Drawing;
using Varollo.AsepriteImporter.Serialization.Converters;
using RectangleConverter = Varollo.AsepriteImporter.Serialization.Converters.RectangleConverter;
using SizeToPointConverter = Varollo.AsepriteImporter.Serialization.Converters.SizeToPointConverter;

namespace Varollo.AsepriteImporter
{
    public struct AsepriteFrame
    {
        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; internal set; }

        [JsonProperty("rotated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rotated { get; internal set; }

        [JsonProperty("trimmed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Trimmed { get; internal set; }

        [JsonProperty("frame", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(RectangleConverter))]
        public Rectangle SpriteRect { get; internal set; }

        [JsonProperty("sourceSize", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SizeToPointConverter))]
        public Point SpriteSize { get; internal set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DurationToTimeSpanConverter))]
        public TimeSpan Duration { get; internal set; }
    }
}