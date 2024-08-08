using Newtonsoft.Json;

namespace Varollo.AsepriteImporter.MetaData
{
    /// <summary>
    /// Structure containing <see cref="AsepriteMetaData"/> from a <i>layer</i> on a <see cref="AsepriteSheet"/>.
    /// </summary>
    /// <seealso href="https://www.aseprite.org/docs/cli/#list-layers"/>
    public struct AsepriteLayerData
    {
        /// <summary>
        /// <b>Name</b> of the <i>layer</i> in Aseprite.
        /// <br/><br/>
        /// Represents property <c>"name"</c> on <see cref="AsepriteMetaData.Layers"/>'s JSON data.
        /// </summary>
        /// <seealso href="https://www.aseprite.org/docs/cli/#list-layers"/>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; internal set; }

        /// <summary>
        /// <i>Name</i> of the <b>group</b> the <i>layer</i> belongs to, in Aseprite.
        /// <br/><br/>
        /// Represents property <c>"group"</c> on <see cref="AsepriteMetaData.Layers"/>'s JSON data.
        /// </summary>
        /// <seealso href="https://www.aseprite.org/docs/cli/#list-layers"/>
        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; internal set; }

        /// <summary>
        /// <b>Opacity</b> of the <i>layer</i> in Aseprite.
        /// <br/><br/>
        /// Represents property <c>"opacity"</c> on <see cref="AsepriteMetaData.Layers"/>'s JSON data.
        /// </summary>
        /// <seealso href="https://www.aseprite.org/docs/cli/#list-layers"/>
        [JsonProperty("opacity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Opacity { get; internal set; }

        /// <summary>
        /// <b>Blend mode</b> of the <i>layer</i> in Aseprite.
        /// <br/><br/>
        /// Represents property <c>"blendMode"</c> on <see cref="AsepriteMetaData.Layers"/>'s JSON data.
        /// </summary>
        /// <seealso href="https://www.aseprite.org/docs/cli/#list-layers"/>
        [JsonProperty("blendMode", NullValueHandling = NullValueHandling.Ignore)]
        public string BlendMode { get; internal set; }
    }
}
