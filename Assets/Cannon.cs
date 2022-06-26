using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : ClickShipPart
{
    [SerializeField]
    Projectile projectilePrefab;
    Ship ship;
    [SerializeField]
    float baseRecoil = 5f;
    [SerializeField]
    float heat = 0.2f;

    void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    protected void ShootFrom(Vector3 origin)
    {
        Projectile projectile = Instantiate(projectilePrefab, origin, Quaternion.identity);
        projectile.Fire((origin - transform.parent.position).normalized);        
    }

    protected virtual void Shoot()
    {
        ShootFrom(transform.position);
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
        float appliedRecoil = baseRecoil - GetStabilization();
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
            Temperature += heat;
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
