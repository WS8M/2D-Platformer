using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _zone;
    [SerializeField] private float _amountStolenHealthInSecond;
    [SerializeField] private float _durationOfAbility;
    [SerializeField] private float _reloadTime;
    
    private Health _health;
    private List<Health> _targets;
    private float _currentUseTime;
    private float _currentReloadTime;

    public bool IsWorking { get; private set; }

    public event Action<float> UpdateView;
    public event Action ReloadStarted;
    public event Action WorkStarted;
    public event Action WorkEnded;

    public float Radius => _zone.radius;

    public void Init(Health health)
    {
        _health = health;
        _targets = new List<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health health)) 
            _targets.Add(health);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health health))
            foreach (var target in _targets.ToList())
                if (target == health)
                    _targets.Remove(target);
    }
    
    public void Activate() => 
        StartCoroutine(AbilityWork());

    private IEnumerator AbilityWork()
    {
        WorkStarted?.Invoke();

        var wait = new WaitForEndOfFrame();

        IsWorking = true;
        _currentUseTime = _durationOfAbility;
        _currentReloadTime = _reloadTime;

        while (_currentUseTime > 0)
        {
            Use(Time.deltaTime);
            yield return wait;
        }

        ReloadStarted?.Invoke();

        while (_currentReloadTime > 0)
        {
            Reload(Time.deltaTime);
            yield return wait;
        }

        WorkEnded?.Invoke();
        IsWorking = false;
    }

    private void Use(float deltaTime)
    {
        if (_currentUseTime + deltaTime < 0) 
            deltaTime = _currentUseTime;
        
        float amountOfStolenHealth = _amountStolenHealthInSecond * deltaTime;
        
        if (_currentUseTime > 0)
        {
            _currentUseTime -= deltaTime;

            UpdateView?.Invoke(_currentUseTime / _durationOfAbility);
            
            foreach (var target in _targets)
            {
                target.TakeDamage(amountOfStolenHealth);
                _health.TakeHealing(amountOfStolenHealth);
            }
        }
    }

    private void Reload(float deltaTime)
    {
        if (_currentReloadTime > 0)
        {
            _currentReloadTime -= deltaTime;
            UpdateView?.Invoke(1f - (_currentReloadTime / _reloadTime));
        }
    }
}