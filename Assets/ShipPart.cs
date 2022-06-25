using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ShipPart : MonoBehaviour
{
    public enum InputType
    {
        First,
        Second,
        Third
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

    public float Temperature
    {
        set
        {
            float newValue = value;
            if (value >= maxTemp)
            {
                newValue = maxTemp;
                overheated = true;
            }
            if (value <= minTemp)
            {
                newValue = minTemp;
                if (overheated) overheated = false;
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

    protected float minHp = 0;
    [SerializeField]
    protected float hp = 100;
    [SerializeField]
    protected float maxHp = 100;
    public Action<float> OnHpPercentageChange;

    float Hp
    {
        set
        {
            float newValue = value;
            if (value >= maxHp)
            {
                newValue = maxHp;
            }
            if (value <= minHp)
            {
                newValue = minHp;
            }
            hp = newValue;
            if (OnHpPercentageChange != null) OnHpPercentageChange(hp / maxHp);
        }
        get
        {
            return hp;
        }
    }

    public float GetHpPercentage() { return hp / maxHp; }
}
