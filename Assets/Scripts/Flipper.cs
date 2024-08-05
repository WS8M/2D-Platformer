using UnityEngine;

public class Flipper : MonoBehaviour
{
    private const int RightDirection = 1;
    private const int LeftDirection = -1;
    
    public void Flip(bool isMovingRight)
    {
        int direction = isMovingRight ? RightDirection : LeftDirection;
        
        var scale = transform.localScale;
        scale.x = direction;

        transform.localScale = scale;
    }
}
