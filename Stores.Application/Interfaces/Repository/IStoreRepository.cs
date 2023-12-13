using Stores.Domain.Entity;

namespace Stores.Application.Interfaces.Repository;

public interface IStoreRepository
{
    Task<ICollection<Store>> GetStores();
    Task<Store> GetStore(int id, CancellationToken cancellationToken);
    Task InsertStore(Store store, CancellationToken cancellationToken);
    Task UpdateStore(Store store, CancellationToken cancellationToken);
    Task DeleteStore(int id, CancellationToken cancellationToken);
}