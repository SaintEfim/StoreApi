namespace Stores.Application.Interfaces.Service;

public interface ICacheSerivce
{
    T GetData<T>(string key);
    bool SetData<T>(string key, T value, DateTimeOffset expirationTime);
    object RemoveData(string key);
}