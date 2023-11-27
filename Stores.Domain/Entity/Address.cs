using System.Text.Json.Serialization;

namespace Stores.Domain.Entity;

public class Address
{
    public int AddressId { get; set; }
    [JsonPropertyName("country")] public string Country { get; set; }
    [JsonPropertyName("city")] public string City { get; set; }
    [JsonPropertyName("street")] public string Street { get; set; }
    [JsonPropertyName("postalCode")] public string PostalCode { get; set; }
    public int StoreId { get; set; }
    public Store Store { get; set; }
}