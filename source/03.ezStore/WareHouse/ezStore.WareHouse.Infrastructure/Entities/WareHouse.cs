using Microservice.Core.Models;
using System;

namespace ezStore.WareHouse.Infrastructure.Entities
{
    public class WareHouse : ModelEntity<Guid>
    {
        public string Name { get; set; }
    }
}
