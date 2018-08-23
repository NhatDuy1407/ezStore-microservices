using Microservice.Core.Models;
using System;

namespace Microservice.Core.DataAccess.Entities
{
    public class BaseGuidModel : ModelEntity<Guid>
    {
        public BaseGuidModel()
        {
            Id = Guid.NewGuid();
        }
    }
}