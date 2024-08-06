using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Flipper))]
public class EnemyMover : MonoBehaviour
{
    private const float MaxDistanceToTarget = 0.1f;
    private const int RightDirection = 1;
    private const int LeftDirection = -1;
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Waypoints _waypoints;

    private int _currentWaypointIndex;

    private Rigidbody2D _rigidbody;
    private Flipper _flipper;
    private int _currentDirection = 1;

    public Vector2 Velocity => _rigidbody.velocity;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipper = GetComponent<Flipper>();
    }

    private void Update()
    {
        Walk();
    }

    private void Walk()
    {
        if (Math.Abs(_waypoints.GetPointPosition(_currentWaypointIndex).x - transform.position.x) < MaxDistanceToTarget)
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.PointCount;

        var direction = _waypoints
                .GetPointPosition(_currentWaypointIndex).x - transform.position.x > 0
                ? RightDirection
                : LeftDirection;

        if (direction != _currentDirection)
        {
            _currentDirection = direction;
            _flipper.Flip(_currentDirection > 0);
        }

        _rigidbody.velocity = new Vector2(_moveSpeed * _currentDirection, 0); 
    }
}