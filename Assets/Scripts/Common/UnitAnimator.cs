using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator))]
public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [FormerlySerializedAs("_mover")] [SerializeField] protected DirectionSwitcher _directionSwitcher;

    protected Animator Animator;
    
    private void OnEnable() => 
        _directionSwitcher.DirectionSwitched += Flip;

    private void OnDisable() => 
        _directionSwitcher.DirectionSwitched -= Flip;

    private void Awake() => 
        Animator = GetComponent<Animator>();

    private void Flip(int direction)
    {
        bool isMovingRight = direction > 0;
        _spriteRenderer.Flip(isMovingRight);
    }
}