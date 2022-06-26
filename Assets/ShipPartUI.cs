using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShipPartUI : MonoBehaviour
{
    [SerializeField]
    Slider tempSlider;

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
        tempSlider.value = temperature;
    }

    void OnHpPercentageChange(float hpPercentage)
    {
        hpTxt.text = String.Format("{0:P0}", hpPercentage);
    }
}
