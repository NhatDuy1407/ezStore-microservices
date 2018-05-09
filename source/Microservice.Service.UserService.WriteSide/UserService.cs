using System;
using System.Linq;
using Microservice.Core.DataAccess.MongoDB;
using Microservice.Service.UserService.Models;
using Microsoft.Extensions.Configuration;
using Microservice.Service.UserService.WriteSide.Interfaces;
using Microservice.Service.UserService.Entities;

namespace Microservice.Service.UserService.WriteSide
{
    public class UserService : WriteService, IWriteUserService
    {
        public UserService(IConfiguration configuration) :
            base(new MongoDbContext(configuration.GetConnectionString("DefaultConnection"), configuration.GetConnectionString("DefaultDatabaseName"), false))
        {
        }

        public Guid Add(AppUserDto entity)
        {
            var user = new AppUser();
            user.Update(entity, "admin");
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
