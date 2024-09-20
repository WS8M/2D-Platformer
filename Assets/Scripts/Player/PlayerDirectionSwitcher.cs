using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerDirectionSwitcher : DirectionSwitcher 
{
    public void Walk(float horizontalInput)
    {
        var xVelocity = horizontalInput * Speed;
        Rigidbody.velocity = new Vector2(xVelocity, Rigidbody.velocity.y);

        if (xVelocity * Direction < 0)
            SwitchDirection(Direction *= -1);
    }
}