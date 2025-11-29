using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RoboticSpiders.Domain.Models;
using RoboticSpiders.Application.Services;
using RoboticSpiders.Infrastructure.Services;
using RoboticSpiders.Domain.Exceptions;

namespace RoboticSpiders;

class Program
{
    private static void Main(string[] args)
    {
        // Setup Dependency Injection
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ILogger, ConsoleLogger>()
            .AddSingleton<IInputProvider, ConsoleInputProvider>()
            .AddSingleton<IInputParser, InputParser>()
            .AddSingleton<MissionControl>()
            .BuildServiceProvider();

        try
        {
            // Resolve Services
            var logger = serviceProvider.GetRequiredService<ILogger>();
            var inputProvider = serviceProvider.GetRequiredService<IInputProvider>();
            var parser = serviceProvider.GetRequiredService<IInputParser>();
            var missionControl = serviceProvider.GetRequiredService<MissionControl>();

            const string wallInputMessage = "Enter Wall Size (e.g., '7 15'):";
            const string positionInputMessage = "Enter Spider Position (e.g., '4 10 Left'):";
            const string instructionsInputMessage = "Enter Instructions (e.g., 'FLFLFRFFLF'):";


            IWall wall = inputProvider.GetInput(wallInputMessage, parser.ParseWall);
            Position position = inputProvider.GetInput(positionInputMessage, parser.ParsePosition);
            var commands = inputProvider.GetInput(instructionsInputMessage, parser.ParseInstructions);

            IMovable spider = new Spider(position, wall);

            missionControl.ExecuteMissionAsync(spider, commands);

            logger.WriteInfo($"Final Position: {spider.Position}");
        }
        catch (InvalidCommandException ex)
        {
            var logger = serviceProvider.GetRequiredService<ILogger>();
            logger.WriteError($"Command Error: {ex.Message}");
        }
        catch (WallCollisionException ex)
        {
            var logger = serviceProvider.GetRequiredService<ILogger>();
            logger.WriteError($"Collision Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            var logger = serviceProvider.GetRequiredService<ILogger>();
            logger.WriteError($"Critical Error: {ex.Message}");
        }
    }
}
