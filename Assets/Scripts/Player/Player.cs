using UnityEngine;

[RequireComponent(
    typeof(PlayerInput),
    typeof(PlayerDirectionSwitcher), 
    typeof(Jumper))]
public class Player : MonoBehaviour, IHealthRecoverable
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Health _health;
    
    private PlayerInput _input;
    private PlayerDirectionSwitcher _directionSwitcher;
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
        _directionSwitcher = GetComponent<PlayerDirectionSwitcher>();
        _jumper = GetComponent<Jumper>();
    }

    private void FixedUpdate()
    {
        _directionSwitcher.Walk(_input.HorizontalInput);
        _jumper.Jump(_input);
    }

    private void OnAttacked() => 
        _jumper.JumpAfterAttack();

    public void RecoverHealth(float recoveryValue) => 
        _health.TakeHealing(recoveryValue);
}