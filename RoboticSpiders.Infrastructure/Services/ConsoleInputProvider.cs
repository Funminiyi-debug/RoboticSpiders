using RoboticSpiders.Application.Services;

namespace RoboticSpiders.Infrastructure.Services;

public class ConsoleInputProvider(
        ILogger logger
    ) : IInputProvider
{
    public T GetInput<T>(string prompt, Func<string, T> parser)
    {
        while (true)
        {
            logger.WriteInfo(prompt);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                logger.WriteError("Input cannot be empty. Please try again.");
                continue;
            }

            try
            {
                return parser(input);
            }
            catch (Exception ex)
            {
                logger.WriteError($"Invalid input: {ex.Message}. Please try again.");
            }
        }
    }
}
