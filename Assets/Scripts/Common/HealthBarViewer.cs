using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarViewer : HealthViewer
{
    [SerializeField] protected Slider _slider;
    [SerializeField] private Color _color;
    [SerializeField] private float _secondsToChange;
    
    private Image _filledImage;
    
    private void OnValidate() => 
        SetFilledArea();
    
    private void Awake()
    {
        _slider.maxValue = UnitHealth.MaxHealth;
        _slider.minValue = 0;
        _slider.value = UnitHealth.MaxHealth;
        SetFilledArea();
    }

    protected override void OnHealthChanged(float healthValue)
    {
        StartCoroutine(ChangeValue(healthValue));
    }

    private IEnumerator ChangeValue(float targetValue)
    {
        if (_secondsToChange <= 0)
        {
            _slider.value = targetValue;
            yield break;
        }
        
        var value = _slider.value;
        var deltaValue = Mathf.Abs(targetValue - value);
        
        while (value != targetValue)
        {
            value = Mathf.MoveTowards(value, targetValue, deltaValue * _secondsToChange * Time.deltaTime );
            _slider.value = value;
            yield return new WaitForEndOfFrame();
        }
    }
    
    private void SetFilledArea()
    {
        _filledImage = _slider.fillRect.GetComponent<Image>();
        
        if (_filledImage is not null) 
            _filledImage.color = _color;
    }
}