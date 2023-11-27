namespace Stores.Api.Models.WorkingHours;

public class CreateWorkingHoursDto
{
    public DayOfWeek DayOfWeek { get; set; }
    public DateTime OpeningTime { get; set; }
    public DateTime ClosingTime { get; set; }
}