using System;

namespace SeaBattle.Domain.Exceptions
{
    public class InvalidParsedCoordinatesException : Exception
    {
        public InvalidParsedCoordinatesException(string message) : base(message)
        {
        }
    }
}