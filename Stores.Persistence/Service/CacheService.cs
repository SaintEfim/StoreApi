using System.Text.Json;
using StackExchange.Redis;
using Stores.Application.Interfaces.Service;

namespace Stores.Persistence.Service;

public class CacheService : ICacheService
{
    private readonly IDatabase _cacheDb;

    public CacheService()
    {
        var redis = ConnectionMultiplexer.Connect("localhost:6379");
        _cacheDb = redis.GetDatabase();
    }

    public T GetData<T>(string key)
    {
        var value = _cacheDb.StringGet(key);
        if (!string.IsNullOrEmpty(value))
        {
            return JsonSerializer.Deserialize<T>(value);
        }


        return default;
    }

    public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
    {
        var expirtyTime = expirationTime.DateTime.Subtract(DateTime.Now);

        return _cacheDb.StringSet(key, JsonSerializer.Serialize(value), expirtyTime);
    }

    public object RemoveData(string key)
    {
        if (_cacheDb.KeyExists(key))
            return _cacheDb.KeyDelete(key);

        return false;
    }
}