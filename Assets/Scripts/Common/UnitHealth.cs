using System;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _health;

    public event Action<float> HealthChanged;
    public event Action TookDamage;
    public event Action Died;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public float Health
    {
        get => _health;

        private set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);

            if (_health == 0)
                Died?.Invoke();
            else
                HealthChanged?.Invoke(_health);
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        Health -= damage;
        TookDamage?.Invoke();
    }

    public void Healing(float healingValue)
    {
        if (healingValue < 0)
            throw new ArgumentOutOfRangeException(nameof(healingValue));

        Health += healingValue;
    }
}
