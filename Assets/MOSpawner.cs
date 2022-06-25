using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOSpawner : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPoints;
    float spawnRateBase = 0.8f;
    float spawnRateVariation = 1.2f;

    [SerializeField]
    Projectile projectilePrefab;
    [SerializeField]
    Transform playersShip;

    void Shoot(Vector3 origin)
    {
        Projectile projectile = Instantiate(projectilePrefab, origin, Quaternion.identity);
        projectile.Fire((playersShip.position - origin).normalized);
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
