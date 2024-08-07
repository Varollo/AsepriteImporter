using Newtonsoft.Json;

namespace Varollo.AsepriteImporter.Serialization
{
    internal struct SerializedSheetData
    {
        [JsonProperty("frames", NullValueHandling = NullValueHandling.Ignore)]
        internal SerializedFrameData[] Frames { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        internal SerializedMetaData? Meta { get; set; }

        public override readonly string ToString() => ToJson(this);

        internal static string ToJson(SerializedSheetData spriteSheet) => JsonConvert.SerializeObject(spriteSheet);
        internal static SerializedSheetData FromJson(string json) => JsonConvert.DeserializeObject<SerializedSheetData>(json, SerializationHelpers.SerializerSettings);
    }
}
