using Microsoft.Xna.Framework;

namespace Varollo.AsepriteImporter.MG
{
    public class DrawTimeCounter : DrawCounterBase
    {
        public DrawTimeCounter(Game game, int drawOrder = int.MinValue) : base(game, drawOrder) { }
        public DrawTimeCounter(GameComponentCollection components, int drawOrder = int.MinValue) : base(components, drawOrder) { }

        protected override long Count(GameTime gameTime)
        {
            return gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}