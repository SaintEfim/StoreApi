namespace Stores.Domain.Entity;

public class StoreType
{
    public int StoreTypeId { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Store> Stores { get; set; } = null!;
}