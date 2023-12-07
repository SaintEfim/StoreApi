using Microsoft.EntityFrameworkCore;
using Stores.Application.Common.Exceptions;
using Stores.Domain.Entity;
using Stores.Application.Interfaces.Repository;

namespace Stores.Persistence.Repository;

public class StoreInfoRepository : IStoreInfoRepository
{
    private readonly ApplicationDbContext _context;

    public StoreInfoRepository(ApplicationDbContext contex)
    {
        _context = contex;
    }

    public List<Store> GetStoresByType(string storeType)
    {
        var stores = _context.Stores
            .Where(s => s.StoreType.Name == storeType)
            .Include(s => s.Addresses)
            .Include(s => s.Administrator)
            .Include(s => s.StoreType)
            .Include(s => s.WorkingHours)
            .ToList();

        return stores;
    }

    public List<Store> GetStoresByStreet(string street)
    {
        var stores = _context.Stores
            .Where(s => s.Addresses.Any(a => a.Street == street))
            .Include(s => s.Addresses)
            .Include(s => s.Administrator)
            .Include(s => s.StoreType)
            .Include(s => s.WorkingHours)
            .ToList();

        return stores;
    }

    public Address GetStoreAddressByPhoneNumber(string phoneNumber)
    {
        var store = _context.Stores
            .Include(s => s.Addresses)
            .Include(s => s.Administrator)
            .FirstOrDefault(s => s.Administrator.PhoneNumber == phoneNumber);

        if (store != null)
        {
            var addresses = store.Addresses;
            if (addresses.Any())
            {
                return addresses.First();
            }
        }

        throw new NotFoundException(nameof(Address), phoneNumber);
    }


    public Store GetStoreByWorkingHours(int storeTypeId, DayOfWeek day, TimeSpan time)
    {
        var store = _context.Stores
            .Include(s => s.WorkingHours)
            .FirstOrDefault(s => s.StoreTypeId == storeTypeId &&
                                 s.WorkingHours.DayOfWeek == day &&
                                 s.WorkingHours.OpeningTime.TimeOfDay <= time &&
                                 s.WorkingHours.ClosingTime.TimeOfDay >= time);

        if (store != null)
        {
            return store;
        }
        
        throw new NotFoundException(nameof(Store), storeTypeId);
    }

    public List<string> GetAdministratorsLastNameByStoreType(string storeType)
    {
        var administrators = _context.Stores
            .Where(s => s.StoreType.Name == storeType)
            .Select(s => s.Administrator.LastName)
            .ToList();

        return administrators;
    }

    public int GetStoreTypeCount(string storeType)
    {
        return _context.Stores
            .Count(s => s.StoreType.Name == storeType);
    }
}