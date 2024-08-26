using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private UnitHealth _health;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private WaypointsFollower _waypointsFollower;
    [SerializeField] private PlayerStalk _playerStalk;
    [SerializeField] private DieBehavior _dieBehavior;
    
    private void FixedUpdate()
    {
        if (_playerStalk.TryGetPlayerPosition(out Vector3 position))
            _mover.Walk(position);
        else
            _mover.Walk(_waypointsFollower.GetTargetPosition());
    }

    private void OnEnable()
    {
        _dieBehavior.Ended += OnDied;
    }

    private void OnDisable()
    {
        _dieBehavior.Ended -= OnDied;
    }
    
    private void OnDied()
    {
        _dieBehavior.Ended -= OnDied;
        
        Destroy(gameObject);
    }
}