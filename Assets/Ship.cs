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

    [SerializeField]
    Brake brakePrefab;

    [SerializeField]
    Stabilizer stabilizerPrefab;

    float stabilization;

    List<ShipPart> parts = new List<ShipPart>();

    public Action OnCompletelyBreak;

    public float GetStabilization() { return stabilization; }

    void UpdateStabilization()
    {
        stabilization = Stabilizer.GetStabilizatonBonus(parts);
    }

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
            UpdateStabilization();
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
                    cannon.SetShip(this);
                    cannon.OnBreak += OnShipPartBreak;
                    parts.Add(cannon);
                }

                if (ShipBlueprintManager.GetShipPart(idx) == ShipBlueprintManager.ShipParts.Brake)
                {
                    Brake brake = Instantiate(brakePrefab, transform.position, Quaternion.identity, partsHandlers[idx]);
                    brake.transform.localPosition = partsPositions[idx];
                    brake.SetInputType((ShipPart.InputType)idx);
                    brake.OnBreak += OnShipPartBreak;
                    parts.Add(brake);
                }

                if (ShipBlueprintManager.GetShipPart(idx) == ShipBlueprintManager.ShipParts.Turbine)
                {
                    Propeller propeller = Instantiate(propellerPrefab, transform.position, Quaternion.identity, partsHandlers[idx]);
                    propeller.transform.localPosition = partsPositions[idx];
                    propeller.SetInputType((ShipPart.InputType)idx);
                    propeller.OnBreak += OnShipPartBreak;
                    parts.Add(propeller);
                }

                if (ShipBlueprintManager.GetShipPart(idx) == ShipBlueprintManager.ShipParts.Stabilizer)
                {
                    Stabilizer stabilizer = Instantiate(stabilizerPrefab, transform.position, Quaternion.identity, partsHandlers[idx]);
                    stabilizer.transform.localPosition = partsPositions[idx];
                    stabilizer.SetInputType((ShipPart.InputType)idx);
                    stabilizer.OnBreak += OnShipPartBreak;
                    parts.Add(stabilizer);
                }
            }
            else
            {
                parts.Add(null);
            }
        }
        UpdateStabilization();
    }

    public List<ShipPart> GetParts() { return parts; }
}
