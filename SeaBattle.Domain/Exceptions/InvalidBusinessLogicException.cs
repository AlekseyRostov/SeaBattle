using System;

namespace SeaBattle.Domain.Exceptions
{
    public class InvalidBusinessLogicException : Exception
    {
        public InvalidBusinessLogicException(string message) : base(message)
        {

        }
    }
}