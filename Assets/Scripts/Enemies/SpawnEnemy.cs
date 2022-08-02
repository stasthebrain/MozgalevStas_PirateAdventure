using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private float nextSpawnTime;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnStep = 25f;
    [SerializeField] private int maxSceletons = 3;
    private int spawner;

   
    
    void Update()
    {
        if ((Time.time > nextSpawnTime) && (spawner < maxSceletons))
            {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            spawner++;
            nextSpawnTime = Time.time + spawnStep;
            }
    }
}
