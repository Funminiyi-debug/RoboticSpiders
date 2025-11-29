using System.Collections.Generic;
using System.Threading.Tasks;
using RoboticSpiders.Domain.Models;
using RoboticSpiders.Application.Commands;

namespace RoboticSpiders.Application.Services;

public class MissionControl
{
    public async Task ExecuteMissionAsync(IMovable actor, IEnumerable<ICommand> commands)
    {
        await Task.Run(() =>
        {
            foreach (var command in commands)
            {
                command.Execute(actor);
            }
        });
    }
}
