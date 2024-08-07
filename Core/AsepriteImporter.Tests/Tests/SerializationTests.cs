using Varollo.AsepriteImporter.Data;
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
            var frame = CastData<AsepriteFrame>(data[ArgData.Frame]);
            Assert.NotEqual(TimeSpan.Zero, frame.Duration);
        }

        [Theory]
        [ClassData(typeof(SerializationTestsData))]
        public void LoadSheet_FramesGroupedByName(Dictionary<ArgData, object> data)
        {
            var sheet = CastData<AsepriteSheet>(data[ArgData.Sheet]);
            var frame = CastData<AsepriteFrame>(data[ArgData.Frame]);
            Assert.NotEmpty(sheet[frame.Name]);
        }

        [Theory]
        [ClassData(typeof(SerializationTestsData))]
        public void LoadSheet_BoundsLoaded(Dictionary<ArgData, object> data)
        {
            var frame = CastData<AsepriteFrame>(data[ArgData.Frame]);
            Assert.False(frame.SpriteRect.IsEmpty,
                $"Frame '{frame.Name}' ({CastData<int>(data[ArgData.FrameID]):00}) has an empty rect ({nameof(AsepriteFrame.SpriteRect)})");
        }

        [Theory]
        [ClassData(typeof(SerializationTestsData))]
        public void LoadMetaData_TagsLoaded(Dictionary<ArgData, object> data)
        {
            if (!data.ContainsKey(ArgData.Meta))
                return;

            var tags = CastData<MetaData>(data[ArgData.Meta]).Tags;

            if (tags == null || tags.Length == 0)
                return;

            for (int i = 0; i < tags.Length; i++)
            {
                TagData tag = tags[i];

                // Test: Tag loaded?
                Assert.NotEqual(default, tag);

                // Test: Is direction valid?
                Assert.True(Enum.IsDefined(tag.Direction),
                    $"Tag '{tag.Name}' ({i:00}) has invalid '{nameof(TagData.Direction)}' value of '{(int)tag.Direction}'.");
            }
        }

        [Theory]
        [ClassData(typeof(SerializationTestsData))]
        public void LoadTags_DirectionIsValid(Dictionary<ArgData, object> data)
        {
            if (!data.ContainsKey(ArgData.Meta))
                return;

            var tags = CastData<MetaData>(data[ArgData.Meta]).Tags;

            if (tags == null || tags.Length == 0)
                return;

            for (int i = 0; i < tags.Length; i++)
            {
                TagData tag = tags[i];
                Assert.True(Enum.IsDefined(tag.Direction),
                    $"Tag '{tag.Name}' ({i:00}) has invalid '{nameof(TagData.Direction)}' value of '{(int)tag.Direction}'.");
            }
        }

        [Theory]
        [ClassData(typeof(SerializationTestsData))]
        public void LoadMetaData_LayersLoaded(Dictionary<ArgData, object> data)
        {
            if (!data.ContainsKey(ArgData.Meta))
                return;

            var layers = CastData<MetaData>(data[ArgData.Meta]).Layers;

            if (layers == null || layers.Length == 0)
                return;

            for (int i = 0; i < layers.Length; i++)
            {
                LayerData layer = layers[i];
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