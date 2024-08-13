
namespace Varollo.AsepriteImporter.Tests
{
    public sealed class SerializationTestsData : TestData<SerializationTestsData.ArgData>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return SetupData(JsonPath.NO_META);
            yield return SetupData(JsonPath.WITH_META);
        }

        private static object[] SetupData(string jsonPath)
        {
            var sheetData = Data(ArgData.Sheet, JsonLoader.LoadSheet(jsonPath));
            var sheet = CachedData<AsepriteSheet>(ArgData.Sheet);

            if (sheet.MetaData.HasValue)
                return DataSet(sheetData, Data(ArgData.Meta, sheet.MetaData), Data(ArgData.Frames, sheet.Frames));
            else
                return DataSet(sheetData, Data(ArgData.Frames, sheet.Frames));
        }

        public enum ArgData
        {
            Sheet,
            Frames,
            Meta,
        }
    }
}