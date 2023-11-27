using System.ComponentModel.DataAnnotations;

namespace Stores.Api.Models.Administrator;

public class CreateAdministratorDto
{
    [Required] public string LastName { get; set; } = default!;
    [Required] public string PhoneNumber { get; set; } = default!;
}