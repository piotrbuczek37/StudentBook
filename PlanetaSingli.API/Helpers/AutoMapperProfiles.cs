using AutoMapper;
using PlanetaSingli.API.Dtos;
using PlanetaSingli.API.Models;

namespace PlanetaSingli.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailsDto>();
        }
    }
}