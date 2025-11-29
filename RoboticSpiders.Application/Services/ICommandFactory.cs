using RoboticSpiders.Application.Commands;

namespace RoboticSpiders.Application.Services;

public interface ICommandFactory
{
    ICommand GetCommand(char commandChar);
}
