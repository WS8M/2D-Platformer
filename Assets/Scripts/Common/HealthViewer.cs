using UnityEngine;

public abstract class HealthViewer : MonoBehaviour
{
    [SerializeField] protected Health Health;
    
    private void OnEnable()
    {
        Health.Changed += OnChanged;
    }

    private void OnDisable()
    {
        Health.Changed -= OnChanged;
    }
    
    protected abstract void OnChanged(float healthValue);
}