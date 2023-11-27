using System.ComponentModel.DataAnnotations;

namespace Stores.Api.Models.StoreType;

public class CreateStoreTypeDto
{
    [Required] public string Name { get; set; } = default!;
}