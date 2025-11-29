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

            // Read Wall Size
            string wallInput = inputProvider.ReadValidLine();

            // Read Spider Position
            string positionInput = inputProvider.ReadValidLine();

            // Read Instructions
            string instructionsInput = inputProvider.ReadValidLine();

            IInputParser parser = new InputParser();
            var missionControl = new MissionControl();

            // Parse Inputs
            IWall wall = parser.ParseWall(wallInput);
            IPosition position = parser.ParsePosition(positionInput);
            var commands = parser.ParseInstructions(instructionsInput);

            // Create Spider
            IMovable spider = new Spider(position, wall);

            // Execute Mission
            await missionControl.ExecuteMissionAsync(spider, commands);

            // Output Result
            Console.WriteLine(spider.Position);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
