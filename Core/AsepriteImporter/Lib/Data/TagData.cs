using System.Drawing;
using Varollo.AsepriteImporter.Serialization;

namespace Varollo.AsepriteImporter
{
    public readonly struct TagData
    {
        internal TagData(SerializedTagData serializedTag)
        {
            Name = serializedTag.Name;
            From = serializedTag.From ?? 0;
            To = serializedTag.To ?? 0;
            Direction = serializedTag.Direction;
            Color = GetColorFromHex(serializedTag.Color);
        }

        public string Name { get; }
        public int From { get; }
        public int To { get; }
        public AnimationDirection Direction { get; }
        public Color Color { get; }

        private static Color GetColorFromHex(string hex)
        {
            var converter = new ColorConverter();
            var col = (Color) converter.ConvertFromString(hex);
            return col;
        }
    }
}