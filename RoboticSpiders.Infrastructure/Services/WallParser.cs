using RoboticSpiders.Application.Services;
using RoboticSpiders.Domain.Models;

namespace RoboticSpiders.Infrastructure.Services;

public class WallParser : IWallParser
{
    public IWall Parse(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2)
            throw new ArgumentException("Invalid wall input. Expected 'x y'.");

        if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException("Invalid wall coordinates. Expected integers.");

        return new Wall(x, y);
    }
}
