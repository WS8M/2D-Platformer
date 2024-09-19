using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Interactables: MonoBehaviour
{
    protected abstract void Interact(Collider2D other);

    private void OnTriggerEnter2D(Collider2D other) =>
        Interact(other);
}