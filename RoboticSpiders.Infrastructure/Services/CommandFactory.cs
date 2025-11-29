using RoboticSpiders.Application.Commands;
using RoboticSpiders.Application.Services;
using RoboticSpiders.Domain.Exceptions;

namespace RoboticSpiders.Infrastructure.Services;

public class CommandFactory : ICommandFactory
{
    private readonly Dictionary<char, Func<ICommand>> _commandMap = new()
    {
        { 'L', () => new TurnLeftCommand() },
        { 'R', () => new TurnRightCommand() },
        { 'F', () => new MoveForwardCommand() }
    };

    public ICommand GetCommand(char commandChar)
    {
        var key = char.ToUpperInvariant(commandChar);
        if (_commandMap.TryGetValue(key, out var factory))
        {
            return factory();
        }

        throw new InvalidCommandException($"Unknown command: {commandChar}");
    }
}
