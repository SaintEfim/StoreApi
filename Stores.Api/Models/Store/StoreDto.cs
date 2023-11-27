using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using Stores.Api.Models.Address;
using Stores.Api.Models.Administrator;
using Stores.Api.Models.Storetype;
using Stores.Api.Models.WorkingHours;
using Stores.Domain.Entity;

namespace Stores.Api.Models.Store
{
    public class StoreDto
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public ICollection<AddressDto> Addresses { get; set; }
        public AdministratorDto Administrator { get; set; }
        public StoreTypeDto StoreType { get; set; }
        public WorkingHoursDto WorkingHours { get; set; }
    }
}
