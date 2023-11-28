using System.Text.Json.Serialization;

namespace Stores.Domain.Entity;

public class Address
{
    public int AddressId { get; set; }
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public int StoreId { get; set; }
    [JsonIgnore] public Store Store { get; set; } = null!;
}