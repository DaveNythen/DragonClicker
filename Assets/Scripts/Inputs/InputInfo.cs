using UnityEngine;

public class InputInfo
{
    public Vector2 startPos { get; private set; }
    public Vector2 endPos { get; private set; }

    public float gestureAngle { get; private set; }
    public Vector2 middlePoint { get; private set; }

    public InputInfo(Vector2 startPos, Vector2 endPos)
    {
        this.startPos = startPos;
        this.endPos = endPos;
        gestureAngle = CalculateGestureAngle(startPos, endPos);
        middlePoint = CalculateMiddlePoint(startPos, endPos);
    }

    private float CalculateGestureAngle(Vector2 start, Vector2 end)
    {
        Vector2 diference = end - start;
        float sign = (start.y < end.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }

    private Vector2 CalculateMiddlePoint(Vector2 start, Vector2 end)
    {
        float midX = end.x + (start.x - end.x) / 2;
        float midY = end.y + (start.y - end.y) / 2;
        return new Vector2(midX, midY);
    }
}
