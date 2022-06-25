using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartUIManager : MonoBehaviour
{
    [SerializeField]
    Ship playersShip;
    [SerializeField]
    ShipPartUI[] uis;

    void Start()
    {
        for (int i = 0; i < uis.Length; i++)
        {
            uis[i].SetShipPart(playersShip.GetParts()[i]);
        }
    }
}
