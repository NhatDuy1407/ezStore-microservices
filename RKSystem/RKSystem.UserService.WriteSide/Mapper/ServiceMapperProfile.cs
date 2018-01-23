using AutoMapper;
using RKSystem.UserService.Data.Entities;
using RKSystem.UserService.Models;

namespace RKSystem.UserService.WriteSide.Mapper
{
    public class ServiceMapperProfile : Profile
    {
        public ServiceMapperProfile()
        {
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserDto, AppUser>();
        }
    }
}
