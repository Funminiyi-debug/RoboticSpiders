using RoboticSpiders.Application.Services;
using RoboticSpiders.Domain.Models;

namespace RoboticSpiders.Infrastructure.Services;

public class PositionParser : IPositionParser
{
    public Position Parse(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 3)
            throw new ArgumentException("Invalid position input. Expected 'x y Orientation'.");

        if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException("Invalid position coordinates. Expected integers.");

        if (!Enum.TryParse(parts[2], true, out Orientation orientation))
            throw new ArgumentException("Invalid orientation. Expected 'Left', 'Right', 'Up', or 'Down'.");

        return new Position(x, y, orientation);
    }
}
