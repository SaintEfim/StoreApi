using System.Text.Json.Serialization;

namespace Stores.Domain.Entity;

public class StoreType
{
    public int StoreTypeId { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    public ICollection<Store> Stores { get; set; }
}