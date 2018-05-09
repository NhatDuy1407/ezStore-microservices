using AutoMapper;
using Microservice.Service.UserService.API.ViewModels;
using Microservice.Service.UserService.Models;

namespace Microservice.Service.UserService.API.Mapper
{
    public class ServiceMapperProfile : Profile
    {
        public ServiceMapperProfile()
        {
            CreateMap<UserVm, AppUserDto>();
            CreateMap<AppUserDto, UserVm>();
        }
    }
}
