using UnityEngine;

public class WaypointsFollower : MonoBehaviour
{
    private const float MaxDistanceToTarget = 0.1f;
    
    [SerializeField] private Waypoints _waypoints;

    private int _currentWaypointIndex;

    public Vector3 GetTargetPosition()
    {
        if (Mathf.Abs(_waypoints.GetPointPosition(_currentWaypointIndex).x - transform.position.x) < MaxDistanceToTarget)
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.PointCount;
        
        return _waypoints.GetPointPosition(_currentWaypointIndex);
    }
}
