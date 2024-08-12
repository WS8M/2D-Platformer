using UnityEngine;

public class PlayerStalk : MonoBehaviour
{
    [SerializeField] private Transform _leftmostPoint;
    [SerializeField] private Transform _rightmostPoint;
    
    private Player _player;

    private bool _isCanStalk => _player is not null;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
            _player = player;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
            _player = null;
    }

    public bool TryGetPlayerPosition(out Vector3 position)
    {
        position = Vector3.zero;
        
        if (_isCanStalk == false)
            return false;
        
        position = CorrectionTargetPosition(_player.gameObject.transform.position);
        return true;
    }

    private Vector3 CorrectionTargetPosition(Vector3 targetPosition)
    {
        if (targetPosition.x < _leftmostPoint.position.x)
            return new Vector3(_leftmostPoint.position.x, targetPosition.y);

        if (targetPosition.x > _rightmostPoint.position.x)
            return new Vector3(_rightmostPoint.position.x, targetPosition.y);

        return targetPosition;
    }
}