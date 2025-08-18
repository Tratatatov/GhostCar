using UnityEngine;

public interface IInput
{
    bool IsEnabled { get; }
    Vector2 GetAxis();
    bool IsBraking();
}
