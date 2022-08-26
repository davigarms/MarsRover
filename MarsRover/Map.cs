using System.Drawing;

namespace MarsRover;

public static class Map
{
    public static char[] Directions => DirectionAddPosition.Select(d => d.Key).ToArray();

    private static IDictionary<char, Point> DirectionAddPosition => new Dictionary<char, Point>
    {
        {'N', new Point( 0, 1) },
        {'E', new Point( 1, 0) },
        {'S', new Point( 0,-1) },
        {'W', new Point(-1, 0) },
    };

    private const int Length = 9;

    public static readonly Point[] Obstacles = {
        new Point(0,3),
    };
    
    public static int CheckMapLengthBoundaries(int value) => CheckBoundaries(value, Length);

    public static int CheckBoundaries(int value, int length)
    {
        if (value < 0) return length;
        return value > length ? 0 : value;
    }

    public static Point AddPositionFromDirection(char direction) =>
        DirectionAddPosition
            .SingleOrDefault(d => d.Key == direction).Value;
}