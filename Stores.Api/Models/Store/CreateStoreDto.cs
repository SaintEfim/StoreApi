using System.ComponentModel.DataAnnotations;
using Stores.Api.Models.Address;
using Stores.Api.Models.Administrator;
using Stores.Api.Models.StoreType;
using Stores.Api.Models.WorkingHours;

namespace Stores.Api.Models.Store;

public class CreateStoreDto
{
    [Required] public string StoreName { get; set; } = default!;
    [Required] public ICollection<AddressDto> Addresses { get; set; } = default!;
    [Required] public AdministratorDto Administrator { get; set; } = default!;
    [Required] public StoreTypeDto StoreType { get; set; } = default!;
    [Required] public WorkingHoursDto WorkingHours { get; set; } = default!;
}