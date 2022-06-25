using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Untouchable : MonoBehaviour
{
    [SerializeField]
    float dmg;
    [SerializeField]
    float pushIntensity;

    public Action OnAttackedIt;

    void OnCollisionEnter2D(Collision2D col)
    {
        Breakable breakable = col.gameObject.GetComponent<Breakable>();
        if (breakable != null)
        {
            breakable.AttackIt(new Breakable.Damage() { value = dmg, pushIntensity = this.pushIntensity, pushDirection = col.transform.position - transform.position });
            if (OnAttackedIt != null) OnAttackedIt();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Breakable breakable = col.gameObject.GetComponent<Breakable>();
        if (breakable != null)
        {
            breakable.AttackIt(new Breakable.Damage() { value = dmg, pushIntensity = this.pushIntensity, pushDirection = col.transform.position - transform.position });
            if (OnAttackedIt != null) OnAttackedIt();
        }
    }
}
