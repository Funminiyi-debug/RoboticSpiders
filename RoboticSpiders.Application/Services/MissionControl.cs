using RoboticSpiders.Domain.Models;
using RoboticSpiders.Application.Commands;

namespace RoboticSpiders.Application.Services;

public class MissionControl
{
    public void ExecuteMissionAsync(IMovable actor, IEnumerable<ICommand> commands)
    {
        foreach (var command in commands)
        {
            command.Execute(actor);
        }
    }
}