namespace Eventsense.DTOs.Guest;

public class UpdateGuest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Vegan { get; set; }
    public bool Confirmed { get; set; }
    public int? Age { get; set; }
    public string Email { get; set; }
}

