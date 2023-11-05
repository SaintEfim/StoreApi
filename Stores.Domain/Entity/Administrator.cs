namespace Stores.Domain.Entity
{
    public class Administrator
    {
        public int AdministratorId { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        // Связь с магазином (один администратор может управлять многими магазинами)
        public ICollection<Store> Stores { get; set; }
    }
}
