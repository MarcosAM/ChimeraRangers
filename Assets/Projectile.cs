using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    bool fired = false;
    [SerializeField]
    Rigidbody2D rb2d;
    float velocity = 300f;
    float duration = 2f;
    float currDuration = 0f;

    int hp = 1;

    [SerializeField]
    Untouchable untouchable;

    void WearOut()
    {
        hp -= 1;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (untouchable)
        {
            untouchable.OnAttackedIt += WearOut;
        }
    }

    public void Fire(Vector2 direction)
    {
        fired = true;
        rb2d.AddForce(direction * velocity);
    }

    void Update()
    {
        if (fired)
        {
            currDuration += Time.deltaTime;
            if (currDuration >= duration)
            {
                Destroy(gameObject);
            }
        }
    }
}
