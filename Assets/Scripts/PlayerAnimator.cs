using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string VelocityY = nameof(VelocityY);
    private const string VelocityX = nameof(VelocityX);
    private const string IsOnGround = nameof(IsOnGround);

    [SerializeField] private PlayerMovement _playerMovement;
    
    private Animator _animator;

    private void Awake() => _animator = GetComponent<Animator>();

    private void Update()
    {
        _animator.SetFloat(VelocityY, _playerMovement.Velocity.y);
        _animator.SetFloat(VelocityX,Mathf.Abs(_playerMovement.Velocity.x));
        _animator.SetBool(IsOnGround, _playerMovement.IsOnGround);
    }
}