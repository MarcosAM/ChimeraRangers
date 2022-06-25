using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : ClickShipPart
{
    [SerializeField]
    Projectile projectilePrefab;

    void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    void Shoot()
    {
        Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.Fire((transform.position - transform.parent.position).normalized);
    }

    void Recoil()
    {
        float recoil = 10f;
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
}
