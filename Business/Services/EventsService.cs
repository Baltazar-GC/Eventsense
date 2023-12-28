using Eventsense.Business.Model;
using Microsoft.EntityFrameworkCore;

namespace Eventsense;

public class EventsService : IEventsService
{
    private readonly EventSenseDataContext dbContext;

    public EventsService(EventSenseDataContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Event> Create(Event Event)
    {

        this.dbContext.Events.Add(Event);

        await this.dbContext.SaveChangesAsync();

        return Event;
    }

    public async Task Delete(int EventId)
    {
        var Event = dbContext.Events.FirstOrDefault(x => x.Id == EventId);

        dbContext.Events.Remove(Event);
        
        await dbContext.SaveChangesAsync();
    }

    public Task<Event> Get(int EventId)
    {
        return this.dbContext.Events.FirstOrDefaultAsync(x => x.Id == EventId);;
    }

    public Task<List<Event>> List()
    {
        return this.dbContext.Events.ToListAsync();
    }

    public async Task<Event> Update(Event Event)
    {
        this.dbContext.Update(Event);

        await this.dbContext.SaveChangesAsync();

        return Event;
    }
}
