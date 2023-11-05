namespace Stores.Domain.Entity
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
