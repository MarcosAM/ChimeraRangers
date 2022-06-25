using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (rb2d != null)
            {
                rb2d.AddForce((transform.parent.position - transform.position) * 0.1f);
            }
        }
    }
}
