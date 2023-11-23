using Stores.Domain.Entity;

namespace Stores.Application.Interfaces
{
    public interface IStoreRepository
    {
        Task<ICollection<Store>> GetStoresAsync();
        Task<Store> GetStoreAsync(int Id);
        Task InsertStoreAsync(Store store);
        Task UpdateStoreAsync(Store store);
        Task DeleteStoreAsync(int Id);
        Task SaveAsync();
    }
}
