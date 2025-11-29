using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RoboticSpiders.Domain.Models;
using RoboticSpiders.Application.Services;
using RoboticSpiders.Infrastructure.Services;

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


            IWall wall = inputProvider.GetInput("Enter Wall Size (e.g., '7 15'):", parser.ParseWall);
            Position position = inputProvider.GetInput("Enter Spider Position (e.g., '4 10 Left'):", parser.ParsePosition);
            var commands = inputProvider.GetInput("Enter Instructions (e.g., 'FLFLFRFFLF'):", parser.ParseInstructions);

            IMovable spider = new Spider(position, wall);

            missionControl.ExecuteMissionAsync(spider, commands);

            logger.WriteInfo($"Final Position: {spider.Position}");
        }
        catch (Exception ex)
        {
            var logger = serviceProvider.GetRequiredService<ILogger>();
            logger.WriteError($"Critical Error: {ex.Message}");
        }
    }
}
