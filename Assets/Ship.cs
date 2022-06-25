using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    List<Vector2> partsPositions;

    [SerializeField]
    Cannon cannonPrefab;

    void Start()
    {
        for (int idx = 0; idx < partsPositions.Count; idx++)
        {
            if (ShipBlueprintManager.GetShipPart(idx) != ShipBlueprintManager.ShipParts.Nothing)
            {
                if (ShipBlueprintManager.GetShipPart(idx) == ShipBlueprintManager.ShipParts.Cannon)
                {
                    Cannon cannon = Instantiate(cannonPrefab, transform.position, Quaternion.identity, transform);
                    cannon.transform.localPosition = partsPositions[idx];
                }
            }
        }
    }
}
