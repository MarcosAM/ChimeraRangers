using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    protected float Temperature
    {
        set
        {
            if (value >= maxTemp)
            {
                temperature = maxTemp;
                overheated = true;
                return;
            }
            if (value <= minTemp)
            {
                temperature = minTemp;
                if (overheated) overheated = false;
                return;
            }
            temperature = value;
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
