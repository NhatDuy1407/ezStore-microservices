﻿using Microservice.Core.DomainService.Commands;
using System;

namespace ezStore.WareHouse.Domain.Application.Commands
{
    public class DeleteWareHouseCommand : ValidationDecoratorCommand
    {
        public Guid Id { get; set; }

        public DeleteWareHouseCommand(Guid id)
        {
            this.Id = id;
        }
        public override bool SelfValidate()
        {
            return true;
        }
    }
}
