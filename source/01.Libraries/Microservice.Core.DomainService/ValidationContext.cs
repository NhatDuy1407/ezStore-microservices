using Microservice.Core.DomainService.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Microservice.Core.DomainService
{
    public class ValidationContext : IValidationContext
    {
        private readonly IList<string> ErrorMessages;

        public ValidationContext()
        {
            ErrorMessages = new List<string>();
        }

        public void AddValidationError(string erorrMessage)
        {
            ErrorMessages.Add(erorrMessage);
        }

        public string FormatValidationError()
        {
            return JsonConvert.SerializeObject(ErrorMessages);
        }
    }
}