using RoboticSpiders.Domain.Models;
using RoboticSpiders.Application.Services;
using RoboticSpiders.Domain.Exceptions;
using RoboticSpiders.Infrastructure.Services;

namespace RoboticSpiders.Tests;

public class SpiderTests
{
    [Fact]
    public void ExecuteMission_ExampleCase_ReturnsCorrectPosition()
    {
        // Arrange
        IWall wall = new Wall(7, 15);
        Position startPos = new Position(4, 10, Orientation.Left);
        IMovable spider = new Spider(startPos, wall);
        var missionControl = new MissionControl();
        ICommandFactory commandFactory = new CommandFactory();
        IInstructionParser parser = new InstructionParser(commandFactory);
        var commands = parser.Parse("FLFLFRFFLF");

        // Act
        missionControl.ExecuteMission(spider, commands);

        // Assert
        Assert.Equal(5, spider.Position.X);
        Assert.Equal(7, spider.Position.Y);
        Assert.Equal(Orientation.Right, spider.Position.Orientation);
    }

    [Fact]
    public void MoveForward_BoundaryCheck_DoesNotMoveOffWall()
    {
        IWall wall = new Wall(5, 5);
        Position startPos = new Position(0, 0, Orientation.Down); // Facing edge
        IMovable spider = new Spider(startPos, wall);

        Assert.Throws<WallCollisionException>(() => spider.MoveForward());
    }
}