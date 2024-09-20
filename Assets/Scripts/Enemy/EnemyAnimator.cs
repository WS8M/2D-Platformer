using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : UnitAnimator
{
    private static int VelocityX = Animator.StringToHash(nameof(VelocityX));
    
    private void Awake() => Animator = GetComponent<Animator>();

    private void Update()
    {
        Animator.SetFloat(VelocityX,Mathf.Abs(_directionSwitcher.Velocity.x));
    }
}