namespace Stores.Domain.Entity
{
    public class StoreType
    {
        public int StoreTypeId { get; set; }
        public string Name { get; set; }

        // Коллекция связей между типом магазина и магазинами
        public ICollection<Store> Stores { get; set; }
    }
}
