using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMover : Mover 
{
    public void Walk(float horizontalInput)
    {
        var xVelocity = horizontalInput * Speed;
        Rigidbody.velocity = new Vector2(xVelocity, Rigidbody.velocity.y);

        if (xVelocity * Direction < 0)
            FlipCharacterDirection();
    }
    
    private void FlipCharacterDirection()
    {
        Direction *= -1;
        bool isMovingRight = Direction > 0;
        
        gameObject.Flip(isMovingRight);
    }
}