using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator))]
public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [FormerlySerializedAs("_flipable")] [SerializeField] protected Mover _mover;

    protected Animator Animator;
    
    private void OnEnable() => 
        _mover.DirectionSwitched += Flip;

    private void OnDisable() => 
        _mover.DirectionSwitched -= Flip;

    private void Awake() => 
        Animator = GetComponent<Animator>();

    private void Flip(int direction)
    {
        bool isMovingRight = direction > 0;
        _spriteRenderer.Flip(isMovingRight);
    }
}