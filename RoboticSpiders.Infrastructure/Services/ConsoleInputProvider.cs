using RoboticSpiders.Application.Services;

namespace RoboticSpiders.Infrastructure.Services;

public class ConsoleInputProvider(
        ILogger logger
    ) : IInputProvider
{
    public T GetInput<T>(string prompt, Func<string, T> parser)
    {
        const int totalAttempts = 3;
        var attempts = 0;
        while (attempts <= totalAttempts)
        {
            logger.WriteInfo(prompt);
            var input = Console.ReadLine();

            if (input == null || string.IsNullOrWhiteSpace(input))
            {
                logger.WriteError("Input cannot be empty. Please try again.");
                attempts++;
                continue;
            }

            try
            {
                return parser(input);
            }
            catch (ArgumentException ex)
            {
                logger.WriteError($"Invalid input: {ex.Message}. Please try again.");
                attempts++;
            }
        }
        
        logger.WriteError("Maximum retries reached.");
        throw new Exception("Maximum retries reached.");
    }
}
