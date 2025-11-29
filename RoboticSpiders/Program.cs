using RoboticSpiders.Domain.Models;
using RoboticSpiders.Application.Services;
using RoboticSpiders.Infrastructure.Services;

namespace RoboticSpiders;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            IInputProvider inputProvider = new ConsoleInputProvider();

            string wallInput = inputProvider.ReadValidLine();

            string positionInput = inputProvider.ReadValidLine();

            string instructionsInput = inputProvider.ReadValidLine();

            IInputParser parser = new InputParser();
            var missionControl = new MissionControl();

            IWall wall = parser.ParseWall(wallInput);
            Position position = parser.ParsePosition(positionInput);
            var commands = parser.ParseInstructions(instructionsInput);

            IMovable spider = new Spider(position, wall);

            await missionControl.ExecuteMissionAsync(spider, commands);

            Console.WriteLine(spider.Position);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
