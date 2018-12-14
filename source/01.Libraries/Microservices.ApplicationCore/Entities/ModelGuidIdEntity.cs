using System;

namespace Ws4vn.Microservicess.ApplicationCore.Entities
{
    public class ModelGuidIdEntity : ModelEntity<Guid>
    {
        public ModelGuidIdEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}