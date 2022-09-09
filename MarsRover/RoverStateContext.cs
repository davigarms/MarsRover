using System.Drawing;

namespace MarsRover;

public class RoverStateContext
{
    private RoverState _currentState;

    public Point Position;

    public bool ObstacleFound { get; private set; }

    public char Direction { get; private set; } = 'N';
    
    public RoverStateContext(RoverState state) => _currentState = state;

    public void Move() => _currentState.Update(this);

    public void SetState(RoverState state) => _currentState = state;

    public void SetObstacleFound(bool obstacleFound) => ObstacleFound = obstacleFound;
    
    public void SetDirection(char direction) => Direction = direction;
    
    public void SetPosition(Point position) => Position = position;
}

