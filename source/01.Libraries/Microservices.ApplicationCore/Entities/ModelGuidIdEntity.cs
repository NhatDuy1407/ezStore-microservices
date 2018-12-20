using System;

namespace Ws4vn.Microservices.ApplicationCore.Entities
{
    public class ModelGuidIdEntity : ModelEntity<Guid>
    {
        public ModelGuidIdEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}