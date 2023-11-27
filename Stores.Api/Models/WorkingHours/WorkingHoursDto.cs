namespace Stores.Api.Models.WorkingHours;

public class WorkingHoursDto
{
    public int WorkingHoursId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public DateTime OpeningTime { get; set; }
    public DateTime ClosingTime { get; set; }
}