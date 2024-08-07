using Microsoft.Xna.Framework;
using Varollo.AsepriteImporter.Tests;

namespace Varollo.AsepriteImporter.MG.Tests
{
    public sealed class AnimationTestsData : TestData<AnimationTestsData.ArgData>
    {
        private readonly static GameComponentCollection s_components = new();

        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return AnimationDataSet(JsonPath.NO_META, "base.idle", new DrawTimeCounter(s_components), 0, 1000, 17);
            yield return AnimationDataSet(JsonPath.WITH_META, "eyes.walk_down", new DrawTimeCounter(s_components), 0, 1000, 17);
            yield return AnimationDataSet(JsonPath.WITH_META, "base.walk_down", new DrawFrameCounter(s_components), 100, 200, 34);
        }

        private static object[] AnimationDataSet(string jsonPath, string animTag, IAnimationCounter counter, int startTimeMillis, int endTimeMillis, int frameTimeMillis)
        {
            return DataSet(
                Data(ArgData.Components, s_components),
                Data(ArgData.Sheet, JsonLoader.LoadSheet(jsonPath)),
                Data(ArgData.Counter, counter),
                Data(ArgData.Animator, new AsepriteAnimator(counter, CachedData<AsepriteSheet>(ArgData.Sheet))),
                Data(ArgData.Animation, CachedData<AsepriteAnimator>(ArgData.Animator).GetAnimation(animTag)),
                Data(ArgData.StartTime, TimeSpan.FromMilliseconds(startTimeMillis)), 
                Data(ArgData.EndTime, TimeSpan.FromMilliseconds(endTimeMillis)), 
                Data(ArgData.FrameTime, TimeSpan.FromMilliseconds(frameTimeMillis)));
        }

        public enum ArgData
        {
            Sheet,
            Counter,
            Animator,
            Animation,
            StartTime,
            EndTime,
            FrameTime,
            Components,
        }
    }
}