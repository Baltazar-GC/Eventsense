namespace Eventsense.Business.Model;

public class Guest : IEntity, IDeleteEntity, IActivityTrackEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Vegan { get; set; }
    public bool Confirmed { get; set; }
    public int? Age { get; set; }
    public string Email { get; set; }
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string DeletedByUserId { get; set; }
    public string DeletedByUserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string CreatedByUserId { get; set; }
    public string CreatedByUserName { get; set; }
    public string UpdatedByUserId { get; set; }
    public string UpdatedByUserName { get; set; }
}
