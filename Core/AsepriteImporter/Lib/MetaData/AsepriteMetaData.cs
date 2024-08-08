using Newtonsoft.Json;
using System;
using System.Drawing;
using Varollo.AsepriteImporter.Serialization.Converters;

namespace Varollo.AsepriteImporter.MetaData
{
    /// <summary>
    /// Structure containing <see cref="AsepriteMetaData"/> of a <see cref="AsepriteSheet"/>.
    /// </summary>
    /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
    public struct AsepriteMetaData
    {
        /// <summary>
        /// <b>URI</b> to Aseprite's official website.
        /// <br/><br/>
        /// Represents property
        /// "<see href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L31">app</see>"
        /// on sprite sheet's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L28"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("app", NullValueHandling = NullValueHandling.Ignore)]
        public Uri App { get; internal set; }

        /// <summary>
        /// <b>Version</b> of Aseprite used to generate the <i>sprite sheet</i>.
        /// <br/><br/>
        /// Represents property
        /// "<see href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L32">version</see>"
        /// on sprite sheet's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L29"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; internal set; }

        /// <summary>
        /// Path to the <b>texture</b> file related to the <i>sprite sheet</i>.
        /// <br/><br/>
        /// Represents property
        /// "<see href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L33">image</see>"
        /// on sprite sheet's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L30"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; internal set; }

        /// <summary>
        /// Color <b>format</b> on Aseprite.
        /// <br/><br/>
        /// Represents property
        /// "<see href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L34">format</see>"
        /// on sprite sheet's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L31"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; internal set; }

        /// <summary>
        /// <i>Bidimensional vector</i> corresponding to the <i>pixel</i> <b>size</b> of the full <i>sprite sheet texture</i>.
        /// <br/><br/>
        /// Represents property
        /// "<see href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L35">size</see>"
        /// on sprite sheet's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L32"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SizeToPointConverter))]
        public Point Size { get; internal set; }

        /// <summary>
        /// <b>Scale</b> of <i>sprite sheet</i> in aseprite.
        /// <br/><br/>
        /// Represents property
        /// "<see href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L35">size</see>"
        /// on sprite sheet's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L32"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("scale", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public double Scale { get; internal set; }

        /// <summary>
        /// <b>Tag</b> <i>meta data</i> of <i>sprite sheet</i>.
        /// <br/><br/>
        /// Represents property
        /// "<see href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L35">frameTags</see>"
        /// on sprite sheet's JSON data.
        /// </summary>
        /// <seealso href="https://www.aseprite.org/docs/cli/#list-tags"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("frameTags", NullValueHandling = NullValueHandling.Ignore)]
        public AsepriteTagData[] Tags { get; internal set; }

        /// <summary>
        /// <b>Layer</b> <i>meta data</i> of <i>sprite sheet</i>.
        /// <br/><br/>
        /// Represents property
        /// "<see href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L35">layer</see>"
        /// on sprite sheet's JSON data.
        /// </summary>
        /// <seealso href="https://www.aseprite.org/docs/cli/#list-layers"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("layers", NullValueHandling = NullValueHandling.Ignore)]
        public AsepriteLayerData[] Layers { get; internal set; }

        // TODO
        //[JsonProperty("slices", NullValueHandling = NullValueHandling.Ignore)]
        //public AsepriteSlice[] Slices { get; internal set; }
    }
}