using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sp;

    [SerializeField]
    Breakable breakable;

    float duration = 1.25f;
    float progress = 0;

    IEnumerator Flashing()
    {
        while(progress <= duration)
        {
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a == 1 ? 0 : 1);
            yield return new WaitForSeconds(0.125f);
            progress += 0.25f;
        }
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 1);
        progress = 0;
    }

    void StartFlashing()
    {
        if(progress != 0)
        {
            progress = 0;
        }
        else
        {
            progress = 0;
            StartCoroutine("Flashing");
        }
    }

    void Start()
    {
        breakable.OnDmgTaken += StartFlashing;
    }
}
