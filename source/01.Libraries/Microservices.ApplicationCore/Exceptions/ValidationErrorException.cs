﻿using System;
using System.Runtime.Serialization;

namespace Ws4vn.Microservices.ApplicationCore.Exceptions
{
    [Serializable]
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException()
        {

        }

        public ValidationErrorException(string message) : base(message)
        {

        }

        public ValidationErrorException(string message, Exception innerException) : base(message, innerException)
        {

        }

        protected ValidationErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
