﻿using System.Threading.Tasks;
using Microservice.Core.DomainService;
using Microservice.Core.DomainService.Interfaces;
using Microservice.Member.Domain.MemberAggregate;

namespace Microservice.Member.Domain.Application.Commands
{
    public class MemberCommandHandler : ICommandHandler<UpdateUserLoginCommand>
    {
        private readonly IDomainService _domainService;

        public MemberCommandHandler(IDomainService domainService)
        {
            _domainService = domainService;
        }

        public Task ExecuteAsync(UpdateUserLoginCommand command)
        {
            var user = new UserDomain(_domainService.WriteService) { Username = command.Email };
            user.Login();
            _domainService.ApplyChanges(user);
            _domainService.SaveChanges();
            return Task.CompletedTask;
        }
    }
}