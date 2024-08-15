using Microsoft.Xna.Framework;
using System;

namespace Varollo.AsepriteImporter.MG
{
    /// <summary>
    /// Counter used by a <see cref="AsepriteAnimator"/>. <br/>
    /// Count changes during the <see cref="IDrawable.Draw(GameTime)"/> method,
    /// while <see cref="IDrawable.Visible"/><c> = true</c>.
    /// </summary>
    public abstract class DrawCounterBase : IAnimationCounter, IGameComponent, IDrawable
    {
        /// <inheritdoc/>
        #pragma warning disable CS0067
        public event EventHandler<EventArgs> DrawOrderChanged;
        #pragma warning restore

        /// <inheritdoc/>
        public event EventHandler<EventArgs> VisibleChanged;

        private double _count;

        /// <summary>
        /// Initializes a <see cref="DrawTimeCounter"/> as a component of given <see cref="Game"/> instance.
        /// </summary>
        /// <param name="game"><see cref="Game"/> instance.</param>
        /// <param name="drawOrder">[optional] Order to count passed time, among other components.</param>
        public DrawCounterBase(Game game, int drawOrder = int.MinValue) : this(game?.Components, drawOrder) { }

        /// <summary>
        /// Initializes a <see cref="DrawTimeCounter"/> and adds it to a <see cref="GameComponentCollection"/>
        /// </summary>
        /// <param name="components"><see cref="GameComponentCollection"/> to add counter instance.</param>
        /// <param name="drawOrder">[optional] Order to count passed time, among other components.</param>
        public DrawCounterBase(GameComponentCollection components, int drawOrder = int.MinValue)
        {
            DrawOrder = drawOrder;
            Visible = true;

            components?.Add(this);
        }

        /// <inheritdoc/>
        public int DrawOrder { get; }
        /// <inheritdoc/>
        public bool Visible { get; private set; }

        /// <inheritdoc/>
        public double GetCount()
        {
            return _count;
        }

        /// <summary>
        /// Enables or disables the counter.
        /// </summary>
        /// <param name="visible">Visibility state.</param>
        public void SetVisibility(bool visible)
        {
            if (Visible != visible)
                VisibleChanged?.Invoke(this, EventArgs.Empty);

            Visible = visible;
        }

        /// <inheritdoc/>
        public void Initialize()
        {
            _count = 0;
        }

        /// <inheritdoc/>
        public void Draw(GameTime gameTime)
        {
            _count += Count(gameTime);
        }

        /// <summary>
        /// Computes <see cref="AsepriteAnimation"/> frame count changes.
        /// </summary>
        /// <param name="gameTime">Time information.</param>
        /// <returns>Value to add(+) to animation counter.</returns>
        protected abstract double Count(GameTime gameTime);
    }
}