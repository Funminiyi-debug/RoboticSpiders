using Moq;
using RoboticSpiders.Application.Commands;
using RoboticSpiders.Application.Services;
using RoboticSpiders.Domain.Exceptions;
using RoboticSpiders.Domain.Models;
using RoboticSpiders.Infrastructure.Services;

namespace RoboticSpiders.Tests;

public class InputParserTests
{
    private readonly IInputParser _parser;
    private readonly Mock<ICommandFactory> _mockCommandFactory;

    public InputParserTests()
    {
        _mockCommandFactory = new Mock<ICommandFactory>();
        _parser = new InputParser(_mockCommandFactory.Object);
    }

    [Fact]
    public void ParseWall_ValidInput_ReturnsWall()
    {
        var wall = _parser.ParseWall("7 15");
        Assert.Equal(7, wall.MaxX);
        Assert.Equal(15, wall.MaxY);
    }

    [Fact]
    public void ParseInstructions_InvalidInput_ThrowsException()
    {
        _mockCommandFactory.Setup(x => x.GetCommand('X')).Throws(new InvalidCommandException("Unknown command: X"));
        Assert.Throws<InvalidCommandException>(() => _parser.ParseInstructions("X").ToList());
    }

    [Fact]
    public void ParsePosition_ValidInput_ReturnsPosition()
    {
        var pos = _parser.ParsePosition("4 10 Left");
        Assert.Equal(4, pos.X);
        Assert.Equal(10, pos.Y);
        Assert.Equal(Orientation.Left, pos.Orientation);
    }

    [Fact]
    public void ParseInstructions_ValidInput_ReturnsCommands()
    {
        _mockCommandFactory.Setup(x => x.GetCommand('F')).Returns(new MoveForwardCommand());
        _mockCommandFactory.Setup(x => x.GetCommand('L')).Returns(new TurnLeftCommand());
        _mockCommandFactory.Setup(x => x.GetCommand('R')).Returns(new TurnRightCommand());

        var commands = _parser.ParseInstructions("FLR").ToList();
        Assert.Equal(3, commands.Count);
        Assert.IsType<MoveForwardCommand>(commands[0]);
        Assert.IsType<TurnLeftCommand>(commands[1]);
        Assert.IsType<TurnRightCommand>(commands[2]);
    }
}
