using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;

    private int _direction = 1;

    public Vector2 Velocity => _rigidbody.velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void Walk(float horizontalInput)
    {
        var xVelocity = horizontalInput * _speed;
        _rigidbody.velocity = new Vector2(xVelocity, _rigidbody.velocity.y);

        if (xVelocity * _direction < 0)
            FlipCharacterDirection();
    }
    
    private void FlipCharacterDirection()
    {
        _direction *= -1;
        bool isMovingRight = _direction > 0;
        
        gameObject.Flip(isMovingRight);
    }
}