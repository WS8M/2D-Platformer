using UnityEngine;

[RequireComponent(typeof(PlayerInput),typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerMover _mover;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _mover = GetComponent<PlayerMover>();
    }

    private void FixedUpdate()
    {
        _mover.Walk(_input.HorizontalInput);
    }
}