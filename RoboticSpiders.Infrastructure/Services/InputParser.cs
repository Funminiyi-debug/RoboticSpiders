using System;
using System.Collections.Generic;
using RoboticSpiders.Domain.Models;
using RoboticSpiders.Application.Services;
using RoboticSpiders.Application.Commands;

namespace RoboticSpiders.Infrastructure.Services;

public class InputParser : IInputParser
{
    private readonly Dictionary<char, Func<ICommand>> _commandMap = new()
    {
        { 'L', () => new TurnLeftCommand() },
        { 'R', () => new TurnRightCommand() },
        { 'F', () => new MoveForwardCommand() }
    };

    public IEnumerable<ICommand> ParseInstructions(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) yield break;

        foreach (char c in input)
        {
            var key = char.ToUpperInvariant(c);
            if (_commandMap.TryGetValue(key, out var factory))
            {
                yield return factory();
            }
            else
            {
                throw new ArgumentException($"Unknown command: {c}");
            }
        }
    }
    public IWall ParseWall(string input)
    {
        var parts = input.Split(' ');
        if (parts.Length != 2)
            throw new ArgumentException("Invalid wall input. Expected 'x y'.");

        if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException("Invalid wall coordinates. Expected integers.");

        return new Wall(x, y);
    }

    public Position ParsePosition(string input)
    {
        var parts = input.Split(' ');
        if (parts.Length != 3)
            throw new ArgumentException("Invalid position input. Expected 'x y Orientation'.");

        if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException("Invalid position coordinates. Expected integers.");

        if (!Enum.TryParse(parts[2], true, out Orientation orientation))
            throw new ArgumentException("Invalid orientation. Expected 'Left', 'Right', 'Up', or 'Down'.");

        return new Position(x, y, orientation);
    }
}
