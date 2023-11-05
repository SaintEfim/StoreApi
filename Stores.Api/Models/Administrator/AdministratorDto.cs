using Stores.Domain.Entity;

namespace Stores.Api.Models.Administrator
{
    public class AdministratorDto
    {
        public int AdministratorId { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
