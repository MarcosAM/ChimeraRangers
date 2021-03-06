using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Breakable : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D rb2d;
    protected float minHp = 0;
    [SerializeField]
    protected float hp = 100;
    [SerializeField]
    protected float maxHp = 100;
    public Action<float> OnHpPercentageChange;
    public Action OnDmgTaken;

    public Action<Breakable> OnBreak;

    void Break()
    {
        if (OnBreak != null) OnBreak(this);
        ExplosionManager.BigExplosion(transform.position);
        Destroy(gameObject);
    }

    float Hp
    {
        set
        {
            float newValue = value;
            if (value >= maxHp)
            {
                newValue = maxHp;
            }
            if (value <= minHp)
            {
                newValue = minHp;
                Break();
            }
            hp = newValue;
            if (OnHpPercentageChange != null) OnHpPercentageChange(hp / maxHp);
            if (OnDmgTaken != null && newValue > minHp) OnDmgTaken();
        }
        get
        {
            return hp;
        }
    }

    public float GetHpPercentage() { return hp / maxHp; }

    public struct Damage
    {
        public float value;
        public float pushIntensity;
        public Vector2 pushDirection;
    }

    [SerializeField]
    float pushResistence = 0f;

    public void AttackIt(Damage dmg)
    {
        Hp -= dmg.value;
        float pushOutcome = dmg.pushIntensity - pushResistence;
        if (dmg.pushIntensity - pushResistence > 0)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(dmg.pushDirection * pushOutcome);
        }
    }
}
