using System;
using System.Linq;

namespace Varollo.AsepriteImporter.MG
{
    public class AsepriteAnimation
    {
        private readonly AsepriteFrame[] _frames;
        private readonly long _totalMillis;

        internal AsepriteAnimation(string name, AsepriteFrame[] frames)
        {
            Name = name;

            _frames = frames;
            FrameCount = frames.Length;

            _totalMillis = _frames.Sum(frame => frame.Duration.Milliseconds);
            TotalDuration = TimeSpan.FromMilliseconds(_totalMillis);
        }

        public string Name { get; }
        public TimeSpan TotalDuration { get; }
        public int FrameCount { get; }

        public AsepriteFrame GetFrameByID(int frameID)
        {
            return _frames[frameID];
        }

        public AsepriteFrame GetFrameByTime(long elapsedMillis)
        {
            long timeInTicks = elapsedMillis % _totalMillis;
            long k = 0;

            for (int i = 0; i < FrameCount; i++)
            {
                AsepriteFrame frame = GetFrameByID(i);
                k += frame.Duration.Milliseconds;

                if (k >= timeInTicks)
                    return frame;
            }

            throw new InvalidOperationException(
                $"{nameof(AsepriteAnimation)} Error: Could not retrieve frame on time '{TimeSpan.FromMilliseconds(elapsedMillis)}' for animation '{Name}'.");
        }
    }
}