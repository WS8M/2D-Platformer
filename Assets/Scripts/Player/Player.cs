using UnityEngine;

[RequireComponent(
    typeof(PlayerInput),
    typeof(PlayerMover), 
    typeof(Jumper))]
public class Player : MonoBehaviour, IHealthRecoverable
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Health _health;
    
    private PlayerInput _input;
    private PlayerMover _mover;
    private Jumper _jumper;

    private void OnEnable()
    {
        _attacker.Attacked += OnAttacked;
    }

    private void OnDisable()
    {
        _attacker.Attacked -= OnAttacked;
    }

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _mover = GetComponent<PlayerMover>();
        _jumper = GetComponent<Jumper>();
    }

    private void FixedUpdate()
    {
        _mover.Walk(_input.HorizontalInput);
        _jumper.Jump(_input);
    }

    private void OnAttacked() => 
        _jumper.JumpAfterAttack();

    public void RecoverHealth(float recoveryValue) => 
        _health.TakeHealing(recoveryValue);
}