using System;
using UnityEngine;

public class Coin : Interactables, ICollectable
{
    [SerializeField] private int _value;
    
    public event Action Collected;

    public void Collect()
    {
        Collected?.Invoke();
        gameObject.SetActive(false);
    }

    protected override void Interact(Collider2D other)
    {
        if (other.TryGetComponent(out CoinCollector coinCollector))
        {
            coinCollector.AddCoins(_value);
            Collect();
        }
    }
}