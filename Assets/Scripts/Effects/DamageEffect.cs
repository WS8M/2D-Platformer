using System.Collections;
using UnityEngine;
public class DamageEffect : Effect<UnitHealth>
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _color;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _duration;

    private float _currentTime;
    private Color _originalColor;

    private void OnEnable() => DependedObject.TookDamage += Play;

    private void OnDisable() => DependedObject.TookDamage -= Play;

    private void Awake() => _originalColor = _spriteRenderer.color;

    protected override void Play()
    {
        StartCoroutine(ColorSwitch());
    }

    private IEnumerator ColorSwitch()
    {
        _currentTime = 0;
        
        while (_currentTime < _duration)
        {
            _currentTime += Time.deltaTime;
            
            float transitionValue = _curve.Evaluate(_currentTime / _duration);
            
            var currentColor = Color.Lerp(_originalColor, _color, transitionValue);
            _spriteRenderer.color = currentColor;

            yield return new WaitForEndOfFrame();
        }

        InvokeEndedAction();
        yield return 0;
    }
}