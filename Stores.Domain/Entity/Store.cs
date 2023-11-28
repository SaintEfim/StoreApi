using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.Domain.Entity;

public class Store
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StoreId { get; set; }
    public string StoreName { get; set; } = null!;
    public ICollection<Address> Addresses { get; set; } = null!;
    public int AdministratorId { get; set; }
    public Administrator Administrator { get; set; } = null!;
    public int StoreTypeId { get; set; }
    public StoreType StoreType { get; set; } = null!;
    public int WorkingHoursId { get; set; }
    public WorkingHours WorkingHours { get; set; } = null!;
}