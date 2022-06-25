using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBlueprintManager : MonoBehaviour
{
    public enum ShipParts
    {
        Turbine,
        Cannon,
        Nothing
    }

    public static Dictionary<string, ShipParts> partsTxtDic = new Dictionary<string, ShipParts>()
    {
        {"Turbine", ShipParts.Turbine},
        {"Cannon", ShipParts.Cannon},
        {"Nothing", ShipParts.Nothing}
    };

    static ShipBlueprintManager instance;
    List<ShipParts> parts = new List<ShipParts>() { ShipParts.Cannon, ShipParts.Cannon };

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public static void SetParts(ShipParts part, int idx)
    {
        if (instance != null)
        {
            if (idx >= 0 && idx < instance.parts.Count)
            {
                instance.parts[idx] = part;
            }
        }
    }

    public static ShipParts GetShipPart(int idx)
    {
        if (instance != null)
        {
            if (idx >= 0 && idx < instance.parts.Count)
            {
                return instance.parts[idx];
            }
        }
        return ShipParts.Nothing;
    }
}
