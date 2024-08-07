using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Varollo.AsepriteImporter
{
    public readonly struct AsepriteAnimation : IEnumerable<AsepriteFrame>
    {
        private readonly AsepriteFrame[] _frames;

        internal AsepriteAnimation(string name, IEnumerable<AsepriteFrame> frames) : this(name, frames.ToArray()) { }
        internal AsepriteAnimation(string name, params AsepriteFrame[] frames)
        {
            Name = name;
            _frames = frames;
        }

        public AsepriteFrame this[int index] => _frames[index];
        public int FrameCount => _frames.Length;
        public string Name { get; }

        public IEnumerator<AsepriteFrame> GetEnumerator() => ((IEnumerable<AsepriteFrame>)_frames).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _frames.GetEnumerator();
    }
}
