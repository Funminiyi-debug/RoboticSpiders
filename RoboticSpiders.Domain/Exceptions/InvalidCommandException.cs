using System;

namespace RoboticSpiders.Domain.Exceptions;

public class InvalidCommandException : Exception
{
    public InvalidCommandException(string message) : base(message)
    {
    }

    public InvalidCommandException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
