using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldShipPart : ShipPart
{
    protected override bool HandleInput()
    {
        if (overheated) return false;
        switch (this.inputType)
        {
            case (ShipPart.InputType.First):
                return InputHandler.GetFirstHold();
            case (ShipPart.InputType.Second):
                return InputHandler.GetSecondHold();
            case (ShipPart.InputType.Third):
                return InputHandler.GetThirdHold();
            case (ShipPart.InputType.Forth):
                return InputHandler.GetForthHold();
            default:
                return false;
        }
    }
}
