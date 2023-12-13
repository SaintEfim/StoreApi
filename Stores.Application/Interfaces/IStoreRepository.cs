using Stores.Domain.Entity;

namespace Stores.Application.Interfaces
{
    public interface IStoreRepository
    {
        Task<ICollection<Store>> GetStoresAsync();
        Task<Store> GetStoreAsync(int dictionaryId);
        Task InsertStoreAsync(Store store);
        Task UpdateStoreAsync(Store store);
        Task DeleteStoreAsync(int dictionaryId);
        Task SaveAsync();
    }
}
