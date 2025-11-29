namespace RoboticSpiders.Application.Services;

public interface IInputProvider
{
    T GetInput<T>(string prompt, Func<string, T> parser);
    void WriteInfo(string message);
    void WriteError(string message);
    void WriteWarning(string message);
}
