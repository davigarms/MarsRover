namespace MarsRover;

public class MarsRover
{
    private readonly IOutput _output;
    private readonly RoverStateContext _context;

    public MarsRover(IOutput output)
    {
        _output = output;
        _context = new RoverStateContext(new MoveForwardState());
    }

    public void Move(string moveCommands)
    {
        foreach (var moveCommand in moveCommands)
        {
            if (_context.ObstacleFound) break;
            switch (moveCommand)
            {
                case 'M':
                    _context.SetState(new MoveForwardState());
                    break;
                case 'L':
                    _context.SetState(new RotateToLeftState());
                    break;
                case 'R':
                    _context.SetState(new RotateToRightState());
                    break;
                default: 
                    throw new NotImplementedException();
            }
            _context.Move();
        }
    }

    public string PrintLocation() => _output.Print(_context.ObstacleFound, _context.Position, _context.Direction.ToString());
}
