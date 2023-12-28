using AutoMapper;
using Eventsense.DTOs.Event;

namespace Eventsense;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<UpdateEvent, Eventsense.Business.Model.Event>();

        CreateMap<CreateEvent, Eventsense.Business.Model.Event>();

        CreateMap<Eventsense.Business.Model.Event, Event>();
    }
}
