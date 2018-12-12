using Microservices.ApplicationCore.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microservices.ApplicationCore.Validations
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