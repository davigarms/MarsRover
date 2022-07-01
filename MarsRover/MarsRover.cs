using System.Drawing;

namespace MarsRover;


public class MarsRover
{
    private int _directionIndex;
    
    private int _x;
    
    private int _y;

    private bool _obstacleFound = false;
    
    private string ObstacleFound => _obstacleFound ? "O:" : "";

    private  IDictionary<char, int> RotationToIndex => new Dictionary<char, int>
    {
        {'R', 1 },
        {'L', -1 },
    };
    
    private char Direction => Map.Directions[DirectionIndex];

    private int DirectionIndex
    {
        get => _directionIndex;
        set
        {
            _directionIndex = value < 0 ? Map.Directions.Length - 1 : value;
            _directionIndex = _directionIndex > Map.Directions.Length - 1 ? 0 : _directionIndex;
        }
    }

    private int X
    {
        get => _x;
        set
        {
            _x = value < 0 ? Map.Length : value;
            _x = _x > Map.Length ? 0 : _x;
        }
    }
    
    private int Y
    {
        get => _y;
        set
        {
            _y = value < 0 ? Map.Length : value;
            _y = _y > Map.Length ? 0 : _y;
        }
    }
    
    private void UpdateDirection(char rotation = 'R')
    {
        DirectionIndex += RotationToIndex.SingleOrDefault(r => r.Key == rotation).Value;
    }

    private void UpdatePosition()
    {
        var (_, newPosition) = Map.DirectionToPosition
            .SingleOrDefault(d => d.Key == Direction);
        
        if (Map.Obstacles.Any(o => X + newPosition[0] == o.X && Y + newPosition[1] == o.Y))
        {
            _obstacleFound = true;
        }
        else
        {
            X += newPosition[0];
            Y += newPosition[1];
        }
    }
    
    public string Move(string moveCommands)
    {
        foreach (var moveCommand in moveCommands)
        {
            switch (moveCommand)
            {
                case 'M':
                    if (!_obstacleFound) UpdatePosition();
                    break;
                case 'R':
                case 'L':
                    UpdateDirection(moveCommand);
                    break;
                default: 
                    throw new NotImplementedException();
            }
        }

        return $"{ObstacleFound}{X}:{Y}:{Direction}";
    }
}
