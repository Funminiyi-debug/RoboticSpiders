using RoboticSpiders.Domain.Exceptions;
using RoboticSpiders.Infrastructure.Services;

namespace RoboticSpiders.Tests;

public class CommandFactoryTests
{
    [Fact]
    public void GetCommand_UnknownCharacter_ThrowsInvalidCommandException()
    {
        var factory = new CommandFactory();
        Assert.Throws<InvalidCommandException>(() => factory.GetCommand('X'));
        Assert.Throws<InvalidCommandException>(() => factory.GetCommand('1'));
        Assert.Throws<InvalidCommandException>(() => factory.GetCommand('?'));
    }
}
