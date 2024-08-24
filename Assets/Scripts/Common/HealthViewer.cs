using UnityEngine;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] private UnitHealth _unitHealth;
    
    private void OnEnable() => _unitHealth.HealthChanged += UpdateHealthDisplay;

    private void OnDisable() => _unitHealth.HealthChanged -= UpdateHealthDisplay;

    private void UpdateHealthDisplay(float healthValue)
    {
        Debug.Log($"Health = {healthValue}");
    }
}
