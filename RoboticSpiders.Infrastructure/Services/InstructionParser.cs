using RoboticSpiders.Application.Commands;
using RoboticSpiders.Application.Services;

namespace RoboticSpiders.Infrastructure.Services;

public class InstructionParser(ICommandFactory commandFactory) : IInstructionParser
{
    public IEnumerable<ICommand> Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) yield break;

        foreach (var c in input)
        {
            yield return commandFactory.GetCommand(c);
        }
    }
}
