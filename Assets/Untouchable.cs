using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Untouchable : MonoBehaviour
{
    [SerializeField]
    float dmg;

    void OnTriggerEnter2D(Collider2D col)
    {
        ShipPart shipPart = col.gameObject.GetComponent<ShipPart>();
        if (shipPart != null)
        {
            shipPart.AttackIt(new Breakable.Damage() { value = dmg });
        }
    }
}
