using System.Drawing;

namespace MarsRover;

public static class Map
{
    public static char[] Directions => DirectionToPosition.Select(d => d.Key).ToArray();
    
    public static IDictionary<char, int[]> DirectionToPosition => new Dictionary<char, int[]>
    {
        {'N', new [] {0, 1} },
        {'E', new [] {1, 0} },
        {'S', new [] {0,-1} },
        {'W', new [] {-1,0} },
    };

    public const int Length = 9;

    public static readonly Point[] Obstacles = new[]
    {
        new Point(0,3),
        new Point(2,2),
    };
}