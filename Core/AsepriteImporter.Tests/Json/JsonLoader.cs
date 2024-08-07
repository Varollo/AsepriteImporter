namespace Varollo.AsepriteImporter.Tests
{
    public class JsonLoader : IDisposable
    {
        #region Singleton
        private static JsonLoader? _instance;
        private JsonLoader() { }
        private static JsonLoader Instance => _instance ??= new();
        #endregion

        private readonly Dictionary<string, AsepriteSheet> _loadedData = new();

        public static AsepriteSheet LoadSheet(string path)
        {
            if (!Instance._loadedData.TryGetValue(path, out var sheet))
            {
                Assert.True(File.Exists(path), $"No file at path: '{path}'");
                sheet = AsepriteDataLoader.LoadJsonData(path);
            }

            return sheet;
        }

        public void Dispose()
        {
            _loadedData.Clear();
            _instance = null;

            GC.SuppressFinalize(this);
        }
    }
}