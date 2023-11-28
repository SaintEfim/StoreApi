using System.ComponentModel.DataAnnotations;

namespace Stores.Api.Models.StoreType;

public class StoreTypeDto
{
    [Required] public string Name { get; set; } = default!;
}