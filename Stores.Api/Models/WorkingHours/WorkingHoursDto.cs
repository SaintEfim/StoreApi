using System.ComponentModel.DataAnnotations;

namespace Stores.Api.Models.WorkingHours;

public class WorkingHoursDto
{
    [Required]
    public int WorkingHoursId { get; set; }
    [Required]
    public DayOfWeek DayOfWeek { get; set; }
    [Required]
    public DateTime OpeningTime { get; set; }
    [Required]
    public DateTime ClosingTime { get; set; }
}