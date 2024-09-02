using TMPro;
using UnityEngine;

public class HealthTextViewer : HealthViewer
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void OnHealthChanged(float healthValue) => 
        _text.text = BuildText(healthValue);

    private string BuildText(float value) => 
        $"{value}|{UnitHealth.MaxHealth}";
}