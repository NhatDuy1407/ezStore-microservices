using Microservice.Core.Models;
using System;

namespace ezStore.Payment.Infrastructure.Entities
{
    public class Payment : ModelEntity<Guid>
    {
        public string Name { get; set; }
    }
}
