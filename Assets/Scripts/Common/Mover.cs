using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float Speed;
    
    protected Rigidbody2D Rigidbody;
    protected int Direction = 1;

    public event Action<int> DirectionSwitched;
    
    public Vector2 Velocity => Rigidbody.velocity;
    
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    protected void SwitchDirection(int newDirection)
    {
        Direction = newDirection;
        DirectionSwitched?.Invoke(Direction);
    }
}
