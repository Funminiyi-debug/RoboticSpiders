namespace RoboticSpiders.Application.Services;

public interface ILogger
{
    void WriteInfo(string message);
    void WriteError(string message);
    void WriteWarning(string message);
}
