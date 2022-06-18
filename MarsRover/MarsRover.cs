using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MarsRover;

public class MarsRover
{
    private int _directionIndex;
    
    private Point _position = new Point(0,0);
    
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
    
    private char Direction => DirectionToPosition.Select(d => d.Key).ToArray()[_directionIndex];
  
    private void UpdateDirection(char rotation = 'R')
    {
        _directionIndex += RotationToIndex.SingleOrDefault(r => r.Key == rotation).Value;
        if (_directionIndex > Directions.Length - 1) _directionIndex = 0;
        if (_directionIndex < 0) _directionIndex = Directions.Length - 1;
    }

    private void UpdatePosition()
    {
        var (_, newPosition) = DirectionToPosition
            .SingleOrDefault(d => d.Key == Direction);

        _position.X += newPosition[0];
        _position.Y += newPosition[1];
        
        AdjustPosition();
    }

    private void AdjustPosition()
    {
        if (_position.X < 0) _position.X = GroundLength;
        if (_position.X > GroundLength) _position.X = 0;
        if (_position.Y < 0) _position.Y = GroundLength;
        if (_position.Y > GroundLength) _position.Y = 0;
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
                    UpdateDirection(moveCommand);
                    break;
                case 'L':
                    UpdateDirection(moveCommand);
                    break;
                default: 
                    throw new NotImplementedException();
            }
        }

        return $"{_position.X}:{_position.Y}:{Direction}";
    }
}