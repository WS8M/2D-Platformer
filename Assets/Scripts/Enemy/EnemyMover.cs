using UnityEngine;

public class EnemyMover : Mover
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
        {
            Direction = direction;
            gameObject.Flip(Direction > 0);
        }
        Rigidbody.velocity = new Vector2(Speed * Direction, Rigidbody.velocity.y); 
    }
}