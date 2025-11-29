using System;

namespace RoboticSpiders.Domain.Exceptions;

public class InvalidCommandException(
        string message
    ) : Exception(message);
