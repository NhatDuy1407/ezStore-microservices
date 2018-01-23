using AutoMapper;
using RKSystem.UserService.API.ViewModels;
using RKSystem.UserService.Data.Entities;
using RKSystem.UserService.Models;

namespace RKSystem.UserService.API.Mapper
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
