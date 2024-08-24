using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _maxFallSpeed = 10f;
    [SerializeField] private float _coyoteDuration = 1f;
    
    [SerializeField] private GroundDetector _groundDetector;

    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _jumpHoldForce = 0.2f;
    [SerializeField] private float _jumpHoldDuration = 0.21f;
    [SerializeField] private float _jumpGravityScale = 1f;
    [SerializeField] private float _fallGravityScale = 3f;

    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    
    private float _jumpTime;
    private float _coyoteTime;
    private bool _isJumping;
    
    public bool IsOnGround => _groundDetector.IsOnGround;

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
        
        if (_input.JumpHold)
            JumpHandler();
        else
            _isJumping = false;
    }
    
    public void JumpAfterAttack()
    {
        ResetYSpeed();
        AddForceOnHoldJump(_jumpForce);
    }

    private void JumpHandler()
    {
        if (_isJumping)
            AddForceOnHoldJump(_jumpHoldForce);
        else if(IsOnGround || _coyoteTime > 0f)
            Jump();
    }

    private void Jump()
    {
        ResetYSpeed();
        AddForceOnHoldJump(_jumpForce);
        
        _coyoteTime = 0;
        _isJumping = true;
        _jumpTime = _jumpHoldDuration;
    }
    
    private void AddForceOnHoldJump(float force)
    {
        _rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    private void ResetYSpeed()
    {
        Vector2 velocity = _rigidbody.velocity;
        _rigidbody.velocity = new Vector2(velocity.x, 0);
    }  
}
