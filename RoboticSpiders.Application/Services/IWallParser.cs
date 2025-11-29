using RoboticSpiders.Domain.Models;

namespace RoboticSpiders.Application.Services;

public interface IWallParser
{
    IWall Parse(string input);
}
