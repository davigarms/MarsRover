namespace MarsRover;

public class MarsRover
{
    private int _directionIndex;
    
    private int _x;
    private int _y;

    private bool _obstacleFound;
    
    private string ObstacleText => _obstacleFound ? "O:" : "";

    private static IDictionary<char, int> RotationToIndex => new Dictionary<char, int>
    {
        {'R', 1 },
        {'L', -1 },
    };
    
    private char Direction => Map.Directions[DirectionIndex];

    private int DirectionIndex
    {
        get => _directionIndex;
        set => _directionIndex = CheckBoundaries(value, Map.Directions.Length - 1);
    }

    private int CheckMapLengthBoundaries(int value) => CheckBoundaries(value, Map.Length);

    private static int CheckBoundaries(int value, int length)
    {
        if (value < 0) return length;
        if (value > length) return 0;
        return value;
    }

    private int X { 
        get => _x;
        set => _x = CheckMapLengthBoundaries(value);
    }
    

    private int Y
    {
        get => _y;
        set => _y = CheckMapLengthBoundaries(value);
    }
    
    private void UpdateDirection(char rotation = 'R')
    {
        DirectionIndex += RotationToIndex.SingleOrDefault(r => r.Key == rotation).Value;
    }

    private void UpdatePosition()
    {
        var (addX, addY) = Map.AddPositionFromDirection(Direction);
        
        if (Map.Obstacles.Any(o => X + addX == o.X && Y + addY == o.Y))
        {
            _obstacleFound = true;
        }
        else
        {
            X += addX;
            Y += addY;
        }
    }

    public string Move(string moveCommands)
    {
        foreach (var moveCommand in moveCommands)
        {
            if (!_obstacleFound) 
                switch (moveCommand)
                {
                    case 'M':
                        UpdatePosition();
                        break;
                    case 'R':
                    case 'L':
                        UpdateDirection(moveCommand);
                        break;
                    default: 
                        throw new NotImplementedException();
                }
            else 
                break;
        }

        return $"{ObstacleText}{X}:{Y}:{Direction}";
    }
}