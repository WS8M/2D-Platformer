using UnityEngine;
using UnityEngine.UI;

public class VampirismAbilityView: MonoBehaviour
{
    [SerializeField] private VampirismAbility _vampirismAbility;
    [SerializeField] private Slider _slider;
    [SerializeField] private Color _reloadColor;
    [SerializeField] private Color _usingColor;
    [SerializeField] private SpriteRenderer _zone;

    private bool _isUsing;
    private bool _isReloading;
    private Image _filledImage;

    public void Init()
    {
        _zone.transform.localScale = Vector3.one * _vampirismAbility.Radius;
        _zone.enabled = false;
        _slider.value = 1f;
        SetFilledArea(_usingColor);
    }
    
    private void OnEnable()
    {       
        _vampirismAbility.UpdateView += OnUpdateView;
        
        _vampirismAbility.WorkStarted += OnWorkStarted;
        _vampirismAbility.ReloadStarted += OnReloadStarted;
        _vampirismAbility.WorkEnded += OnWorkEnded;
    }

    private void OnDisable()
    {
        _vampirismAbility.UpdateView -= OnUpdateView;
        
        _vampirismAbility.WorkStarted -= OnWorkStarted;
        _vampirismAbility.ReloadStarted -= OnReloadStarted;
        _vampirismAbility.WorkEnded -= OnWorkEnded;
    }

    private void OnUpdateView(float progress)
    {
        _slider.value = progress;
    }

    private void OnWorkStarted()
    {
        _zone.enabled = true;
        SetColor(_usingColor);
    }
    
    private void OnReloadStarted()
    {
        _zone.enabled = false;
        SetColor(_reloadColor);
    }
    
    private void OnWorkEnded()
    {
        SetColor(_usingColor);
    }

    private void SetFilledArea(Color color)
    {
        _filledImage = _slider.fillRect.GetComponent<Image>();
        SetColor(color);
    }

    private void SetColor(Color color)
    {
        if (_filledImage is not null) 
            _filledImage.color = color;
    }
}