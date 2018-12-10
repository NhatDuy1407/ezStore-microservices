using Microservice.Core.Models;

namespace ezStore.Payment.ApplicationCore.Entities
{
    public class Payment : ModelGuidIdEntity
    {
        public string Name { get; set; }
    }
}
