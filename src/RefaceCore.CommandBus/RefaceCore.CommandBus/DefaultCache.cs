using System.Collections.Concurrent;

namespace RefaceCore.CommandBus
{
    public class DefaultCache : ICache
    {
        private static readonly ConcurrentDictionary<string, object> map = new ConcurrentDictionary<string, object>();

        public void Set<T>(string key, T data)
        {
            map.AddOrUpdate(key, data, (key, old) => data);
        }

        public bool TryGet<T>(string key, out T result)
        {
            object obj;
            if (!map.TryGetValue(key, out obj))
            {
                result = default(T);
                return false;
            }

            result = (T)obj;
            return true;
        }
    }
}
