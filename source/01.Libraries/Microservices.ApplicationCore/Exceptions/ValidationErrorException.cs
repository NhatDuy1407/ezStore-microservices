using System;

namespace Microservices.ApplicationCore.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException(string error) : base(error)
        {

        }
    }
}
