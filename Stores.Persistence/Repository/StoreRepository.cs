using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stores.Application.Interfaces;
using Stores.Domain.Entity;
using Stores.Persistence;

namespace Stores.Persistence.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ApplicationDbContext _context;

        public StoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Store>> GetStoresAsync()
        {
            return await _context.Stores
                .Include(s => s.Addresses)
                .Include(s => s.Administrator)
                .Include(s => s.StoreType)
                .Include(s => s.WorkingHours)
                .ToListAsync();
        }

        public async Task<Store> GetStoreAsync(int storeId, CancellationToken cancellationToken)
            => await _context.Stores
             .Include(s => s.Addresses)
             .Include(s => s.Administrator)
             .Include(s => s.StoreType)
             .Include(s => s.WorkingHours)
             .FirstOrDefaultAsync(s => s.StoreId == storeId);


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

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
