using Varollo.AsepriteImporter.MetaData;
using static Varollo.AsepriteImporter.Tests.SerializationTestsData;

namespace Varollo.AsepriteImporter.Tests
{
    public class SerializationTests
    {
        [Theory]
        [ClassData(typeof(SerializationTestsData))]
        public void LoadSheet_ContainFrames(Dictionary<ArgData, object> data)
        {
            AsepriteSheet sheet = CastData<AsepriteSheet>(data[ArgData.Sheet]);
            Assert.NotEmpty(sheet.Frames);
        }

        [Theory]
        [ClassData(typeof(SerializationTestsData))]
        public void LoadSheet_DurationLoaded(Dictionary<ArgData, object> data)
        {
            AsepriteFrame[] frames = CastData<AsepriteFrame[]>(data[ArgData.Frames]);
            for (int i = 0; i < frames.Length; i++)
            {
                AsepriteFrame frame = frames[i];
                if (frame.Duration == TimeSpan.Zero)
                    Assert.Fail($"Frame {frame.Name} ({i:00}) has duration ({nameof(AsepriteFrame.Duration)}) of 0.");
            }
        }

        [Theory]
        [ClassData(typeof(SerializationTestsData))]
        public void LoadSheet_FramesGroupedByName(Dictionary<ArgData, object> data)
        {
            var frames = CastData<AsepriteFrame[]>(data[ArgData.Frames]);
            Assert.NotEmpty(frames);
        }

        [Theory]
        [ClassData(typeof(SerializationTestsData))]
        public void LoadSheet_BoundsLoaded(Dictionary<ArgData, object> data)
        {
            AsepriteFrame[] frames = CastData<AsepriteFrame[]>(data[ArgData.Frames]);
            for (int i = 0; i < frames.Length; i++)
            {
                AsepriteFrame frame = frames[i];
                
                if (frame.SpriteRect.IsEmpty)
                    Assert.Fail($"Frame '{frame.Name}' ({i:00}) has an empty rect ({nameof(AsepriteFrame.SpriteRect)})");
            }
        }

        [Theory]
        [ClassData(typeof(SerializationTestsData))]
        public void LoadMetaData_TagsLoaded(Dictionary<ArgData, object> data)
        {
            if (!data.ContainsKey(ArgData.Meta))
                return;

            var tags = CastData<AsepriteMetaData>(data[ArgData.Meta]).Tags;

            if (tags == null || tags.Length == 0)
                return;

            for (int i = 0; i < tags.Length; i++)
            {
                AsepriteTagData tag = tags[i];

                // Test: Tag loaded?
                Assert.NotEqual(default, tag);

                // Test: Is direction valid?
                Assert.True(Enum.IsDefined(tag.Direction),
                    $"Tag '{tag.Name}' ({i:00}) has invalid '{nameof(AsepriteTagData.Direction)}' value of '{(int)tag.Direction}'.");
            }
        }

        [Theory]
        [ClassData(typeof(SerializationTestsData))]
        public void LoadTags_DirectionIsValid(Dictionary<ArgData, object> data)
        {
            if (!data.ContainsKey(ArgData.Meta))
                return;

            var tags = CastData<AsepriteMetaData>(data[ArgData.Meta]).Tags;

            if (tags == null || tags.Length == 0)
                return;

            for (int i = 0; i < tags.Length; i++)
            {
                AsepriteTagData tag = tags[i];
                Assert.True(Enum.IsDefined(tag.Direction),
                    $"Tag '{tag.Name}' ({i:00}) has invalid '{nameof(AsepriteTagData.Direction)}' value of '{(int)tag.Direction}'.");
            }
        }

        [Theory]
        [ClassData(typeof(SerializationTestsData))]
        public void LoadMetaData_LayersLoaded(Dictionary<ArgData, object> data)
        {
            if (!data.ContainsKey(ArgData.Meta))
                return;

            var layers = CastData<AsepriteMetaData>(data[ArgData.Meta]).Layers;

            if (layers == null || layers.Length == 0)
                return;

            for (int i = 0; i < layers.Length; i++)
            {
                AsepriteLayerData layer = layers[i];
                Assert.NotEqual(default, layer);
            }
        }

        //// TODO: Slices not implemented yet.
        //[Theory]
        //[ClassData(typeof(SerializationTestsData))]
        //public void LoadMetaData_SlicesLoaded(Dictionary<ArgData, object> data)
        //{
        //    if (!data.ContainsKey(ArgData.Meta))
        //        return;

        //    var slices = CastData<MetaData>(data[ArgData.Meta]).Slices;

        //    if (slices == null || slices.Length == 0)
        //        return;

        //    for (int i = 0; i < slices.Length; i++)
        //    {
        //        SliceData slice = slices[i];
        //        Assert.NotEqual(default, slice);
        //    }
        //}

        private static TCast CastData<TCast>(object data)
        {
            return (TCast)data;
        }
    }
}