using System;

namespace RoboticSpiders.Domain.Exceptions;

public class WallCollisionException : Exception
{
    public WallCollisionException(string message) : base(message)
    {
    }

    public WallCollisionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
