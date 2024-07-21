using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private float _speed; //Speed reduction when crouching
    [SerializeField] private float _maxFallSpeed;
    [SerializeField] private float _coyoteDuration = 1f;

    [Header("Jump Parameters")] 
    [SerializeField] private GroundCheck _groundCheck;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpHoldForce;
    [SerializeField] private float _jumpHoldDuration;
    [SerializeField] private float _jumpGravityScale;
    [SerializeField] private float _fallGravityScale;

    private PlayerInput _input;
    private Rigidbody2D _rigidbody;

    private bool _isJumping;
    private int _direction = 1;
    private float _jumpTime;
    private float _coyoteTime;

    public bool IsOnGround => _groundCheck.IsOnGround;
    public Vector2 Velocity => _rigidbody.velocity;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rigidbody.velocity.y >= 0)
            _rigidbody.gravityScale = _jumpGravityScale;

        if (_rigidbody.velocity.y < 0 && _coyoteTime < 0f)
            _rigidbody.gravityScale = _fallGravityScale;

        if (IsOnGround)
            _coyoteTime = _coyoteDuration;

        if (IsOnGround == false)
            _coyoteTime -= Time.deltaTime;

        Walk(_input.HorizontalInput);
        Jumping();
    }

    private void Walk(float horizontalInput)
    {
        var xVelocity = horizontalInput * _speed;
        _rigidbody.velocity = new Vector2(xVelocity, _rigidbody.velocity.y);

        if (xVelocity * _direction < 0)
            FlipCharacterDirection();
    }

    private void Jumping()
    {
        if (_input.JumpPressed && (IsOnGround || _coyoteTime > 0f) && _isJumping == false)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isJumping = true;
            _jumpTime = _jumpHoldDuration;
        }
        else if (_isJumping && _input.JumpHold)
        {
            if (_jumpTime > 0)
            {
                _rigidbody.AddForce(Vector2.up * _jumpHoldForce, ForceMode2D.Impulse);
                _jumpTime -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }
        else if (_isJumping)
        {
            _jumpTime -= Time.deltaTime;
        }

        if (_jumpTime < 0) _isJumping = false;

        if (_rigidbody.velocity.y < -_maxFallSpeed)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -_maxFallSpeed);
    }

    private void FlipCharacterDirection()
    {
        _direction *= -1;

        var scale = transform.localScale;
        scale.x = _direction;

        transform.localScale = scale;
    }
}