namespace RefaceCore.CommandBus
{
    public interface ICache
    {
        bool TryGet<T>(string key, out T result);

        void Set<T>(string key, T data);
    }
}
