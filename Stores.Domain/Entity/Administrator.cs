namespace Stores.Domain.Entity;

public class Administrator
{
    public int AdministratorId { get; set; }
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public ICollection<Store> Stores { get; set; } = null!;
}