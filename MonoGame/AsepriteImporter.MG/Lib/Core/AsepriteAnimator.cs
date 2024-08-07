using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Varollo.AsepriteImporter.MG
{
    public class AsepriteAnimator
    {
        private readonly AsepriteSheet _sheet;
        private readonly IAnimationCounter _counter;
        private readonly Dictionary<string, AsepriteAnimation> _animationMap;

        public AsepriteAnimator(IAnimationCounter counter, AsepriteSheet sheet)
        {
            _sheet = sheet;
            _counter = counter;
            _animationMap = new();
        }

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

        public Rectangle GetFrame(string name)
        {
            AsepriteAnimation animation = GetAnimation(name);
            AsepriteFrame frame = animation.GetFrameByTime(_counter.GetCount());

            System.Drawing.Rectangle bounds = frame.Bounds;
            return new(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }
    }
}