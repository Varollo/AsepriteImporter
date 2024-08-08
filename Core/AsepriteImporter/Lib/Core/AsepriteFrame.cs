using Newtonsoft.Json;
using System;
using System.Drawing;
using Varollo.AsepriteImporter.Serialization.Converters;
using RectangleConverter = Varollo.AsepriteImporter.Serialization.Converters.RectangleConverter;
using SizeToPointConverter = Varollo.AsepriteImporter.Serialization.Converters.SizeToPointConverter;

namespace Varollo.AsepriteImporter
{
    /// <summary>
    /// Structure containing data from a <i>frame</i> on a <see cref="AsepriteSheet"/>.
    /// </summary>
    /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
    public struct AsepriteFrame
    {
        /// <summary>
        /// <b>Name</b> used to group <i>frames</i> of the same <i>animation</i>, when <see cref="MetaData.AsepriteTagData"/> is not present.
        /// <br/><br/>
        /// Represents property
        /// "<see href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L3">filename</see>"
        /// on frame's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L2"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#filename-format"/>
        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; internal set; }

        /// <summary>
        /// Rectangular area on the <i>sprite sheet texture</i> corresponding to this <i>frame</i>'s <i>pixel</i> <b>boundaries</b>.
        /// <br/><br/>
        /// Represents property "<seealso href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L4">frame</seealso>"
        /// on frame's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L3"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("frame", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(RectangleConverter))]
        public Rectangle SpriteRect { get; internal set; }

        /// <summary>
        /// Represents property "<seealso href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L5">rotated</seealso>"
        /// on frame's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L4"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("rotated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rotated { get; internal set; }

        /// <summary>
        /// Represents property "<seealso href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L6">trimmed</seealso>"
        /// on frame's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L5"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("trimmed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Trimmed { get; internal set; }

        /// <summary>
        /// <i>Bidimensional vector</i> corresponding to the <i>pixel</i> <b>size</b> of the <i>frame</i>.
        /// <br/><br/>
        /// Represents property "<seealso href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L7">frame</seealso>"
        /// on frame's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L6"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("sourceSize", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SizeToPointConverter))]
        public Point SpriteSize { get; internal set; }

        /// <summary>
        /// <b>Duration</b>, in <i>milliseconds</i>, the <i>frame</i> should be displayed on the <i>animation</i>.
        /// <br/><br/>
        /// Represents property "<seealso href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L8">frame</seealso>"
        /// on frame's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L7"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DurationToTimeSpanConverter))]
        public TimeSpan Duration { get; internal set; }
    }
}