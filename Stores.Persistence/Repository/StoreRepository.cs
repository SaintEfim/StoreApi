using Microsoft.EntityFrameworkCore;
using Stores.Application.Interfaces;
using Stores.Application.Interfaces.Repository;
using Stores.Application.Interfaces.Service;
using Stores.Domain.Entity;

namespace Stores.Persistence.Repository;

public class StoreRepository : IStoreRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ICacheSerivce _cacheSerivce;
    public StoreRepository(ApplicationDbContext context, ICacheSerivce cacheSerivce)
    {
        _context = context;
        _cacheSerivce = cacheSerivce;
    }

    public async Task<ICollection<Store>> GetStoresAsync()
    {
        var cacheData = _cacheSerivce.GetData<ICollection<Store>>("stores");

        if (cacheData != null && cacheData.Count() > 0)
            return cacheData;

        cacheData = await _context.Stores
            .Include(s => s.Addresses)
            .Include(s => s.Administrator)
            .Include(s => s.StoreType)
            .Include(s => s.WorkingHours)
            .ToListAsync();

        var expiryTime = DateTimeOffset.Now.AddSeconds(5);
        _cacheSerivce.SetData<ICollection<Store>>("stores", cacheData, expiryTime);

        return cacheData;
    }

    public async Task<Store> GetStoreAsync(int storeId, CancellationToken cancellationToken)
    {
        return (await _context.Stores
            .Include(s => s.Addresses)
            .Include(s => s.Administrator)
            .Include(s => s.StoreType)
            .Include(s => s.WorkingHours)
            .FirstOrDefaultAsync(s => s.StoreId == storeId, cancellationToken))!;
    }



    public async Task InsertStoreAsync(Store store, CancellationToken cancellationToken)
    {
        _context.Stores.Add(store);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateStoreAsync(Store store, CancellationToken cancellationToken)
    {
        _context.Stores.Update(store);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteStoreAsync(int storeId, CancellationToken cancellationToken)
    {
        var store = await _context.Stores.FindAsync(storeId);
        if (store != null)
        {
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}