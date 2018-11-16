﻿using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DomainService.Models;
using Microservice.Member.Infrastructure.Models;

namespace Microservice.Member.Domain.MemberAggregate
{
    public class UserDomain : AggregateRoot
    {
        private readonly IDataAccessWriteService writeService;

        public UserDomain(IDataAccessWriteService writeService)
        {
            this.writeService = writeService;
        }

        public string Username { get; set; }

        public void Login()
        {
            writeService.Repository<UserLog>().Insert(new UserLog() { Content = Username + " loged in." });
            writeService.SaveChanges();
        }
    }
}