using System.ComponentModel.DataAnnotations;

namespace Stores.Api.Models.Address;

public class CreateAddressDto
{
    [Required] public string Country { get; set; } = default!;
    [Required] public string City { get; set; } = default!;
    [Required] public string Street { get; set; } = default!;
    [Required] public string PostalCode { get; set; } = default!;
}