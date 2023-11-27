namespace Stores.Api.Models.Address;

public class CreateAddressDto
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
}