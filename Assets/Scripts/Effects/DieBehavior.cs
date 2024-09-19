using System.Collections;
using UnityEngine;

public class DieBehavior : HealthListener
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _torque;
    [SerializeField] private float _durationBeforeDestroyGameObjects;
    [SerializeField] private Enemy _destroyedObject;
    
    private void OnEnable() => Health.Died += Play;

    private void OnDisable() => Health.Died -= Play;

    protected override void Play()
    {
        StartCoroutine(Died());
    }

    private IEnumerator Died()
    {
        _collider.enabled = false;
        
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        _rigidbody.velocity = Vector2.zero;
        
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        _rigidbody.AddTorque(_torque,ForceMode2D.Force);
        
        var wait = new WaitForSeconds(_durationBeforeDestroyGameObjects);

        yield return wait;
        
        InvokeEndedAction();
    }
}