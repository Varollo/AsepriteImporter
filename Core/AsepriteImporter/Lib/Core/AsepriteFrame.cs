using System;
using System.Drawing;
using Varollo.AsepriteImporter.Serialization;

namespace Varollo.AsepriteImporter
{
    public readonly struct AsepriteFrame
    {
        internal AsepriteFrame(SerializedFrameData serializedFrame)
        {
            Name = serializedFrame.Filename;
            Duration = TimeSpan.FromMilliseconds(serializedFrame.Duration ?? 0);
            Bounds = new(
                x: serializedFrame.Frame.X ?? 0,
                y: serializedFrame.Frame.Y ?? 0,
                width: serializedFrame.Frame.W ?? 0,
                height: serializedFrame.Frame.H ?? 0);
        }

        public string Name { get; }
        public Rectangle Bounds { get; }
        public TimeSpan Duration { get; }
    }
}