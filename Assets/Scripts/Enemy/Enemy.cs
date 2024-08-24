using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private WaypointsFollower _waypointsFollower;
    [SerializeField] private PlayerStalk _playerStalk;

    private void FixedUpdate()
    {
        if (_playerStalk.TryGetPlayerPosition(out Vector3 position))
            _mover.Walk(position);
        else
            _mover.Walk(_waypointsFollower.GetTargetPosition());
    }
}