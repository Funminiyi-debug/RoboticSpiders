using RoboticSpiders.Domain.Models;

namespace RoboticSpiders.Application.Services;

public interface IPositionParser
{
    Position Parse(string input);
}
