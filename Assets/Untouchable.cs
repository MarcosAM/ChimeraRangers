using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Untouchable : MonoBehaviour
{
    [SerializeField]
    float dmg;

    void OnCollisionEnter2D(Collision2D col)
    {
        Breakable breakable = col.gameObject.GetComponent<Breakable>();
        if (breakable != null)
        {
            breakable.AttackIt(new Breakable.Damage() { value = dmg });
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Breakable breakable = col.gameObject.GetComponent<Breakable>();
        if (breakable != null)
        {
            breakable.AttackIt(new Breakable.Damage() { value = dmg });
        }
    }
}
