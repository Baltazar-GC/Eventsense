using AutoMapper;
using Eventsense.DTOs.Guest;

namespace Eventsense;

public class GuestProfile : Profile
{
    public GuestProfile()
    {
        CreateMap<UpdateGuest, Eventsense.Business.Model.Guest>();

        CreateMap<CreateGuest, Eventsense.Business.Model.Guest>();

        CreateMap<Eventsense.Business.Model.Guest, Guest>();
    }
}
