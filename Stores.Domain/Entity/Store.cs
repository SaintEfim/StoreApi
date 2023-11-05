using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.Domain.Entity
{
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public int AdministratorId { get; set; }
        public Administrator Administrator { get; set; }
        public int StoreTypeId { get; set; }
        public StoreType StoreType { get; set; }
        public int WorkingHoursId { get; set; }
        public WorkingHours WorkingHours { get; set; }
    }
}
