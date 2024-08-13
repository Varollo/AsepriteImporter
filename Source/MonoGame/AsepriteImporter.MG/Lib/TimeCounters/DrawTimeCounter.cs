using Microsoft.Xna.Framework;

namespace Varollo.AsepriteImporter.MG
{
    /// <summary>
    /// Counter used by a <see cref="AsepriteAnimator"/>. <br/>
    /// Count changes during the <see cref="IDrawable.Draw(GameTime)"/> method,
    /// Counts time in <c>[milliseconds]</c>
    /// </summary>
    public class DrawTimeCounter : DrawCounterBase
    {
        /// <inheritdoc/>
        public DrawTimeCounter(Game game, int drawOrder = int.MinValue) : base(game, drawOrder) { }
        
        /// <inheritdoc/>
        public DrawTimeCounter(GameComponentCollection components, int drawOrder = int.MinValue) : base(components, drawOrder) { }

        /// <inheritdoc/>
        protected override double Count(GameTime gameTime)
        {
            return gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}