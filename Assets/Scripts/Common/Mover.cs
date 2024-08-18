using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float Speed;
    
    protected Rigidbody2D Rigidbody;
    protected int Direction = 1;
    
    public Vector2 Velocity => Rigidbody.velocity;
    
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }
}
