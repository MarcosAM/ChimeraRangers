using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : ClickShipPart
{
    [SerializeField]
    Projectile projectilePrefab;
    Ship ship;

    void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    void Shoot()
    {
        Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.Fire((transform.position - transform.parent.position).normalized);
    }

    float GetStabilization()
    {
        if(ship != null)
        {
            return ship.GetStabilization();
        }
        return 0;
    }

    float GetRecoil()
    {
        float appliedRecoil = 5f - GetStabilization();
        if(appliedRecoil <= 0) return 0;
        return appliedRecoil;
    }

    void Recoil()
    {
        float recoil = GetRecoil();
        if(recoil <= 0) return;
        Vector2 oppositeDir = (transform.position - transform.parent.position).normalized * -1;
        rb2d.AddForce(oppositeDir * recoil);
    }

    void Update()
    {
        if (HandleInput())
        {
            Shoot();
            Recoil();
            Temperature += 0.2f;
        }
        else
        {
            Cooldown();
        }
    }

    public void SetShip(Ship ship)
    {
        this.ship = ship;
    }
}
