using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] protected Mover Mover;

    protected Animator Animator;
    
    private void OnEnable() => 
        Mover.DirectionSwitched += Flip;

    private void OnDisable() => 
        Mover.DirectionSwitched -= Flip;

    private void Awake() => 
        Animator = GetComponent<Animator>();

    private void Flip(int direction)
    {
        bool isMovingRight = direction > 0;
        _spriteRenderer.Flip(isMovingRight);
    }
}