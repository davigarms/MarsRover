using System.Drawing;

namespace MarsRover;

public static class Map
{
    public static char[] Directions => DirectionAddPosition.Select(d => d.Key).ToArray();

    private static IDictionary<char, KeyValuePair<int,int>> DirectionAddPosition => new Dictionary<char, KeyValuePair<int,int>>
    {
        {'N', new KeyValuePair<int,int>( 0, 1) },
        {'E', new KeyValuePair<int,int>( 1, 0) },
        {'S', new KeyValuePair<int,int>( 0,-1) },
        {'W', new KeyValuePair<int,int>(-1, 0) },
    };

    public const int Length = 9;

    public static readonly Point[] Obstacles = new[]
    {
        new Point(0,3),
        new Point(2,2),
    };

    public static KeyValuePair<int,int> AddPositionFromDirection(char direction)
    {
        return DirectionAddPosition
            .SingleOrDefault(d => d.Key == direction).Value;
    }
}