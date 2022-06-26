using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilizer : ClickShipPart
{
    [SerializeField]
    float bonus;

    void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    public static float GetStabilizatonBonus(List<ShipPart> parts)
    {
        Stabilizer stabilizer = (Stabilizer)parts.Find(p => p is Stabilizer);
        if(stabilizer != null)
        {
            return stabilizer.bonus;
        }
        return 0;
    }
}
