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
            .AddSingleton<IInputProvider, ConsoleInputProvider>()
            .AddSingleton<IInputParser, InputParser>()
            .AddSingleton<MissionControl>()
            .BuildServiceProvider();

        try
        {
            // Resolve Services
            var inputProvider = serviceProvider.GetRequiredService<IInputProvider>();
            var parser = serviceProvider.GetRequiredService<IInputParser>();
            var missionControl = serviceProvider.GetRequiredService<MissionControl>();

            
            string wallInput = inputProvider.ReadValidLine();

            string positionInput = inputProvider.ReadValidLine();

            string instructionsInput = inputProvider.ReadValidLine();

            IWall wall = parser.ParseWall(wallInput);
            Position position = parser.ParsePosition(positionInput);
            var commands = parser.ParseInstructions(instructionsInput);

            IMovable spider = new Spider(position, wall);

            missionControl.ExecuteMissionAsync(spider, commands);

            Console.WriteLine(spider.Position);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
