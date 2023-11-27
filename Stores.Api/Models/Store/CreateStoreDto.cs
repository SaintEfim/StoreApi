using Stores.Api.Models.Address;
using Stores.Api.Models.Administrator;
using Stores.Api.Models.StoreType;
using Stores.Api.Models.WorkingHours;
using Stores.Api.Models.Storetype;

namespace Stores.Api.Models.Store
{
    public class CreateStoreDto
    {
        public string StoreName { get; set; }
        public ICollection<CreateAddressDto> Addresses { get; set; }
        public CreateAdministratorDto Administrator { get; set; }
        public CreateStoreTypeDto StoreType { get; set; }
        public CreateWorkingHoursDto WorkingHours { get; set; }
    }
}
