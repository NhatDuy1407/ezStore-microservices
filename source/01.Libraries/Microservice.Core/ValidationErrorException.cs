using System;

namespace Microservice.Core
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException(string error) : base(error)
        {

        }
    }
}
