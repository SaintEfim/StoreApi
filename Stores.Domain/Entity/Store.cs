using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Stores.Domain.Entity
{
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreId { get; set; }
        [JsonPropertyName("storeName")]
        public string StoreName { get; set; }
        [JsonPropertyName("addresses")]
        public ICollection<Address> Addresses { get; set; }
        public int AdministratorId { get; set; }
        [JsonPropertyName("administrator")]
        public Administrator Administrator { get; set; }
        public int StoreTypeId { get; set; }
        [JsonPropertyName("storeType")]
        public StoreType StoreType { get; set; }
        public int WorkingHoursId { get; set; }
        [JsonPropertyName("workingHours")]
        public WorkingHours WorkingHours { get; set; }
    }
}
