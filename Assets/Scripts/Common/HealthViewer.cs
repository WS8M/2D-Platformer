using UnityEngine;

public abstract class HealthViewer : MonoBehaviour
{
    [SerializeField] protected UnitHealth UnitHealth;
    
    private void OnEnable()
    {
        UnitHealth.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        UnitHealth.HealthChanged -= OnHealthChanged;
    }


    protected abstract void OnHealthChanged(float healthValue);
}