using System;

namespace Ws4vn.Microservices.ApplicationCore.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException(string error) : base(error)
        {

        }
    }
}
