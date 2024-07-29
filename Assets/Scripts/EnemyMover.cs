using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private const float MaxDistanceToTarget = 0.1f;
    private const int PositiveDirection = 1;
    private const int NegativeDirection = -1;
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Waypoints _waypoints;

    private int _currentWaypointIndex;

    private Rigidbody2D _rigidbody;
    private int _direction = 1;

    public Vector2 Velocity => _rigidbody.velocity;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Walk();
        
        FlipCharacter();
    }

    private void Walk()
    {
        if (Math.Abs(_waypoints.GetPointPosition(_currentWaypointIndex).x - transform.position.x) < MaxDistanceToTarget) 
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.PointCount;

        _direction = _waypoints.GetPointPosition(_currentWaypointIndex).x - transform.position.x > 0 ? PositiveDirection : NegativeDirection;
        
        _rigidbody.velocity = new Vector2(_moveSpeed * _direction, 0); 
    }
    
    private void FlipCharacter()
    {
        Vector3 scale = transform.localScale;
        scale.x = _direction;
        
        transform.localScale = scale;
    }
}