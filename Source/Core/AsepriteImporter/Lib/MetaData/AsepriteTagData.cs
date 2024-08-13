using Newtonsoft.Json;
using System.Drawing;
using Varollo.AsepriteImporter.Serialization.Converters;

namespace Varollo.AsepriteImporter.MetaData
{
    /// <summary>
    /// Structure containing <see cref="AsepriteMetaData"/> from a <i>tag</i> on a <see cref="AsepriteSheet"/>.
    /// </summary>
    /// <seealso href="https://www.aseprite.org/docs/cli/#list-tags"/>
    public struct AsepriteTagData
    {
        /// <summary>
        /// <b>Name</b> of the <i>tag</i> in Aseprite, used to group <i>frames</i> of the same <i>animation</i>.
        /// <br/><br/>
        /// Represents property <c>"name"</c> on <see cref="AsepriteMetaData.Tags"/>'s JSON data.
        /// </summary>
        /// <seealso href="https://www.aseprite.org/docs/cli/#list-tags"/>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; internal set; }

        /// <summary>
        /// <b>First</b> <i>frame index</i> of the <i>animation</i> corresponding to the <i>tag</i>.
        /// <br/><br/>
        /// Represents property <c>"from"</c> on <see cref="AsepriteMetaData.Tags"/>'s JSON data.
        /// </summary>
        /// <seealso href="https://www.aseprite.org/docs/cli/#list-tags"/>
        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public int? From { get; internal set; }

        /// <summary>
        /// <b>Last</b> <i>frame index</i> of the <i>animation</i> corresponding to the <i>tag</i>.
        /// <br/><br/>
        /// Represents property <c>"to"</c> on <see cref="AsepriteMetaData.Tags"/>'s JSON data.
        /// </summary>
        /// <seealso href="https://www.aseprite.org/docs/cli/#list-tags"/>
        [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
        public int? To { get; internal set; }

        /// <summary>
        /// <b>Direction</b> and <i>loop mode</i> of the <i>animation</i> corresponding to the <i>tag</i>.
        /// <br/><br/>
        /// Represents property <c>"direction"</c> on <see cref="AsepriteMetaData.Tags"/>'s JSON data.
        /// </summary>
        /// <seealso href="https://www.aseprite.org/docs/cli/#list-tags"/>
        [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(AnimationDirectionConverter))]
        public AsepriteAnimationDirection Direction { get; internal set; }

        /// <summary>
        /// <b>Color</b> of the <i>tag</i> in Aseprite.
        /// <br/><br/>
        /// Represents property <c>"color"</c> on <see cref="AsepriteMetaData.Tags"/>'s JSON data.
        /// </summary>
        /// <seealso href="https://www.aseprite.org/docs/cli/#list-tags"/>
        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(HexToColorConverter))]
        public Color Color { get; internal set; }
    }
}
