namespace Eventsense;

public interface IActivityTrackEntity
{
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string CreatedByUserId { get; set; }

    public string CreatedByUserName { get; set; }

    public string UpdatedByUserId { get; set; }

    public string UpdatedByUserName { get; set; }
}
