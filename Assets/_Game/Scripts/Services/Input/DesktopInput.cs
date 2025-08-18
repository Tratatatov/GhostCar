using UnityEngine;

public class DesktopInput : IInput
{
    private const string Vertical = "Vertical";
    private const string Horizontal = "Horizontal";
    private bool _isEnabled = true;

    public bool IsEnabled { get => _isEnabled; }

    public Vector2 GetAxis()
    {
        if (_isEnabled == false) return Vector2.zero;

        Vector2 inputAxis = new Vector2(
            Input.GetAxis(Horizontal),
            Input.GetAxis(Vertical)
            );
        return inputAxis;
    }

    public bool IsBraking()
    {
        if (_isEnabled == false) return false;

        return Input.GetKey(KeyCode.Space);
    }

    public void Enable() => _isEnabled = true;

    public void Disable() => _isEnabled = false;

}