using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private float _speed; //Speed reduction when crouching
    [SerializeField] private float _maxFallSpeed;
    [SerializeField] private float _coyoteDuration = 1f;
    
    [Header("Jump Parameters")] 
    [SerializeField] private GroundDetector _groundDetector;

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

    public bool IsOnGround => _groundDetector.IsOnGround;
    public Vector2 Velocity => _rigidbody.velocity;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.y >= 0)
            _rigidbody.gravityScale = _jumpGravityScale;

        if (_rigidbody.velocity.y < 0 && _coyoteTime < 0f)
            _rigidbody.gravityScale = _fallGravityScale;

        if (IsOnGround && _isJumping == false)
            _coyoteTime = _coyoteDuration;

        if (IsOnGround == false)
            _coyoteTime -= Time.fixedDeltaTime;

        if (_rigidbody.velocity.y < -_maxFallSpeed)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -_maxFallSpeed);
        
        if (_jumpTime <= 0)
            _isJumping = false;
        
        if (_isJumping)
            _jumpTime -= Time.fixedDeltaTime;
        
        Walk(_input.HorizontalInput);

        if (_input.JumpHold)
            JumpHandler();
        else
            _isJumping = false;
    }
    
    private void JumpHandler()
    {
        if (_isJumping)
            AddForceOnHoldJump();
        else if(IsOnGround || _coyoteTime > 0f)
            Jump();
    }

    private void AddForceOnHoldJump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpHoldForce, ForceMode2D.Impulse);
    }
    
    private void Jump()
    {
        Vector2 velocity = _rigidbody.velocity;
        _rigidbody.velocity = new Vector2(velocity.x, 0);
        
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        
        _coyoteTime = 0;
        _isJumping = true;
        _jumpTime = _jumpHoldDuration;
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

        var scale = transform.localScale;
        scale.x = _direction;

        transform.localScale = scale;
    }
}