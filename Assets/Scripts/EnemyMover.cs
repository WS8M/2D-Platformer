using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Waypoints _waypoints;

    private int _currentWaypointIndex = 0;

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
        if (Math.Abs(_waypoints.GetPointPosition(_currentWaypointIndex).x - transform.position.x) < 0.1f) 
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.CountOfPoints;

        _direction = _waypoints.GetPointPosition(_currentWaypointIndex).x - transform.position.x > 0 ? 1 : -1;
        
        _rigidbody.velocity = new Vector2(_moveSpeed * _direction, 0); 
    }
    
    private void FlipCharacter()
    {
        Vector3 scale = transform.localScale;
        scale.x = _direction;
        
        transform.localScale = scale;
    }
}