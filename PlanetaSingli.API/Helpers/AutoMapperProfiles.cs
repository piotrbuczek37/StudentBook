using System.Linq;
using AutoMapper;
using PlanetaSingli.API.Dtos;
using PlanetaSingli.API.Models;

namespace PlanetaSingli.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>().ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            }).ForMember(dest => dest.Age, opt => {
                opt.ResolveUsing(src => src.DateOfBirth.CalculateAge());
            });
            CreateMap<User, UserForDetailsDto>().ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            }).ForMember(dest => dest.Age, opt => {
                opt.ResolveUsing(src => src.DateOfBirth.CalculateAge());
            });
            CreateMap<Photo, PhotosForDetailsDto>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}