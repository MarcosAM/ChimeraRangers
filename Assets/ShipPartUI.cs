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

    [SerializeField]
    Color highHp;

    [SerializeField]
    Color mediumHp;

    [SerializeField]
    Color lowHp;

    [SerializeField]
    Image blackout;

    [SerializeField]
    Text status;

    void OnBreak(Breakable breakable)
    {
        blackout.gameObject.SetActive(true);
        status.text = "Broken";
    }

    void OnCooldown()
    {
        blackout.gameObject.SetActive(false);
        status.text = string.Empty;
    }

    void OnOverheat()
    {
        blackout.gameObject.SetActive(true);
        status.text = "Overheat";
    }

    public void SetShipPart(ShipPart shipPart)
    {
        if (shipPart != null)
        {
            OnTemperatureChange(shipPart.Temperature);
            shipPart.OnTemperatureChange += OnTemperatureChange;

            OnHpPercentageChange(shipPart.GetHpPercentage());
            shipPart.OnHpPercentageChange += OnHpPercentageChange;

            shipPart.OnBreak += OnBreak;
            shipPart.OnCooldown += OnCooldown;
            shipPart.OnOverheat += OnOverheat;
        }
    }

    void OnTemperatureChange(float temperature)
    {
        tempSlider.value = temperature;
    }

    Color GetHpColor(float hpPercentage)
    {
        if(hpPercentage >= 0.75f) return highHp;
        if(hpPercentage > 0.25f) return mediumHp;
        return lowHp;
    }

    void OnHpPercentageChange(float hpPercentage)
    {
        hp.color = GetHpColor(hpPercentage);
        hp.fillAmount = hpPercentage;
    }
}
