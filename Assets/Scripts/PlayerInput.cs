using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const float MinHorizontalValue = -1f;
    private const float MaxHorizontalValue = 1f;
    
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    private bool _readyToCLear;
    
    public float HorizontalInput { get; private set; }
    public bool JumpHold { get; private set; }

    
    private void Update()
    {
        ClearInputs();
        
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        _readyToCLear = true;
    }

    private void ProcessInputs()
    {
        HorizontalInput = Input.GetAxis(Horizontal);
        JumpHold = JumpHold || Input.GetButton(Jump);
    }

    private void ClearInputs()
    {
        if (_readyToCLear)
        {
            HorizontalInput = 0;
            JumpHold = false;

            _readyToCLear = false;
        }
    }
}