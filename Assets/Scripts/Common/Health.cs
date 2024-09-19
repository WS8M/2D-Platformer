using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    private float _value;

    public event Action<float> Changed;
    public event Action TookDamage;
    public event Action Died;
    
    public float MaxValue => _maxValue;
    
    public float Value
    {
        get => _value;

        private set
        {
            if(value == _value)
                return;
            
            _value = Mathf.Clamp(value, 0, _maxValue);
            
            Changed?.Invoke(_value);
            
            if (_value == 0)
                Died?.Invoke();
        }
    }
    
    private void Awake()
    {
        Value = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        Value -= damage;
        TookDamage?.Invoke();
    }

    public void TakeHealing(float healingValue)
    {
        if (healingValue < 0)
            throw new ArgumentOutOfRangeException(nameof(healingValue));

        Value += healingValue;
    }
}