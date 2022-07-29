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
