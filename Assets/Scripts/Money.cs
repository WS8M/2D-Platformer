using System;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _coinQuantity;

    public int CoinQuantity => _coinQuantity;

    public  event Action Collected;
    
    public void Collect()
    {
        Collected?.Invoke();
        gameObject.SetActive(false);
    }
}