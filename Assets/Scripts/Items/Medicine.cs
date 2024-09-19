using System;
using UnityEngine;

public class Medicine : Interactables, ICollectable
{
    [SerializeField] private int _value;

    public event Action Collected;

    public void Collect()
    {
        Collected?.Invoke();
        gameObject.SetActive(false);
    }

    protected override void Interact(Collider2D other)
    {
        if (other.TryGetComponent(out IHealthRecoverable healthRecoverable))
        {
            healthRecoverable.RecoverHealth(_value);
            Collect();
        }
    }
}