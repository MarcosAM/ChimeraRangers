using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShipPartUI : MonoBehaviour
{
    [SerializeField]
    Text tempTxt;

    [SerializeField]
    Text hpTxt;

    public void SetShipPart(ShipPart shipPart)
    {
        if (shipPart != null)
        {
            OnTemperatureChange(shipPart.Temperature);
            shipPart.OnTemperatureChange += OnTemperatureChange;

            OnHpPercentageChange(shipPart.GetHpPercentage());
            shipPart.OnHpPercentageChange += OnHpPercentageChange;
        }
    }

    void OnTemperatureChange(float temperature)
    {
        tempTxt.text = String.Format("T: {0:P2}", temperature);
    }

    void OnHpPercentageChange(float hpPercentage)
    {
        hpTxt.text = String.Format("H: {0:P2}", hpPercentage);
    }
}
