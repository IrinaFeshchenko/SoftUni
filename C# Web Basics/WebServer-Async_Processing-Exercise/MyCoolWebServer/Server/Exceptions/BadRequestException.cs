﻿namespace MyCoolWebServer.Server.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        private const string InvalidRequestMessage = "Request is not valid.";

        public BadRequestException(string message)
            : base(message)
        {       
        }

        public static object ThrowFromInvalidRequest()
            => throw new BadRequestException(InvalidRequestMessage);
    }
}
