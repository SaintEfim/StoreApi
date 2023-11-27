﻿using System.ComponentModel.DataAnnotations;

namespace Stores.Api.Models.WorkingHours;

public class CreateWorkingHoursDto
{
    [Required]
    public DayOfWeek DayOfWeek { get; set; }
    [Required]
    public DateTime OpeningTime { get; set; }
    [Required]
    public DateTime ClosingTime { get; set; }
}