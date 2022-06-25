using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickShipPart : ShipPart
{
    protected override bool HandleInput()
    {
        if (overheated) return false;
        switch (this.inputType)
        {
            case (ShipPart.InputType.First):
                return Input.GetMouseButtonDown(0);
            case (ShipPart.InputType.Second):
                return Input.GetKeyDown("z");
            case (ShipPart.InputType.Third):
                return Input.GetMouseButtonDown(1);
            default:
                return false;
        }
    }
}
