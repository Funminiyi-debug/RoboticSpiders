using Xunit;
using RoboticSpiders.Application.Services;
using RoboticSpiders.Infrastructure.Services;
using RoboticSpiders.Application.Commands;
using RoboticSpiders.Domain.Models;
using System.Linq;

namespace RoboticSpiders.Tests;

public class InputParserTests
{
    private readonly IInputParser _parser;

    public InputParserTests()
    {
        _parser = new InputParser();
    }

    [Fact]
    public void ParseWall_ValidInput_ReturnsWall()
    {
        var wall = _parser.ParseWall("7 15");
        Assert.Equal(7, wall.MaxX);
        Assert.Equal(15, wall.MaxY);
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
        var commands = _parser.ParseInstructions("FLR").ToList();
        Assert.Equal(3, commands.Count);
        Assert.IsType<MoveForwardCommand>(commands[0]);
        Assert.IsType<TurnLeftCommand>(commands[1]);
        Assert.IsType<TurnRightCommand>(commands[2]);
    }
}
