using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    private bool _readyToCLear;
    
    public float HorizontalInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool JumpHold { get; private set; }

    
    private void Update()
    {
        ClearInputs();
        
        ProcessInputs();

        NormalizeHorizontalInput();
    }

    private void FixedUpdate()
    {
        _readyToCLear = true;
    }

    private void ProcessInputs()
    {
        HorizontalInput += Input.GetAxis(Horizontal);
        JumpPressed = JumpPressed || Input.GetButtonDown(Jump);
        JumpHold = JumpHold || Input.GetButton(Jump);
    }

    private void NormalizeHorizontalInput()
    {
        const float MinHorizontalValue = -1f;
        const float MaxHorizontalValue = 1f;
        
        HorizontalInput = Mathf.Clamp(HorizontalInput, MinHorizontalValue, MaxHorizontalValue);
    }

    private void ClearInputs()
    {
        if (_readyToCLear)
        {
            HorizontalInput = 0;
            JumpHold = false;
            JumpPressed = false;

            _readyToCLear = false;
        }
    }
}