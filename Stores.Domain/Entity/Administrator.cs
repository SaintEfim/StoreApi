using System.Text.Json.Serialization;

namespace Stores.Domain.Entity
{
    public class Administrator
    {
        public int AdministratorId { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
        public ICollection<Store> Stores { get; set; }
    }
}
