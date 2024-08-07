using Microsoft.Xna.Framework;

namespace Varollo.AsepriteImporter.MG
{
    public class DrawFrameCounter : DrawCounterBase
    {
        public DrawFrameCounter(Game game, int drawOrder = int.MinValue) : base(game, drawOrder) { }
        public DrawFrameCounter(GameComponentCollection components, int drawOrder = int.MinValue) : base(components, drawOrder) { }

        protected override long Count(GameTime gameTime) => 1;
    }
}