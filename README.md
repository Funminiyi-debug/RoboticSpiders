# Robotic Spiders

A C# console application simulating a robotic spider navigating a wall grid.

## How to Run

1.  Ensure .NET 9.0 is installed.
2.  Run the application:
    ```bash
    dotnet run --project RoboticSpiders
    ```

## Usage

Follow the prompts to enter:
1.  **Wall Size**: `7 15` (Width Height)
2.  **Start Position**: `2 4 Left` (X Y Orientation)
3.  **Instructions**: `FLFLFRFFLF` (Forward, Left, Right)

## Architecture
Built using Clean Architecture principles (Domain, Application, Infrastructure) and Dependency Injection.
