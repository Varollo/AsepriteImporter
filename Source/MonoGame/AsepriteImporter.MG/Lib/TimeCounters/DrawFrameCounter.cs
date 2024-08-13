using Microsoft.Xna.Framework;

namespace Varollo.AsepriteImporter.MG
{
    /// <summary>
    /// Counter used by a <see cref="AsepriteAnimator"/>. <br/>
    /// Count changes during the <see cref="IDrawable.Draw(GameTime)"/> method,
    /// Counts Draw calls.
    /// </summary>
    public class DrawFrameCounter : DrawCounterBase
    {
        /// <inheritdoc/>
        public DrawFrameCounter(Game game, int drawOrder = int.MinValue) : base(game, drawOrder) { }

        /// <inheritdoc/>
        public DrawFrameCounter(GameComponentCollection components, int drawOrder = int.MinValue) : base(components, drawOrder) { }

        /// <inheritdoc/>
        protected override double Count(GameTime gameTime) => 1;
    }
}