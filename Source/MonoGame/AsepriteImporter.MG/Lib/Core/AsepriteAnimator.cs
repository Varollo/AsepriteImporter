using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Varollo.AsepriteImporter.MG
{
    /// <summary>
    /// Handles all <see cref="AsepriteAnimation"/> on a <see cref="AsepriteSheet"/>
    /// </summary>
    public class AsepriteAnimator
    {
        private readonly AsepriteSheet _sheet;
        private readonly IAnimationCounter _counter;
        private readonly Dictionary<string, AsepriteAnimation> _animationMap;

        /// <summary>
        /// Initializes a <see cref="AsepriteAnimator"/> for a <see cref="AsepriteSheet"/> using a <see cref="IAnimationCounter"/>
        /// </summary>
        /// <param name="counter"> Object responsible for increasing animation frame. Such as <see cref="DrawTimeCounter"/>. </param>
        /// <param name="sheet"> <i>Sprite sheet</i> deserialized using <see cref="AsepriteDataLoader"/> </param>
        public AsepriteAnimator(IAnimationCounter counter, AsepriteSheet sheet)
        {
            _sheet = sheet;
            _counter = counter;
            _animationMap = new();
        }

        /// <summary>
        /// Retrieves an animation by <see cref="AsepriteFrame.Name"/> or <see cref="MetaData.AsepriteTagData.Name"/>.
        /// </summary>
        /// <param name="name"> Name or tag key for the animation. </param>
        /// <returns> Found animation of given name key. </returns>
        /// <exception cref="ArgumentException"> Thrown when no animation is found with that name key. </exception>
        public AsepriteAnimation GetAnimation(string name)
        {
            if (!_animationMap.TryGetValue(name, out var animation))
            {
                if (!_sheet.HasAnimation(name))
                    throw new ArgumentException($"{nameof(AsepriteAnimator)} Error: Could not find animation with name '{name}' in sheet.");

                animation = new(name, _sheet[name].ToArray());
            }

            return animation;
        }

        /// <summary>
        /// Retrieves the current frame (<see cref="Rectangle"/>) for an animation using the <see cref="AsepriteFrame.Name"/> or <see cref="MetaData.AsepriteTagData.Name"/>.
        /// </summary>
        /// <param name="name"> Name or tag key for the animation. </param>
        /// <returns> Rectangle corresponding to the <see cref="AsepriteFrame.SpriteRect"/> of the current frame of animation. </returns>
        public Rectangle GetFrame(string name)
        {
            AsepriteAnimation animation = GetAnimation(name);
            AsepriteFrame frame = animation.GetFrameByTime(_counter.GetCount());

            System.Drawing.Rectangle bounds = frame.SpriteRect;
            return new(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }
    }
}