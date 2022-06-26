using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : HoldShipPart
{

    [SerializeField]
    ParticleSystem ps;

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
                rb2d.AddForce((transform.parent.position - transform.position).normalized * 80f * Time.deltaTime);
                Temperature += 0.2f * Time.deltaTime;

                if(ps.isStopped)
                {
                    ps.Play();
                }
            }
            else
            {
                if(ps.isPlaying)
                {
                    ps.Stop();
                }
                Cooldown();
            }
        }
    }
}
