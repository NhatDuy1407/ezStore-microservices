using Microservice.Core.Models;

namespace ezStore.Payment.Infrastructure.Entities
{
    public class Payment : ModelGuidIdEntity
    {
        public string Name { get; set; }
    }
}
