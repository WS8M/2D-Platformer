using UnityEngine;

public class PlayerAnimator : UnitAnimator
{
    private static int VelocityY = Animator.StringToHash(nameof(VelocityY));
    private static int VelocityX = Animator.StringToHash(nameof(VelocityX));
    private static int IsOnGround = Animator.StringToHash(nameof(IsOnGround));
    
    [SerializeField] private Jumper _jumper;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Animator.SetFloat(VelocityY, _directionSwitcher.Velocity.y);
        Animator.SetFloat(VelocityX,Mathf.Abs(_directionSwitcher.Velocity.x));
        Animator.SetBool(IsOnGround, _jumper.IsOnGround);
    }
}