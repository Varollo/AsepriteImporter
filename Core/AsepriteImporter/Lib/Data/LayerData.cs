using Varollo.AsepriteImporter.Serialization;

namespace Varollo.AsepriteImporter
{
    public readonly struct LayerData
    {
        internal LayerData(SerializedLayerData serializedLayer)
        {
            Name = serializedLayer.Name;
            Group = serializedLayer.Group;
            Opacity = serializedLayer.Opacity ?? 0;
            BlendMode = serializedLayer.BlendMode;
        }

        public string Name { get; }
        public string Group { get; }
        public int Opacity { get; }
        public string BlendMode { get; }

    }
}