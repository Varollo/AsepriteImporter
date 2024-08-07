using Microsoft.Xna.Framework;
using System;

namespace Varollo.AsepriteImporter.MG
{
    public abstract class DrawCounterBase : IAnimationCounter, IGameComponent, IDrawable
    {
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        private long _count;

        public DrawCounterBase(Game game, int drawOrder = int.MinValue) : this (game?.Components, drawOrder) { }
        public DrawCounterBase(GameComponentCollection components, int drawOrder = int.MinValue)
        {
            components?.Add(this);
        }

        public int DrawOrder { get; }
        public bool Visible { get; private set; }

        public long GetCount()
        {
            return _count;
        }

        public void SetVisibility(bool visible)
        {
            if (Visible != visible)
                VisibleChanged?.Invoke(this, EventArgs.Empty);

            Visible = visible;
        }

        public void Initialize()
        {
            _count = 0;
        }

        public void Draw(GameTime gameTime)
        {
            _count += Count(gameTime);
        }

        protected abstract long Count(GameTime gameTime);
    }
}