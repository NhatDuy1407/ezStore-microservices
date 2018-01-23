using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using RKSystem.DataAccess.MongoDB;
using RKSystem.DataAccess.MongoDB.Interfaces;
using RKSystem.UserService.Data.Entities;
using RKSystem.UserService.Models;
using RKSystem.UserService.WriteSide.Interfaces;

namespace RKSystem.UserService.WriteSide
{
    public class UserService : BaseService, IUserService
    {
        public UserService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var defaultConnection = configuration["ConnectionStrings:DefaultConnection"];
            var defaultDatabaseName = configuration["ConnectionStrings:DefaultDatabaseName"];

            UnitOfWork = new WriteUnitOfWork(new MongoDbContext(defaultConnection, defaultDatabaseName, false));
        }

        public UserService(IWriteUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Add(AppUserDto entity)
        {
            var user = AutoMapper.Mapper.Map<AppUser>(entity);
            UnitOfWork.Repository<AppUser>().Insert(user);
        }

        public void Delete(Guid id)
        {
            UnitOfWork.Repository<AppUser>().Delete(i => i.Id == id);
        }
    }
}
