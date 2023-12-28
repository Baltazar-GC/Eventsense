namespace Eventsense.Business.Model;

public class Event : IEntity, IDeleteEntity, IActivityTrackEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int CreatedByUserId { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int UpdatedByUserId { get; set; }
    public string City { get; set; }
    public string EventVenue { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string DeletedByUserId { get; set; }
    public string DeletedByUserName { get; set; }
    public string CreatedByUserName { get; set; }
    public string UpdatedByUserName { get; set; }
    DateTime? IActivityTrackEntity.UpdatedAt { get; set; }
    string IActivityTrackEntity.CreatedByUserId { get; set; }
    string IActivityTrackEntity.UpdatedByUserId { get; set; }
}
