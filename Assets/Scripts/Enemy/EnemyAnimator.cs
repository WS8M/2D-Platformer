using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private static int VelocityX = Animator.StringToHash(nameof(VelocityX));

    [SerializeField] private EnemyMover _enemyMover;
    
    private Animator _animator;

    private void Awake() => _animator = GetComponent<Animator>();

    private void Update()
    {
        _animator.SetFloat(VelocityX,Mathf.Abs(_enemyMover.Velocity.x));
    }
}
