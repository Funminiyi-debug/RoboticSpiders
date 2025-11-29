using RoboticSpiders.Domain.Models;
using RoboticSpiders.Application.Services;
using RoboticSpiders.Application.Commands;

namespace RoboticSpiders.Infrastructure.Services;

public class InputParser(
        ICommandFactory commandFactory
    ) : IInputParser
{
    public IEnumerable<ICommand> ParseInstructions(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) yield break;

        foreach (char c in input)
        {
            yield return commandFactory.GetCommand(c);
        }
    }
    public IWall ParseWall(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2)
            throw new ArgumentException("Invalid wall input. Expected 'x y'.");

        if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException("Invalid wall coordinates. Expected integers.");

        return new Wall(x, y);
    }

    public Position ParsePosition(string input)
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
