using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : ClickShipPart
{
    void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb2d != null)
        {
            if (HandleInput())
            {
                rb2d.velocity = Vector2.zero;
                Temperature += 0.35f;
            }
            else
            {
                Cooldown();
            }
        }
    }
}
