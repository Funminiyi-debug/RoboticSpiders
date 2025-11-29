using System;
using RoboticSpiders.Application.Services;

namespace RoboticSpiders.Infrastructure.Services;

public class ConsoleInputProvider : IInputProvider
{
    private readonly ILogger _logger;

    public ConsoleInputProvider(ILogger logger)
    {
        _logger = logger;
    }

    public T GetInput<T>(string prompt, Func<string, T> parser)
    {
        while (true)
        {
            _logger.WriteInfo(prompt);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                _logger.WriteError("Input cannot be empty. Please try again.");
                continue;
            }

            try
            {
                return parser(input);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Invalid input: {ex.Message}. Please try again.");
            }
        }
    }
}
