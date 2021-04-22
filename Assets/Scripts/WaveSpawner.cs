using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyToSpawn;

    public Transform spawnPoint;

    public float timeToSpawn;
    public float timeBetweenEnemies;

    public int numberOfEnemies;
    public int numberOfWaves;

    private float spawnTimer = 2f;



    private void Update()
    {
        if (spawnTimer <= 0 && numberOfWaves > 0)
        {
            StartCoroutine(SpawnWave());
            spawnTimer = timeToSpawn;
        }

        spawnTimer -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBetweenEnemies);
        numberOfWaves--;
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
            yield return wait;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
