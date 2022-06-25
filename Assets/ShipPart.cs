using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipPart : MonoBehaviour
{
    public enum InputType
    {
        First,
        Second,
        Third
    }

    protected InputType inputType;

    public void SetInputType(InputType it)
    {
        this.inputType = it;
    }
    protected abstract bool HandleInput();
}
