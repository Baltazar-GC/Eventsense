using AutoMapper;
using Eventsense;

namespace WebStarted.HR.API.DTOs.Mappers
{
    public static class APIMappingProfiles
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<GuestProfile>();
        }
    }
}
