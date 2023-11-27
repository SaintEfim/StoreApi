using System.ComponentModel.DataAnnotations;

namespace Stores.Api.Models.Storetype;

public class StoreTypeDto
{
    [Required] public int StoreTypeId { get; set; }
    [Required] public string Name { get; set; } = default!;
}