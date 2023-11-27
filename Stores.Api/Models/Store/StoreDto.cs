using Stores.Api.Models.Address;
using Stores.Api.Models.Administrator;
using Stores.Api.Models.Storetype;
using Stores.Api.Models.WorkingHours;
using System.ComponentModel.DataAnnotations;

namespace Stores.Api.Models.Store;

public class StoreDto
{
    [Required]
    public int StoreId { get; set; }
    [Required]
    public string StoreName { get; set; } = default!;
    [Required]
    public ICollection<AddressDto> Addresses { get; set; } = default!;
    [Required]
    public AdministratorDto Administrator { get; set; } = default!;
    [Required]
    public StoreTypeDto StoreType { get; set; } = default!;
    [Required]
    public WorkingHoursDto WorkingHours { get; set; } = default!;
}