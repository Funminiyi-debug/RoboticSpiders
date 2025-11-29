using System;
using RoboticSpiders.Application.Services;

namespace RoboticSpiders.Infrastructure.Services;

public class ConsoleInputProvider : IInputProvider
{
    public T GetInput<T>(string prompt, Func<string, T> parser)
    {
        while (true)
        {
            WriteInfo(prompt);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                WriteError("Input cannot be empty. Please try again.");
                continue;
            }

            try
            {
                return parser(input);
            }
            catch (Exception ex)
            {
                WriteError($"Invalid input: {ex.Message}. Please try again.");
            }
        }
    }

    public void WriteInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void WriteWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
