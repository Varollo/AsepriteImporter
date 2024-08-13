using System;
using System.Linq;

namespace Varollo.AsepriteImporter.MG
{
    /// <summary>
    /// Object representing a <i>animation</i> of <see cref="AsepriteFrame"/>.
    /// </summary>
    public class AsepriteAnimation
    {
        private readonly AsepriteFrame[] _frames;
        private readonly double _totalMillis;

        internal AsepriteAnimation(string name, AsepriteFrame[] frames)
        {
            Name = name;

            _frames = frames;
            FrameCount = frames.Length;

            _totalMillis = _frames.Sum(frame => frame.Duration.TotalMilliseconds);
            TotalDuration = TimeSpan.FromMilliseconds(_totalMillis);
        }

        /// <summary>
        /// <see cref="AsepriteFrame.Name"/> or <see cref="MetaData.AsepriteTagData"/> corresponding to the animation.        
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Sum of <see cref="AsepriteFrame.Duration"/> for all frames in the animation.<br/>
        /// <see cref="MetaData.AsepriteAnimationDirection.PingPong"/> (and reversed) double original animation duration.
        /// </summary>
        public TimeSpan TotalDuration { get; }

        /// <summary>
        /// <b>Amount</b> of frames present in the <i>animation</i>.
        /// </summary>
        public int FrameCount { get; }

        /// <summary>
        /// Retrieves a <i>frame</i> in the <i>animation</i> by it's index or "<paramref name="frameID"/>".
        /// <br/><i>Out of bounds</i> "<paramref name="frameID"/>" values are wrapped back to <c>0</c>.
        /// </summary>
        /// <param name="frameID"> Order, starting from <c>0</c>, which the <i>frame</i> appears in the <b>animation</b>. </param>
        /// <returns><i>Frame at position "<paramref name="frameID"/>"</i></returns>
        public AsepriteFrame GetFrameByID(int frameID)
        {
            return _frames[Math.Abs(frameID) % FrameCount];
        }

        /// <summary>
        /// Retrieves the <i>frame</i> in the <i>animation</i> that is suposed to be shown at a <b>elapsed time</b>, in <i>milliseconds</i>.
        /// <br/><i>Out of bounds</i> "<paramref name="elapsedMillis"/>" values are wrapped back to <c>0</c>.
        /// </summary>
        /// <param name="elapsedMillis">Point in time, in <i>milliseconds</i>, during the <i>animation</i> to retrieve a frame from.</param>
        /// <returns>Frame at "<paramref name="elapsedMillis"/>" point in time.</returns>
        /// <exception cref="InvalidOperationException">This should not occour, if it does, it's a sign my code doesn't work!</exception>
        public AsepriteFrame GetFrameByTime(double elapsedMillis)
        {
            double timeInMillis = Math.Abs(elapsedMillis) % _totalMillis;
            double k = 0;

            for (int i = 0; i <= FrameCount; i++)
            {
                AsepriteFrame frame = GetFrameByID(i);
                k += frame.Duration.TotalMilliseconds;

                if (k > timeInMillis)
                    return frame;
            }

            throw new InvalidOperationException(
                $"{nameof(AsepriteAnimation)} Error: Could not retrieve frame on time '{TimeSpan.FromMilliseconds(elapsedMillis)}' for animation '{Name}'.");
        }
    }
}