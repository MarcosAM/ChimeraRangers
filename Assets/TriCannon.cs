using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriCannon : Cannon
{
    [SerializeField]
    Transform[] cannons;

    protected override void Shoot()
    {
        foreach (Transform cannon in cannons)
        {
            ShootFrom(cannon.position);
        }
    }
}
