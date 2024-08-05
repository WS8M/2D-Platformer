using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput), typeof(Flipper))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerInput _input;
    private Flipper _flipper;
    private Rigidbody2D _rigidbody;

    private int _direction = 1;

    public Vector2 Velocity => _rigidbody.velocity;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _flipper = GetComponent<Flipper>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Walk(_input.HorizontalInput);
    }
    
    private void Walk(float horizontalInput)
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
        
        _flipper.Flip(isMovingRight);
    }
}