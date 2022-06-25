using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ship : MonoBehaviour
{
    [SerializeField]
    List<Vector2> partsPositions;

    [SerializeField]
    List<Transform> partsHandlers;

    [SerializeField]
    Cannon cannonPrefab;

    [SerializeField]
    Propeller propellerPrefab;

    List<ShipPart> parts = new List<ShipPart>();

    public Action OnCompletelyBreak;

    void CheckIfCompletelyBreak()
    {
        bool notCompletelyBroken = parts.Exists(p => p != null);
        if (!notCompletelyBroken)
        {
            if (OnCompletelyBreak != null) OnCompletelyBreak();
        }
    }

    void OnShipPartBreak(Breakable shipPart)
    {
        int idx = parts.IndexOf((ShipPart)shipPart);
        if (idx >= 0)
        {
            parts[idx] = null;
            CheckIfCompletelyBreak();
        }
    }

    void Awake()
    {
        for (int idx = 0; idx < partsPositions.Count; idx++)
        {
            if (ShipBlueprintManager.GetShipPart(idx) != ShipBlueprintManager.ShipParts.Nothing)
            {
                if (ShipBlueprintManager.GetShipPart(idx) == ShipBlueprintManager.ShipParts.Cannon)
                {
                    Cannon cannon = Instantiate(cannonPrefab, transform.position, Quaternion.identity, partsHandlers[idx]);
                    cannon.transform.localPosition = partsPositions[idx];
                    cannon.SetInputType((ShipPart.InputType)idx);
                    cannon.OnBreak += OnShipPartBreak;
                    parts.Add(cannon);
                }

                if (ShipBlueprintManager.GetShipPart(idx) == ShipBlueprintManager.ShipParts.Turbine)
                {
                    Propeller propeller = Instantiate(propellerPrefab, transform.position, Quaternion.identity, partsHandlers[idx]);
                    propeller.transform.localPosition = partsPositions[idx];
                    propeller.SetInputType((ShipPart.InputType)idx);
                    propeller.OnBreak += OnShipPartBreak;
                    parts.Add(propeller);
                }
            }
            else
            {
                parts.Add(null);
            }
        }
    }

    public List<ShipPart> GetParts() { return parts; }
}
