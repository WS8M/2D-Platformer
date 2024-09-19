using UnityEngine;
using UnityEngine.UI;

public class HealthBarViewer : HealthViewer
{
    [SerializeField] protected Slider Slider;
    [SerializeField] protected Color Color;
    
    private Image _filledImage;
    
    protected virtual void Awake()
    {
        Slider.maxValue = Health.MaxValue;
        Slider.minValue = 0;
        Slider.value = Health.MaxValue;
        SetFilledArea();
    }

    protected override void OnChanged(float healthValue)
    {
        ChangeValue(healthValue);
    }

    private void ChangeValue(float targetValue)
    {
        Slider.value = targetValue;
    }
    
    private void SetFilledArea()
    {
        _filledImage = Slider.fillRect.GetComponent<Image>();
        
        if (_filledImage is not null) 
            _filledImage.color = Color;
    }
}