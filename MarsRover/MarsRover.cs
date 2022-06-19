namespace MarsRover;

public class MarsRover
{
    private int _directionIndex;
    
    private int _x;
    
    private int _y;
    
    private const int GroundLength = 9;

    private IDictionary<char, int[]> DirectionToPosition => new Dictionary<char, int[]>
    {
        {'N', new [] {0, 1} },
        {'E', new [] {1, 0} },
        {'S', new [] {0,-1} },
        {'W', new [] {-1,0} },
    };
    
    private  IDictionary<char, int> RotationToIndex => new Dictionary<char, int>
    {
        {'R', 1 },
        {'L', -1 },
    };

    private char[] Directions =>  DirectionToPosition.Select(d => d.Key).ToArray();
    
    private char Direction => Directions[DirectionIndex];

    private int DirectionIndex
    {
        get => _directionIndex;
        set
        {
            _directionIndex = value < 0 ? Directions.Length - 1 : value;
            _directionIndex = _directionIndex > Directions.Length - 1 ? 0 : _directionIndex;
        }
    }

    private int X
    {
        get => _x;
        set
        {
            _x = value < 0 ? GroundLength : value;
            _x = _x > GroundLength ? 0 : _x;
        }
    }
    
    private int Y
    {
        get => _y;
        set
        {
            _y = value < 0 ? GroundLength : value;
            _y = _y > GroundLength ? 0 : _y;
        }
    }
    
    private void UpdateDirection(char rotation = 'R')
    {
        DirectionIndex += RotationToIndex.SingleOrDefault(r => r.Key == rotation).Value;
    }

    private void UpdatePosition()
    {
        var (_, newPosition) = DirectionToPosition
            .SingleOrDefault(d => d.Key == Direction);

        X += newPosition[0];
        Y += newPosition[1];
    }
    
    public string MoveRover(string moveCommands)
    {
        foreach (var moveCommand in moveCommands)
        {
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
        }

        return $"{X}:{Y}:{Direction}";
    }
}
