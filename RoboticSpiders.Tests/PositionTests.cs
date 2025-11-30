using RoboticSpiders.Domain.Models;

namespace RoboticSpiders.Tests;

public class PositionTests
{
    [Fact]
    public void MoveForward_FacingUp_IncrementsY()
    {
        var pos = new Position(0, 0, Orientation.Up);
        var newPos = pos.MoveForward();
        Assert.Equal(0, newPos.X);
        Assert.Equal(1, newPos.Y);
        Assert.Equal(Orientation.Up, newPos.Orientation);
    }

    [Fact]
    public void MoveForward_FacingRight_IncrementsX()
    {
        var pos = new Position(0, 0, Orientation.Right);
        var newPos = pos.MoveForward();
        Assert.Equal(1, newPos.X);
        Assert.Equal(0, newPos.Y);
        Assert.Equal(Orientation.Right, newPos.Orientation);
    }

    [Fact]
    public void MoveForward_FacingDown_DecrementsY()
    {
        var pos = new Position(0, 1, Orientation.Down);
        var newPos = pos.MoveForward();
        Assert.Equal(0, newPos.X);
        Assert.Equal(0, newPos.Y);
        Assert.Equal(Orientation.Down, newPos.Orientation);
    }

    [Fact]
    public void MoveForward_FacingLeft_DecrementsX()
    {
        var pos = new Position(1, 0, Orientation.Left);
        var newPos = pos.MoveForward();
        Assert.Equal(0, newPos.X);
        Assert.Equal(0, newPos.Y);
        Assert.Equal(Orientation.Left, newPos.Orientation);
    }
}
