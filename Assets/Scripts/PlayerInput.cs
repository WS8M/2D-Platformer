using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    private bool _readyToCLear;
    
    public float HorizontalInput { get; private set; }
    public bool JumpHold { get; private set; }
    
    private void Update()
    {
        if (_readyToCLear) 
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
        HorizontalInput = 0;
        JumpHold = false;

        _readyToCLear = false;
    }
}