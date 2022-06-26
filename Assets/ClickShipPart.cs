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
                return InputHandler.GetFirstClick();
            case (ShipPart.InputType.Second):
                return InputHandler.GetSecondClick();
            case (ShipPart.InputType.Third):
                return InputHandler.GetThirdClick();
            default:
                return false;
        }
    }
}
