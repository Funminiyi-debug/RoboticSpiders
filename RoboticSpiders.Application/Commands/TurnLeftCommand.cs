using RoboticSpiders.Domain.Models;

namespace RoboticSpiders.Application.Commands;

public class TurnLeftCommand : ICommand
{
    public void Execute(IMovable actor)
    {
        actor.TurnLeft();
    }
}
