using Stores.Domain.Entity;

namespace Stores.Domain.Interfaces
{
    public interface IStoreService
    {
        List<Store> GetStoresByType(string storeType);
        List<Store> GetStoresByStreet(string street);
        Address GetStoreAddressByPhoneNumber(string phoneNumber);
        Store GetStoreByWorkingHours(int storeTypeId, DayOfWeek day, TimeSpan time);
        List<string> GetAdministratorsLastNameByStoreType(string storeType);
        int GetStoreTypeCount(string storeType);
    }
}

