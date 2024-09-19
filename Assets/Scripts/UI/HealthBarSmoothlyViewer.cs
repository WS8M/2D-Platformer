using System.Collections;
using UnityEngine;

public class HealthBarSmoothlyViewer : HealthBarViewer
{
    [SerializeField] private float _secondsToChange;
    
    private Coroutine _coroutine;
    
    protected override void OnChanged(float healthValue)
    {
        if (_coroutine is not null) 
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValue(healthValue));
    }
    
    private IEnumerator ChangeValue(float targetValue)
    {
        if (_secondsToChange <= 0)
        {
            Slider.value = targetValue;
            yield break;
        }
        
        var value = Slider.value;
        var deltaValue = Mathf.Abs(targetValue - value);
        
        while (value != targetValue)
        {
            value = Mathf.MoveTowards(value, targetValue, deltaValue * _secondsToChange * Time.deltaTime );
            Slider.value = value;
            yield return new WaitForEndOfFrame();
        }
    }
}