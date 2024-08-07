
namespace Varollo.AsepriteImporter.Tests
{
    public sealed class SerializationTestsData : TestData<SerializationTestsData.ArgData>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var dataSet in AllFrameData(JsonPath.NO_META))
                yield return dataSet;

            foreach (var dataSet in AllFrameData(JsonPath.WITH_META))
                yield return dataSet;
        }

        private static IEnumerable<object[]> AllFrameData(string jsonPath)
        {
            var sheetData = Data(ArgData.Sheet, JsonLoader.LoadSheet(jsonPath));
            var sheet = CachedData<AsepriteSheet>(ArgData.Sheet);
            var metaData = sheet.MetaData.HasValue ? Data(ArgData.Meta, sheet.MetaData) : default;

            return CachedData<AsepriteSheet>(ArgData.Sheet).Select((frame, i) => 
            {
                if (sheet.MetaData.HasValue)
                    return DataSet(sheetData, Data(ArgData.Frame, frame), Data(ArgData.FrameID, i), metaData);
                else 
                    return DataSet(sheetData, Data(ArgData.Frame, frame), Data(ArgData.FrameID, i));
            });
        }

        public enum ArgData
        {
            Sheet,
            Frame,
            FrameID,
            Meta,
        }
    }
}