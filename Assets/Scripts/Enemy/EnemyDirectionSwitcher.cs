using UnityEngine;

public class EnemyDirectionSwitcher : DirectionSwitcher
{
    private const float MinDistanceForMove = 0.1f;
    private const int RightDirection = 1;
    private const int LeftDirection = -1;
    
    public void Walk(Vector3 targetPosition)
    {
        var distance = targetPosition.x - transform.position.x;
        
        if (Mathf.Abs(distance) < MinDistanceForMove)
            return;
        
        var direction = distance > 0
            ? RightDirection
            : LeftDirection;
        
        if (direction != Direction) 
            SwitchDirection(Direction = direction);
        
        Rigidbody.velocity = new Vector2(Speed * Direction, Rigidbody.velocity.y); 
    }
}