using System;

namespace RKSystem.DataAccess.Entities
{
    public class BaseGuidModel : BaseModel
    {
        public BaseGuidModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }
    }
}