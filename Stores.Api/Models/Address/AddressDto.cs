using System.ComponentModel.DataAnnotations;

namespace Stores.Api.Models.Address;

public class AddressDto
{
    [Required]
    public int AddressId { get; set; }

    [Required] public string Country { get; set; } = default!;
    [Required] public string City { get; set; } = default!;
    [Required] public string Street { get; set; } = default!;
    [Required] public string PostalCode { get; set; } = default!;
}