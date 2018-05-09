using AutoMapper;
using Microservice.Service.UserService.Entities;
using Microservice.Service.UserService.Models;

namespace Microservice.Service.UserService.Mapper
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
