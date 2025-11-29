using System;
using System.Collections.Generic;
using RoboticSpiders.Domain.Models;
using RoboticSpiders.Application.Services;
using RoboticSpiders.Application.Commands;

namespace RoboticSpiders.Infrastructure.Services;

public class InputParser : IInputParser
{
    public IWall ParseWall(string input)
    {
        var parts = input.Split(' ');
        if (parts.Length != 2)
            throw new ArgumentException("Invalid wall input. Expected 'x y'.");

        if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException("Invalid wall coordinates. Expected integers.");

        return new Wall(x, y);
    }

    public IPosition ParsePosition(string input)
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

    public List<ICommand> ParseInstructions(string input)
    {
        var commands = new List<ICommand>();
        foreach (char c in input)
        {
            switch (char.ToUpper(c))
            {
                case 'L':
                    commands.Add(new TurnLeftCommand());
                    break;
                case 'R':
                    commands.Add(new TurnRightCommand());
                    break;
                case 'F':
                    commands.Add(new MoveForwardCommand());
                    break;
                default:
                    throw new ArgumentException($"Invalid instruction '{c}'. Expected 'L', 'R', or 'F'.");
            }
        }
        return commands;
    }
}
