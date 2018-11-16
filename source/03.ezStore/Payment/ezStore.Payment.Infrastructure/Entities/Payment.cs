using Microservice.Core.Models;
using System;

namespace ezStore.Payment.Infrastructure.Entities
{
    public class Payment : ModelGuidIdEntity
    {
        public string Name { get; set; }
    }
}
