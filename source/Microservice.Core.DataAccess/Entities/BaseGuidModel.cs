using Microservice.Core.Models;
using System;

namespace Microservice.Core.DataAccess.Entities
{
    public class BaseGuidModel : ModelEntity
    {
        public BaseGuidModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }
    }
}