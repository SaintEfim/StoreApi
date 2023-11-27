using Stores.Domain.Entity;

namespace Stores.Application.Interfaces;

public interface IStoreInfoRepository
{
    List<Store> GetStoresByType(string storeType);
    List<Store> GetStoresByStreet(string street);
    Address GetStoreAddressByPhoneNumber(string phoneNumber);
    Store GetStoreByWorkingHours(int storeTypeId, DayOfWeek day, TimeSpan time);
    List<string> GetAdministratorsLastNameByStoreType(string storeType);
    int GetStoreTypeCount(string storeType);
}