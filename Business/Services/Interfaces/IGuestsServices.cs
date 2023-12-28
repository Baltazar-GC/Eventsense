using Eventsense.Business.Model;

namespace Eventsense;

public interface IGuestsServices
{
    Task<Guest> Get(int guestId);
    
    Task<List<Guest>> List();


    Task<Guest> Create(Guest guest);


    Task<Guest> Update(Guest guest);
    

    Task Delete(int guestId);
}
