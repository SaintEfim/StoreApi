using Stores.Domain.Entity;

namespace Stores.Application.Interfaces;

public interface IStoreRepository
{
    Task<ICollection<Store>> GetStoresAsync();
    Task<Store> GetStoreAsync(int id);
    Task InsertStoreAsync(Store store, CancellationToken cancellationToken);
    Task UpdateStoreAsync(Store store, CancellationToken cancellationToken);
    Task DeleteStoreAsync(int id, CancellationToken cancellationToken);
}