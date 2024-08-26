using System;
using UnityEngine;

public abstract class HealthListener: MonoBehaviour
{
    [SerializeField] protected UnitHealth Health;
    public event Action Ended;
    
    protected abstract void Play();

    protected void InvokeEndedAction() => Ended?.Invoke();
}