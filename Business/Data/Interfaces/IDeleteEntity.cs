namespace Eventsense;

public interface IDeleteEntity
{
    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string DeletedByUserId { get; set; }

    public string DeletedByUserName { get; set; }
}
