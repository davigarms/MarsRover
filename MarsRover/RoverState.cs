using System.Drawing;

namespace MarsRover;

public abstract class RoverState
{
    public abstract void Update(RoverStateContext context);
    
    protected static bool IsObstacleFound(Point nextPosition) => 
        Map.Obstacles.Any(o => nextPosition.X == o.X && nextPosition.Y == o.Y);

    protected static void UpdateObstacleFound(RoverStateContext context) => context.SetObstacleFound(true);
    
    protected static Point GetNextPosition(RoverStateContext context)
    {
        var movePosition = Map.AddPositionFromDirection(context.Direction);
        return new Point(context.Position.X + movePosition.X, 
            context.Position.Y + movePosition.Y);
    }

    protected static void UpdatePosition(RoverStateContext context, Point nextPosition) =>
        context.SetPosition(new Point(
            Map.CheckMapLengthBoundaries(nextPosition.X), 
            Map.CheckMapLengthBoundaries(nextPosition.Y)));

    private static int UpdateDirectionIndex(int directionIndex, int directionChange) => 
        Map.CheckBoundaries(directionIndex + directionChange, Map.Directions.Length - 1);
    
    protected static void UpdateDirection(int directionChange, RoverStateContext context)
    {
        var directionIndex = Array.IndexOf(Map.Directions, context.Direction);
        var newDirectionIndex = UpdateDirectionIndex(directionIndex, directionChange);
        context.SetDirection(Map.Directions[newDirectionIndex]);
    }
}

internal class RotateToLeftState : RoverState
{
    public override void Update(RoverStateContext context) => UpdateDirection(-1, context);
}

internal class RotateToRightState : RoverState 
{
    public override void Update(RoverStateContext context) => UpdateDirection(1, context);
}

internal class MoveForwardState : RoverState
{
    public override void Update(RoverStateContext context)
    {
        var nextPosition = GetNextPosition(context);
        if (IsObstacleFound(nextPosition))
            UpdateObstacleFound(context);
        else
            UpdatePosition(context, nextPosition);
    }
}
