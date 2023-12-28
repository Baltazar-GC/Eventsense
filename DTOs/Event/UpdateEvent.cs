using System.ComponentModel.DataAnnotations;

namespace Eventsense.DTOs.Event;

public class UpdateEvent
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public string City { get; set; }
    public string EventVenue { get; set; }
}
