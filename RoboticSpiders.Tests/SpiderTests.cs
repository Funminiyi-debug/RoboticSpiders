using Xunit;
using RoboticSpiders.Domain.Models;
using RoboticSpiders.Application.Services;
using RoboticSpiders.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoboticSpiders.Tests;

public class SpiderTests
{
    [Fact]
    public async Task ExecuteMission_ExampleCase_ReturnsCorrectPosition()
    {
        // Arrange
        IWall wall = new Wall(7, 15);
        IPosition startPos = new Position(4, 10, Orientation.Left);
        IMovable spider = new Spider(startPos, wall);
        var missionControl = new MissionControl();
        IInputParser parser = new InputParser();
        var commands = parser.ParseInstructions("FLFLFRFFLF");

        // Act
        await missionControl.ExecuteMissionAsync(spider, commands);

        // Assert
        Assert.Equal(5, spider.Position.X);
        Assert.Equal(7, spider.Position.Y);
        Assert.Equal(Orientation.Right, spider.Position.Orientation);
    }

    [Fact]
    public void MoveForward_BoundaryCheck_DoesNotMoveOffWall()
    {
        IWall wall = new Wall(5, 5);
        IPosition startPos = new Position(0, 0, Orientation.Down); // Facing edge
        IMovable spider = new Spider(startPos, wall);

        spider.MoveForward();

        Assert.Equal(0, spider.Position.X);
        Assert.Equal(0, spider.Position.Y); // Should not move
    }
}
