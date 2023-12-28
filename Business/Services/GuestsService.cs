using Eventsense.Business.Model;
using Microsoft.EntityFrameworkCore;

namespace Eventsense;

public class GuestsService : IGuestsServices
{
    private readonly EventSenseDataContext dbContext;

    public GuestsService(EventSenseDataContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Guest> Create(Guest guest)
    {

        this.dbContext.Guests.Add(guest);

        await this.dbContext.SaveChangesAsync();

        return guest;
    }

    public async Task Delete(int guestId)
    {
        var guest = dbContext.Guests.FirstOrDefault(x => x.Id == guestId);

        dbContext.Guests.Remove(guest);
        
        await dbContext.SaveChangesAsync();
    }

    public Task<Guest> Get(int guestId)
    {
        return this.dbContext.Guests.FirstOrDefaultAsync(x => x.Id == guestId);;
    }

    public Task<List<Guest>> List()
    {
        return this.dbContext.Guests.ToListAsync();
    }

    public async Task<Guest> Update(Guest guest)
    {
        this.dbContext.Update(guest);

        await this.dbContext.SaveChangesAsync();

        return guest;
    }
}
