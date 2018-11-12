using Microservice.Core.Models;
using System;

namespace ezStore.Order.Infrastructure.Entities
{
    public class Order : ModelEntity<Guid>
    {
        public string Name { get; set; }
    }
}
