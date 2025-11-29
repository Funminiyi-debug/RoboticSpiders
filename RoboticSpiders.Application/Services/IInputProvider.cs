namespace RoboticSpiders.Application.Services;

public interface IInputProvider
{
    T GetInput<T>(string prompt, Func<string, T> parser);
}
