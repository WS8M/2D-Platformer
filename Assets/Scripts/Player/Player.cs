using UnityEngine;

[RequireComponent(
    typeof(PlayerInput),
    typeof(PlayerMover), 
    typeof(Jumper))]
public class Player : MonoBehaviour, IHealthRecoverable
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Health _health;
    [SerializeField] private VampirismAbility _ability;
    [SerializeField] private VampirismAbilityView _abilityView;
    
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
        _ability.Init(_health);
        _abilityView.Init();
    }

    private void FixedUpdate()
    {
        _mover.Walk(_input.HorizontalInput);
        _jumper.Jump(_input);
        
        if (_input.ActionInput && _ability.IsWorking == false)
            _ability.Activate();
    }

    private void OnAttacked() => 
        _jumper.JumpAfterAttack();

    public void RecoverHealth(float recoveryValue) => 
        _health.TakeHealing(recoveryValue);
}