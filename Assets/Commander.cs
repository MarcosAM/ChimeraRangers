using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Commander : ClickShipPart
{
    [SerializeField]
    float heat = 0.3f;
    List<InputType> inputTypes;


    void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    public void UpdateInputTypes(List<ShipPart> parts)
    {
        inputTypes = new List<InputType>();
        for(int i = 0;i < parts.Count; i++)
        {
            if(parts[i] is Cannon || parts[i] is TriCannon)
            {
                inputTypes.Add((InputType)i);
            }
        }
    }

    void ClickInputType(InputType it)
    {
        switch(it)
        {
            case(InputType.First):
                InputHandler.ForceFirst();
                break;
            case(InputType.Second):
                InputHandler.ForceSecond();
                break;
            case(InputType.Third):
                InputHandler.ForceThird();
                break;
            default:
                break;
        }
    }

    void ClickAll()
    {
        foreach(InputType it in inputTypes)
        {
            ClickInputType(it);
        }
    }

    void Update()
    {
        if (HandleInput())
        {
            ClickAll();
            Temperature += heat;
        }
        else
        {
            Cooldown();
        }
    }
}
