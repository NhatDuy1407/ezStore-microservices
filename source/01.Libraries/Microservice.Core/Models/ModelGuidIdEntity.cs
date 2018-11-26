using System;

namespace Microservice.Core.Models
{
    public class ModelGuidIdEntity : ModelEntity<Guid>
    {
        public ModelGuidIdEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}