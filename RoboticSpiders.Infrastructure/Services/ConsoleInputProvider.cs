using System;
using RoboticSpiders.Application.Services;

namespace RoboticSpiders.Infrastructure.Services;

public class ConsoleInputProvider : IInputProvider
{
    public string ReadValidLine()
    {
        string? input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? throw new InvalidOperationException("Input cannot be null or whitespace.") : input;
    }
}
