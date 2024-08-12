using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    private const float MinDistanceForMove = 0.1f;
    private const int RightDirection = 1;
    private const int LeftDirection = -1;
    
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody;
    private int _currentDirection = 1;

    public Vector2 Velocity => _rigidbody.velocity;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void Walk(Vector3 targetPosition)
    {
        var distance = targetPosition.x - transform.position.x;
        
        if (Mathf.Abs(distance) < MinDistanceForMove)
            return;
        
        var direction = distance > 0
            ? RightDirection
            : LeftDirection;
        
        if (direction != _currentDirection)
        {
            _currentDirection = direction;
            gameObject.Flip(_currentDirection > 0);
        }
        _rigidbody.velocity = new Vector2(_moveSpeed * _currentDirection, _rigidbody.velocity.y); 
    }
}