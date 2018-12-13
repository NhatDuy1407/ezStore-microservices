using Ws4vn.Microservices.ApplicationCore.Entities;

namespace ezStore.Payment.ApplicationCore.Entities
{
    public class Payment : ModelGuidIdEntity
    {
        public string Name { get; set; }
    }
}
