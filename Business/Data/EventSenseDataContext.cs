using Eventsense.Business.Model;
using Microsoft.EntityFrameworkCore;

namespace Eventsense;

public class EventSenseDataContext : DbContext
{
    public EventSenseDataContext(DbContextOptions<EventSenseDataContext> options)
        : base(options)
    {
    }
        public DbSet<Event> Events { get; set; }
        public DbSet<Guest> Guests { get; set; }
}
