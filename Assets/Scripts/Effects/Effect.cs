using System;
using UnityEngine;

public abstract class Effect<T>: MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T DependedObject;
    public event Action Ended;
    
    protected abstract void Play();

    protected void InvokeEndedAction() => Ended?.Invoke();
}