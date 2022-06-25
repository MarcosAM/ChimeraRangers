using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    Projectile projectilePrefab;
    Rigidbody2D rb2d;

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
        float recoil = 30f;
        Vector2 oppositeDir = (transform.position - transform.parent.position).normalized * -1;
        rb2d.AddForce(oppositeDir * recoil);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            Recoil();
        }
    }
}
