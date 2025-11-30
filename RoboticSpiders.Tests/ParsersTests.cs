using Moq;
using RoboticSpiders.Application.Commands;
using RoboticSpiders.Application.Services;
using RoboticSpiders.Domain.Exceptions;
using RoboticSpiders.Domain.Models;
using RoboticSpiders.Infrastructure.Services;

namespace RoboticSpiders.Tests;

public class ParsersTests
{
    private readonly Mock<ICommandFactory> _mockCommandFactory = new();

    [Fact]
    public void WallParser_Parse_ValidInput_ReturnsWall()
    {
        var parser = new WallParser();
        var wall = parser.Parse("7 15");
        Assert.Equal(7, wall.MaxX);
        Assert.Equal(15, wall.MaxY);
    }

    [Theory]
    [InlineData("a 5")]
    [InlineData("5 b")]
    [InlineData("a b")]
    public void WallParser_Parse_NonIntegerArgs_ThrowsArgumentException(string input)
    {
        var parser = new WallParser();
        Assert.Throws<ArgumentException>(() => parser.Parse(input));
    }

    [Theory]
    [InlineData("-5 5")]
    [InlineData("5 -5")]
    [InlineData("-1 -1")]
    public void WallParser_Parse_NegativeNumbers_ThrowsException(string input)
    {
        var parser = new WallParser();
        // Wall parser parses string to int, then Wall constructor throws ArgumentOutOfRangeException
        Assert.Throws<ArgumentOutOfRangeException>(() => parser.Parse(input));
    }

    [Theory]
    [InlineData("5")]
    [InlineData("5 5 5")]
    [InlineData("")]
    public void WallParser_Parse_InvalidArgCount_ThrowsArgumentException(string input)
    {
        var parser = new WallParser();
        Assert.Throws<ArgumentException>(() => parser.Parse(input));
    }

    [Fact]
    public void InstructionParser_Parse_InvalidInput_ThrowsException()
    {
        _mockCommandFactory.Setup(x => x.GetCommand('X')).Throws(new InvalidCommandException("Unknown command: X"));
        var parser = new InstructionParser(_mockCommandFactory.Object);
        Assert.Throws<InvalidCommandException>(() => parser.Parse("X").ToList());
    }

    [Fact]
    public void PositionParser_Parse_ValidInput_ReturnsPosition()
    {
        var parser = new PositionParser();
        var pos = parser.Parse("4 10 Left");
        Assert.Equal(4, pos.X);
        Assert.Equal(10, pos.Y);
        Assert.Equal(Orientation.Left, pos.Orientation);
    }

    [Fact]
    public void InstructionParser_Parse_ValidInput_ReturnsCommands()
    {
        _mockCommandFactory.Setup(x => x.GetCommand('F')).Returns(new MoveForwardCommand());
        _mockCommandFactory.Setup(x => x.GetCommand('L')).Returns(new TurnLeftCommand());
        _mockCommandFactory.Setup(x => x.GetCommand('R')).Returns(new TurnRightCommand());

        var parser = new InstructionParser(_mockCommandFactory.Object);
        var commands = parser.Parse("FLR").ToList();
        Assert.Equal(3, commands.Count);
        Assert.IsType<MoveForwardCommand>(commands[0]);
        Assert.IsType<TurnLeftCommand>(commands[1]);
        Assert.IsType<TurnRightCommand>(commands[2]);
    }
}
