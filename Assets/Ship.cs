using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    parts.Add(cannon);
                }

                if (ShipBlueprintManager.GetShipPart(idx) == ShipBlueprintManager.ShipParts.Turbine)
                {
                    Propeller propeller = Instantiate(propellerPrefab, transform.position, Quaternion.identity, partsHandlers[idx]);
                    propeller.transform.localPosition = partsPositions[idx];
                    propeller.SetInputType((ShipPart.InputType)idx);
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
