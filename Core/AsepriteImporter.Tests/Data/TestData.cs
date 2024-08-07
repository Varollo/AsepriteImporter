using System.Collections;

namespace Varollo.AsepriteImporter.Tests
{
    public abstract class TestData<TArgEnum> : IDisposable, IEnumerable<object[]> where TArgEnum : Enum
    {
        private static readonly Dictionary<TArgEnum, object> _cachedData = new();

        public abstract IEnumerator<object[]> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            _cachedData.Clear();
            GC.SuppressFinalize(this);
        }

        protected static KeyValuePair<TArgEnum, object> Data(TArgEnum key, object value)
        {
            if (!_cachedData.TryAdd(key, value))
                _cachedData[key] = value;

            return new(key, value);
        }

        protected static T CachedData<T>(TArgEnum key)
        {
            Assert.True(_cachedData.TryGetValue(key, out var value), $"Data '{key}' must already be cached.");

            if (value is T castValue)
                return castValue;

            throw new ArgumentException(
                $"Data '{key}' is type {value.GetType().FullName} and cannot be cast to '{typeof(T).FullName}'.", nameof(T));
        }

        protected static object[] DataSet(params KeyValuePair<TArgEnum, object>[] args)
        {
            _cachedData.Clear();
            return new object[] { new Dictionary<TArgEnum, object>(args) };
        }
    }
}