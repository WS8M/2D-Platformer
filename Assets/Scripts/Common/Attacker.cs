using System;
using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _delayAfterAttack;

    private Health _target;

    private bool _canAttack = true;
    private bool _currentTime;

    private WaitForSeconds _wait;

    public event Action Attacked;

    private void Awake() =>
        _wait = new WaitForSeconds(_delayAfterAttack);

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_canAttack)
        {
            if (other.gameObject.TryGetComponent(out Health health))
            {
                StartCoroutine(CountDelayBetweenAttack());
                health.TakeDamage(_damage);
                Attacked?.Invoke();
            }
        }
    }

    private IEnumerator CountDelayBetweenAttack()
    {
        _canAttack = false;
        
        yield return _wait;
        
        _canAttack = true;
    }
}