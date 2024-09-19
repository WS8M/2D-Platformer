using UnityEngine;

public class GroundDetector : MonoBehaviour
{
   [SerializeField] private float _raycastDelay = 0.1f;
   [SerializeField] private LayerMask _groundLayer;
   [SerializeField] private float _rayLength;
   [SerializeField] private Transform[] _rayStartPoints;

   private float _currentTime;
   private bool _isOnGround;

   public bool IsOnGround => _isOnGround;

   private void FixedUpdate()
   {
      if (_currentTime >= 0)
      {
         _currentTime -= Time.fixedDeltaTime;
         
         if (_currentTime < 0)
         {
            _currentTime = _raycastDelay;
            RaycastIntoGround();
         }
      }
   }

   private void RaycastIntoGround()
   {
      foreach (var point in _rayStartPoints)
      {
         RaycastHit2D hit = Physics2D.Raycast(point.position, Vector2.down, _rayLength, _groundLayer.value);
         _isOnGround = hit.collider is not null;
         
         if(_isOnGround)
            break;
      }
   }
}