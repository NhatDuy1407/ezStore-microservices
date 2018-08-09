using System;

namespace Microservice.Core.Service
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException(string error) : base(error)
        {

        }
    }
}
