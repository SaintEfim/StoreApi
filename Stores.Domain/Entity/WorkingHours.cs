using System.Text.Json.Serialization;

namespace Stores.Domain.Entity;

public class WorkingHours
{
    public int WorkingHoursId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public DateTime OpeningTime { get; set; }
    public DateTime ClosingTime { get; set; }
    [JsonIgnore] public ICollection<Store> Stores { get; set; } = null!;
}