using System;
using System.Linq;
using Varollo.AsepriteImporter.Serialization;

namespace Varollo.AsepriteImporter
{
    public readonly struct MetaData
    {
        internal MetaData(SerializedMetaData serializedMeta)
        {
            App = serializedMeta.App;
            Version = serializedMeta.Version;
            Image = serializedMeta.Image;
            Format = serializedMeta.Format;
            Width = serializedMeta.Size.W.Value;
            Height = serializedMeta.Size.H.Value;
            Scale = serializedMeta.Scale.Value;
            
            Tags = serializedMeta.FrameTags?.Select(tag => new TagData(tag)).ToArray();
            Layers = serializedMeta.Layers?.Select(layer => new LayerData(layer)).ToArray();
        }

        public Uri App { get; }
        public string Version { get; }
        public string Image { get; }
        public string Format { get; }
        public int Width { get; }
        public int Height { get; }
        public int Scale { get; }
        public TagData[] Tags { get; }
        public LayerData[] Layers { get; }
        public SliceData[] Slices => throw new NotImplementedException();
    }
}