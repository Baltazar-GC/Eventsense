using System.ComponentModel.DataAnnotations;

namespace Eventsense.DTOs.Guest;

public class CreateGuest
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public bool Vegan { get; set; }
    public bool Confirmed { get; set; }
    public int? Age { get; set; }
    public string Email { get; set; }
}
