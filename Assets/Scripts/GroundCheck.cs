using UnityEngine;

public class GroundCheck : MonoBehaviour
{
   [SerializeField] private LayerMask _groundLayer;
   [SerializeField] private float _rayLength;
   [SerializeField] private Transform[] _rayStartPoints;
   [SerializeField] private Color _rayColor;

   private bool _isOnGround;

   public bool IsOnGround => _isOnGround;
   
   private void OnDrawGizmos()
   {
      foreach (var point in _rayStartPoints)
      {
         Vector3 startPosition = point.position;
         Vector3 endPosition = startPosition + Vector3.down * _rayLength;
         
         Debug.DrawLine(startPosition, endPosition, _rayColor);
      }
   }

   private void Update()
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
