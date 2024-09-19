using System;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected Rigidbody2D Rigidbody;
    
    protected int Direction = 1;

    public event Action<int> DirectionSwitched;
    
    public Vector2 Velocity => Rigidbody.velocity;

    protected void SwitchDirection(int newDirection)
    {
        Direction = newDirection;
        DirectionSwitched?.Invoke(Direction);
    }
}
