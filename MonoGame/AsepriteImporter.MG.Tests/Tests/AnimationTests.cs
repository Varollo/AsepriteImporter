using Microsoft.Xna.Framework;
using static Varollo.AsepriteImporter.MG.Tests.AnimationTestsData;

namespace Varollo.AsepriteImporter.MG.Tests
{
    public class AnimationTests
    {
        [Theory]
        [ClassData(typeof(AnimationTestsData))]
        public void CallingDrawOnAnimator_FrameChangesAsTimePasses(Dictionary<ArgData, object> data)
        {
            var animator = CastData<AsepriteAnimator>(data[ArgData.Animator]);
            var animation = CastData<AsepriteAnimation>(data[ArgData.Animation]);

            Rectangle frame = Rectangle.Empty;
            int frameCounter = 1;

            SimmulateGameLoop(components: new IGameComponent[] { CastData<IGameComponent>(data[ArgData.Counter]) },
                initialTime: CastData<TimeSpan>(data[ArgData.StartTime]),
                totalTime: CastData<TimeSpan>(data[ArgData.EndTime]),
                frameTime: CastData<TimeSpan>(data[ArgData.FrameTime]),

                afterDraw: gameTime =>
                {
                    if (frame != animator.GetFrame(animation.Name))
                    {
                        frame = animator.GetFrame(animation.Name);
                        frameCounter++;
                    }
                });

            Assert.NotEqual(1, frameCounter);
        }

        [Theory]
        [ClassData(typeof(AnimationTestsData))]
        public void GetFrameBeforeDraw_MustBeFirstFrame(Dictionary<ArgData, object> data)
        {
            var sheet = CastData<AsepriteSheet>(data[ArgData.Sheet]);
            var animator = CastData<AsepriteAnimator>(data[ArgData.Animator]);
            var animation = CastData<AsepriteAnimation>(data[ArgData.Animation]);

            var firstFrame = sheet[animation.Name].First().SpriteRect;
            var frame = animator.GetFrame(animation.Name);

            Assert.Equal(firstFrame.X, frame.X);
            Assert.Equal(firstFrame.Y, frame.Y);
            Assert.Equal(firstFrame.Width, frame.Width);
            Assert.Equal(firstFrame.Height, frame.Height);
        }

        [Theory]
        [ClassData(typeof(AnimationTestsData))]
        public void GivenTag_AnimationMustHaveCorrespondingFrames(Dictionary<ArgData, object> data)
        {
            var sheet = CastData<AsepriteSheet>(data[ArgData.Sheet]);
            var animation = CastData<AsepriteAnimation>(data[ArgData.Animation]);

            for (int i = 0; i < animation.FrameCount; i++)
                Assert.Contains(animation.GetFrameByID(i), sheet[animation.Name]);
        }

        [Theory]
        [ClassData(typeof(AnimationTestsData))]
        public void InitializeAnim_TickCountIs0(Dictionary<ArgData, object> data)
        {
            var counter = CastData<DrawCounterBase>(data[ArgData.Counter]);
            counter.Initialize();
            Assert.Equal(0, counter.GetCount());
        }

        private static void SimmulateGameLoop(TimeSpan initialTime, TimeSpan totalTime, TimeSpan frameTime, Action<GameTime>? beforeUpdate = null, Action<GameTime>? afterUpdate = null, Action<GameTime>? beforeDraw = null, Action<GameTime>? afterDraw = null, params IGameComponent[] components)
        {
            for (TimeSpan elapsedTime = initialTime; elapsedTime <= totalTime; elapsedTime += frameTime)
            {
                var gameTime = new GameTime(elapsedTime, frameTime);

                foreach (var component in components)
                {
                    // Update ----------------------
                    beforeUpdate?.Invoke(gameTime);

                    if (component is IUpdateable updateable && updateable.Enabled)
                        updateable.Update(gameTime);

                    afterUpdate?.Invoke(gameTime);

                    // Draw ------------------------
                    beforeDraw?.Invoke(gameTime);

                    if (component is IDrawable drawable && drawable.Visible)
                        drawable.Draw(gameTime);

                    afterDraw?.Invoke(gameTime);
                }
            }
        }

        private static TCast CastData<TCast>(object data)
        {
            return (TCast)data;
        }
    }
}