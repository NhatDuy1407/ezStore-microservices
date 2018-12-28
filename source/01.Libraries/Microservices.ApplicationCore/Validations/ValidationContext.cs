using Ws4vn.Microservices.ApplicationCore.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ws4vn.Microservices.ApplicationCore.Validations
{
    public class ValidationContext : IValidationContext
    {
        private readonly IList<string> _errorMessages;

        public ValidationContext()
        {
            _errorMessages = new List<string>();
        }

        public void AddValidationError(string erorrMessage)
        {
            _errorMessages.Add(erorrMessage);
        }

        public string FormatValidationError()
        {
            return JsonConvert.SerializeObject(_errorMessages);
        }
    }
}