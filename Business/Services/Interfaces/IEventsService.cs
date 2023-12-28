using Eventsense.Business.Model;

namespace Eventsense;

public interface IEventsService
{
    Task<Event> Get(int eventId);
    
    Task<List<Event>> List();


    Task<Event> Create(Event guest);


    Task<Event> Update(Event guest);
    

    Task Delete(int eventId);
}
