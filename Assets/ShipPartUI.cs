using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShipPartUI : MonoBehaviour
{
    [SerializeField]
    Text text;

    public void SetShipPart(ShipPart shipPart)
    {
        OnTemperatureChange(shipPart.Temperature);
        shipPart.OnTemperatureChange += OnTemperatureChange;
    }

    void OnTemperatureChange(float temperature)
    {
        text.text = String.Format("T: {0:P2}", temperature);
    }
}
