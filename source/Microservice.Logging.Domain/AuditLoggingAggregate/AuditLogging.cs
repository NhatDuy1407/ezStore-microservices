using System;
using Microservice.Core.Models;

namespace Microservice.Logging.Domain.AuditLoggingAggregate
{
    public class AuditLogging : DomainEntity
    {
        public AuditLogging()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public string Content { get; set; }
    }
}