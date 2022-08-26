using System.Drawing;

namespace MarsRover;


public interface IOutput 
{
    string Print(bool obstacleFound, Point position, string direction);
}

public class Output : IOutput
{
    public string Print(bool obstacleFound, Point position, string direction)
    {
        var obstacleText = obstacleFound ? "O:" : "";
        var positionText = $"{position.X}:{position.Y}";
        return $"{obstacleText}{positionText}:{direction}";
    } 
}