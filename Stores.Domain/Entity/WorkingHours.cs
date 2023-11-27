using System.Text.Json.Serialization;

namespace Stores.Domain.Entity;

public class WorkingHours
{
    public int WorkingHoursId { get; set; }
    [JsonPropertyName("dayOfWeek")] public DayOfWeek DayOfWeek { get; set; }
    [JsonPropertyName("openingTime")] public DateTime OpeningTime { get; set; }
    [JsonPropertyName("closingTime")] public DateTime ClosingTime { get; set; }
    public ICollection<Store> Stores { get; set; }
}