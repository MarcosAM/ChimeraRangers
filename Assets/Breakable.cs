using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Breakable : MonoBehaviour
{
    protected float minHp = 0;
    [SerializeField]
    protected float hp = 100;
    [SerializeField]
    protected float maxHp = 100;
    public Action<float> OnHpPercentageChange;

    void Break()
    {
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
    }

    public void AttackIt(Damage dmg)
    {
        Hp -= dmg.value;
    }
}
