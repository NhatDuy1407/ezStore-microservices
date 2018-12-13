using System;

namespace Microservices.ApplicationCore.Entities
{
    public class ModelGuidIdEntity : ModelEntity<Guid>
    {
        public ModelGuidIdEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}