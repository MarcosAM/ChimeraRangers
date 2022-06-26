using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOSpawner : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPoints;
    float spawnRateBase = 0.8f;
    float spawnRateVariation = 1.5f;

    [SerializeField]
    Projectile projectilePrefab;
    
    [SerializeField]
    Projectile biggerBrownPrefab;

    [SerializeField]
    Projectile bBouncePrefab;
    
    [SerializeField]
    Projectile sBouncePrefab;
    
    [SerializeField]
    Transform playersShip;

    void Shoot(Vector3 origin)
    {
        float chance = Random.value;
        if(chance > 0.75f)
        {
            Projectile projectile = Instantiate(projectilePrefab, origin, Quaternion.identity);
            projectile.Fire((playersShip.position - origin).normalized);
            return;
        }

        if(chance > 0.5f)
        {
            Projectile biggerBrown = Instantiate(biggerBrownPrefab, origin, Quaternion.identity);
            biggerBrown.Fire((playersShip.position - origin).normalized);
            return;
        }

        if(chance > 0.25f)
        {
            Projectile bBounce = Instantiate(bBouncePrefab, origin, Quaternion.identity);
            bBounce.Fire((playersShip.position - origin).normalized);
            return;
        }

        Projectile sBounce = Instantiate(sBouncePrefab, origin, Quaternion.identity);
        sBounce.Fire((playersShip.position - origin).normalized);
        return;
    }

    void ShootFromRandomSpawnPoint()
    {
        int randomIdx = Random.Range(0, spawnPoints.Length);
        Shoot(spawnPoints[randomIdx].position);
    }

    IEnumerator StartShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRateBase + (Random.value * spawnRateVariation));
            ShootFromRandomSpawnPoint();
        }
    }

    void Start()
    {
        ShootFromRandomSpawnPoint();
        StartCoroutine("StartShooting");
    }
}
