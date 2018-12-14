using System;

namespace Ws4vn.Microservicess.ApplicationCore.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException(string error) : base(error)
        {

        }
    }
}
