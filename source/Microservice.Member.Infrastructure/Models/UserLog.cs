using Microservice.Core.Models;
using System;

namespace Microservice.Member.Infrastructure.Models
{
    public class UserLog : ModelEntity<Guid>
    {
        public string Content { get; set; }
    }
}
