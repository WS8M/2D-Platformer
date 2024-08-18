using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _delayAfterAttack;

    private bool _isCanAttack = true;
    private bool _currentTime;
    
    private WaitForSeconds _wait;

    private void Awake() => 
        _wait = new WaitForSeconds(_delayAfterAttack);

    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (_isCanAttack)
        {
            if (other.gameObject.TryGetComponent(out UnitHealth health))
            {
                StartCoroutine(ReadinessTimer());
                health.TakeDamage(_damage);
            }
        }
    }

    private IEnumerator ReadinessTimer()
    {
        _isCanAttack = false;
        
        yield return _wait;
        
        _isCanAttack = true;
    }
}