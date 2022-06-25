using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : HoldShipPart
{
    Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        if (HandleInput())
        {
            if (rb2d != null)
            {
                rb2d.AddForce((transform.parent.position - transform.position).normalized * 30f * Time.deltaTime);
            }
        }
    }
}
