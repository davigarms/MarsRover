using System.Drawing;

namespace MarsRover;

public class MarsRover
{
    private int _directionIndex = 0;
    private string[] _direction = new string[] { "N", "E", "S", "W" };
    private Point _position = new Point(0,0);
    
    public string MoveRover(string moveCommands)
    {
        foreach (var moveCommand in moveCommands)
        {
            switch (moveCommand)
            {
                case 'M':
                    if (_direction[_directionIndex] == "N") _position.Y += 1;
                    if (_direction[_directionIndex] == "E") _position.X += 1;
                    if (_direction[_directionIndex] == "S") _position.Y -= 1;
                    if (_direction[_directionIndex] == "W") _position.X -= 1;
                    break;
                case 'R':
                    _directionIndex++;
                    break;
                default:
                    throw new NotImplementedException();
            }

            _directionIndex = _directionIndex < _direction.Length ? _directionIndex : 0;
            _position.X = _position.X >= 0 ? _position.X : 0;
            _position.Y = _position.Y >= 0 ? _position.Y : 0;
        }

        return $"{_position.X}:{_position.Y}:{_direction[_directionIndex]}";
    }
}
