using System;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _value;

    public int Value => _value;

    public  event Action Collected;
    
    public void Collect()
    {
        Collected?.Invoke();
        gameObject.SetActive(false);
    }
}