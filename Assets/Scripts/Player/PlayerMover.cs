using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMover : DirectionSwitcher 
{
    public void Walk(float horizontalInput)
    {
        var xVelocity = horizontalInput * Speed;
        Rigidbody.velocity = new Vector2(xVelocity, Rigidbody.velocity.y);

        if (xVelocity * Direction < 0)
            SwitchDirection(Direction *= -1);
    }
}