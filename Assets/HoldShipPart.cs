using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldShipPart : ShipPart
{
    protected override bool HandleInput()
    {
        switch (this.inputType)
        {
            case (ShipPart.InputType.First):
                return Input.GetMouseButton(0);
            case (ShipPart.InputType.Second):
                return Input.GetKey("z");
            case (ShipPart.InputType.Third):
                return Input.GetMouseButton(1);
            default:
                return false;
        }
    }
}
