using UnityEngine;

public static class Flipper
{
    private const int RightDirection = 1;
    private const int LeftDirection = -1;

    public static void Flip(this GameObject gameObject, bool isMovingRight)
    {
        int direction = isMovingRight ? RightDirection : LeftDirection;
        
        var scale = gameObject.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;

        gameObject.transform.localScale = scale;
    }
}
