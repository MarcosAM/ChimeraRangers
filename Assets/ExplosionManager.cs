using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    [SerializeField]
    ParticleSystem smallExplosionPrefab;

    [SerializeField]
    ParticleSystem bigExplosionPrefab;

    static ExplosionManager instance;


    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void SE(Vector3 position)
    {
        ParticleSystem ps = Instantiate(smallExplosionPrefab, position, Quaternion.identity);
        Destroy(ps, 0.7f);        
    }

    void BE(Vector3 position)
    {
        ParticleSystem ps = Instantiate(bigExplosionPrefab, position, Quaternion.identity);
        Destroy(ps, 0.7f);        
    }

    public static void BigExplosion(Vector3 position)
    {
        if(instance == null) return;
        instance.BE(position);
    }

    public static void SmallExplosion(Vector3 position)
    {
        if(instance == null) return;
        instance.SE(position);
    }
}
