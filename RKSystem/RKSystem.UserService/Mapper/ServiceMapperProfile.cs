using AutoMapper;
using RKSystem.UserService.Data.Entities;
using RKSystem.UserService.Models;

namespace RKSystem.UserService.Mapper
{
    public class ServiceMapperProfile : Profile
    {
        public ServiceMapperProfile()
        {
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserDto, AppUser>().ForMember(x => x._id, opt => opt.Ignore());
        }
    }
}
