using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private static int VelocityY = Animator.StringToHash(nameof(VelocityY));
    private static int VelocityX = Animator.StringToHash(nameof(VelocityX));
    private static int IsOnGround = Animator.StringToHash(nameof(IsOnGround));

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Jumper _jumper;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat(VelocityY, _playerMover.Velocity.y);
        _animator.SetFloat(VelocityX,Mathf.Abs(_playerMover.Velocity.x));
        _animator.SetBool(IsOnGround, _jumper.IsOnGround);
    }
}