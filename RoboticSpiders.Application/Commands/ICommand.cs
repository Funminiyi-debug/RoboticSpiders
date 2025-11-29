using RoboticSpiders.Domain.Models;

namespace RoboticSpiders.Application.Commands;

public interface ICommand
{
    void Execute(IMovable actor);
}
