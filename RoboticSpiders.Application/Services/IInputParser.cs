using RoboticSpiders.Domain.Models;
using RoboticSpiders.Application.Commands;

namespace RoboticSpiders.Application.Services;

public interface IInputParser
{
    IWall ParseWall(string input);
    Position ParsePosition(string input);
    IEnumerable<ICommand> ParseInstructions(string input);
}
