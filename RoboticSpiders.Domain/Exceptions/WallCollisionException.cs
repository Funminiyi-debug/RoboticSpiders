using System;

namespace RoboticSpiders.Domain.Exceptions;

public class WallCollisionException(
        string message
    ) : Exception(message);
