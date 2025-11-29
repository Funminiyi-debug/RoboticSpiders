using System.Collections.Generic;

using RoboticSpiders.Domain.Models;
using RoboticSpiders.Application.Commands;

namespace RoboticSpiders.Application.Services;

public interface IInputParser
{
    IWall ParseWall(string input);
    IPosition ParsePosition(string input);
    List<ICommand> ParseInstructions(string input);
}
