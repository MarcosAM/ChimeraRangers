using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Untouchable : MonoBehaviour
{
    [SerializeField]
    float dmg;

    public Action OnAttackedIt;

    void OnCollisionEnter2D(Collision2D col)
    {
        Breakable breakable = col.gameObject.GetComponent<Breakable>();
        if (breakable != null)
        {
            breakable.AttackIt(new Breakable.Damage() { value = dmg });
            if (OnAttackedIt != null) OnAttackedIt();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Breakable breakable = col.gameObject.GetComponent<Breakable>();
        if (breakable != null)
        {
            breakable.AttackIt(new Breakable.Damage() { value = dmg });
            if (OnAttackedIt != null) OnAttackedIt();
        }
    }
}
