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
    Image hp;

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
        hp.fillAmount = hpPercentage;
    }
}
