using UnityEngine;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] private UnitHealth _unitHealth;

    private void OnEnable() => _unitHealth.OnHealthChanged += UpdateHealthDisplay;

    private void OnDisable() => _unitHealth.OnHealthChanged -= UpdateHealthDisplay;

    private void UpdateHealthDisplay(float healthValue)
    {
        Debug.Log($"Health = {healthValue}");
    }
}
