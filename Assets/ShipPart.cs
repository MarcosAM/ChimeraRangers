using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ShipPart : Breakable
{
    public enum InputType
    {
        First,
        Second,
        Third,
        Forth
    }

    protected InputType inputType;

    public void SetInputType(InputType it)
    {
        this.inputType = it;
    }
    protected abstract bool HandleInput();

    protected float minTemp = 0;
    protected float temperature = 0;
    protected float maxTemp = 1;
    protected bool overheated = false;

    public Action<float> OnTemperatureChange;

    public Action OnOverheat;
    public Action OnCooldown;

    public float Temperature
    {
        set
        {
            float newValue = value;
            if (value >= maxTemp)
            {
                newValue = maxTemp;
                if (!overheated)
                {
                    overheated = true;
                    if (OnOverheat != null) OnOverheat();
                }
            }
            if (value <= minTemp)
            {
                newValue = minTemp;
                if (overheated)
                {
                    overheated = false;
                    if (OnCooldown != null) OnCooldown();
                }
            }
            temperature = newValue;
            if (OnTemperatureChange != null) OnTemperatureChange(temperature);
        }
        get
        {
            return temperature;
        }
    }

    [SerializeField]
    float cdRate;

    [SerializeField]
    float overheatedCdRate;


    protected void Cooldown()
    {
        if (overheated)
        {
            Temperature -= overheatedCdRate * Time.deltaTime;
        }
        else
        {
            Temperature -= cdRate * Time.deltaTime;
        }
    }
}
