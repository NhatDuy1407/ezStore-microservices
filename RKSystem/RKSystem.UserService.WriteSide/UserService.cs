using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RKSystem.DataAccess.MongoDB;
using RKSystem.UserService.Data.Entities;
using RKSystem.UserService.Models;
using RKSystem.UserService.WriteSide.Interfaces;

namespace RKSystem.UserService.WriteSide
{
    public class UserService : WriteService, IUserService
    {
        public UserService(IConfiguration configuration) :
            base(new MongoDbContext(configuration.GetConnectionString("DefaultConnection"), configuration.GetConnectionString("DefaultDatabaseName"), false))
        {
        }

        public Guid Add(AppUserDto entity)
        {
            var user = AutoMapper.Mapper.Map<AppUser>(entity);
            if (!Repository<AppUser>().Get(i => i.Id == user.Id).Any())
            {
                Repository<AppUser>().Insert(user);
            }
            return user.Id;
        }

        public void Delete(Guid id)
        {
            Repository<AppUser>().Delete(i => i.Id == id);
        }
    }
}
