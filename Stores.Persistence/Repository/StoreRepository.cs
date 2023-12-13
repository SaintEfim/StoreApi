using Microsoft.EntityFrameworkCore;
using Stores.Application.Interfaces.Repository;
using Stores.Domain.Entity;

namespace Stores.Persistence.Repository;

public class StoreRepository : IStoreRepository
{
    private readonly ApplicationDbContext _context;

    public StoreRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Store>> GetStores()
    {
        return await _context.Stores
            .Include(s => s.Addresses)
            .Include(s => s.Administrator)
            .Include(s => s.StoreType)
            .Include(s => s.WorkingHours)
            .ToListAsync();
    }

    public async Task<Store> GetStore(int storeId, CancellationToken cancellationToken)
    {
        return (await _context.Stores
            .Include(s => s.Addresses)
            .Include(s => s.Administrator)
            .Include(s => s.StoreType)
            .Include(s => s.WorkingHours)
            .FirstOrDefaultAsync(s => s.StoreId == storeId, cancellationToken))!;
    }


    public async Task InsertStore(Store store, CancellationToken cancellationToken)
    {
        _context.Stores.Add(store);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateStore(Store store, CancellationToken cancellationToken)
    {
        _context.Stores.Update(store);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteStore(int storeId, CancellationToken cancellationToken)
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