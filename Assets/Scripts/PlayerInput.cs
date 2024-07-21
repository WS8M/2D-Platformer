using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);
    
    private float _horizontalInput;
    private bool _jumpPressed;
    private bool _jumpHold;
    
    public float HorizontalInput => _horizontalInput;
    public bool JumpPressed => _jumpPressed;
    public bool JumpHold => _jumpHold;
    
    private void Update()
    {
        _horizontalInput = Input.GetAxis(Horizontal);
        _jumpPressed = Input.GetButtonDown(Jump);
        _jumpHold = Input.GetButton(Jump);
    }
}