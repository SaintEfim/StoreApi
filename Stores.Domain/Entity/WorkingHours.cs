using System.Text.Json.Serialization;

namespace Stores.Domain.Entity
{
    public class WorkingHours
    {
        public int WorkingHoursId { get; set; }
        [JsonPropertyName("dayOfWeek")]
        public DayOfWeek DayOfWeek { get; set; }
        [JsonPropertyName("openingTime")]
        public DateTime OpeningTime { get; set; }
        [JsonPropertyName("closingTime")]
        public DateTime ClosingTime { get; set; }

        // Связь с магазином (многие рабочие часы могут принадлежать одному магазину) 
        public ICollection<Store> Stores { get; set; }
    }
}
