using Microsoft.EntityFrameworkCore;
using Stores.Persistence;
using Stores.Domain.Entity;
using Stores.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stores.Persistence.Repository
{
    public class StoreService : IStoreService
    {
        private readonly ApplicationDbContext _context;

        public StoreService(ApplicationDbContext contex)
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

            return store.Addresses.FirstOrDefault();
        }

        public Store GetStoreByWorkingHours(int storeTypeId, DayOfWeek day, TimeSpan time)
        {
            var store = _context.Stores
                .Include(s => s.WorkingHours)
                .FirstOrDefault(s => s.StoreTypeId == storeTypeId &&
                                     s.WorkingHours.DayOfWeek == day &&
                                     s.WorkingHours.OpeningTime.TimeOfDay <= time &&
                                     s.WorkingHours.ClosingTime.TimeOfDay >= time);

            return store;
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
}
