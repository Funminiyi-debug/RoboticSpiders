namespace RoboticSpiders.Domain.Models;

public interface IPosition
{
    int X { get; set; }
    int Y { get; set; }
    Orientation Orientation { get; set; }
}
