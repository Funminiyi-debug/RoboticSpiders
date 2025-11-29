using RoboticSpiders.Domain.Models;

namespace RoboticSpiders.Application.Commands;

public class MoveForwardCommand : ICommand
{
    public void Execute(IMovable actor)
    {
        actor.MoveForward();
    }
}
