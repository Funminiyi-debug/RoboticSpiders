using RoboticSpiders.Application.Commands;

namespace RoboticSpiders.Application.Services;

public interface IInstructionParser
{
    IEnumerable<ICommand> Parse(string input);
}
