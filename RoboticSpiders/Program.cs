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
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ILogger, ConsoleLogger>()
            .AddSingleton<ICommandFactory, CommandFactory>()
            .AddSingleton<IInputProvider, ConsoleInputProvider>()
            .AddSingleton<IWallParser, WallParser>()
            .AddSingleton<IPositionParser, PositionParser>()
            .AddSingleton<IInstructionParser, InstructionParser>()
            .AddSingleton<MissionControl>()
            .BuildServiceProvider();

        var logger = serviceProvider.GetRequiredService<ILogger>();

        try
        {
            var inputProvider = serviceProvider.GetRequiredService<IInputProvider>();
            var wallParser = serviceProvider.GetRequiredService<IWallParser>();
            var positionParser = serviceProvider.GetRequiredService<IPositionParser>();
            var instructionParser = serviceProvider.GetRequiredService<IInstructionParser>();
            var missionControl = serviceProvider.GetRequiredService<MissionControl>();

            const string wallInputMessage = "Enter Wall Size (e.g., '7 15'):";
            const string positionInputMessage = "Enter Spider Position (e.g., '4 10 Left'):";
            const string instructionsInputMessage = "Enter Instructions (e.g., 'FLFLFRFFLF'):";


            var wall = inputProvider.GetInput(wallInputMessage, wallParser.Parse);
            var position = inputProvider.GetInput(positionInputMessage, positionParser.Parse);
            var commands = inputProvider.GetInput(instructionsInputMessage, instructionParser.Parse);

            IMovable spider = new Spider(position, wall);

            missionControl.ExecuteMission(spider, commands);

            logger.WriteInfo($"Final Position: {spider.Position}");
        }
        catch (InvalidCommandException ex)
        {
            logger.WriteError($"Command Error: {ex.Message}");
        }
        catch (WallCollisionException ex)
        {
            logger.WriteError($"Collision Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            logger.WriteError($"Critical Error: {ex.Message}");
        }
    }
}
