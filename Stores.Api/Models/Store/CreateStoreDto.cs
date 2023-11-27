using System.ComponentModel.DataAnnotations;
using Stores.Api.Models.Address;
using Stores.Api.Models.Administrator;
using Stores.Api.Models.StoreType;
using Stores.Api.Models.WorkingHours;

namespace Stores.Api.Models.Store;

public class CreateStoreDto
{
    [Required] public string StoreName { get; set; } = default!;
    [Required] public ICollection<CreateAddressDto> Addresses { get; set; } = default!;
    [Required] public CreateAdministratorDto Administrator { get; set; } = default!;
    [Required] public CreateStoreTypeDto StoreType { get; set; } = default!;
    [Required] public CreateWorkingHoursDto WorkingHours { get; set; } = default!;
}