using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] GameObject[] AsteroidSpawners;
    [SerializeField] GameObject[] EnemySpawners;
    List<GameObject> UnusedAsteroidSpawners = new List<GameObject>();
    List<GameObject> UnusedEnemySpawners = new List<GameObject>();
    [SerializeField] float timeToSpawn = 2f;
    [SerializeField] float enemyTimeToSpawn = 7f;

    void Start()
    {
        foreach (GameObject asteroidSpawner in AsteroidSpawners)
        {
            UnusedAsteroidSpawners.Add(asteroidSpawner);
        }

        foreach (GameObject enemySpawner in EnemySpawners)
        {
            UnusedEnemySpawners.Add(enemySpawner);
        }

        StartCoroutine(ActivateAsteroidSpawners());
        StartCoroutine(ActivateEnemySpawners());
        InvokeRepeating("IncreaseSpawnrate", 15f, 15f);
        InvokeRepeating("IncreaseEnemySpawnrate", 15f, 15f);
    }
    IEnumerator ActivateAsteroidSpawners()
    {
        while (true)
        {
            RaffleCoinDrop();

            for (int i = 0; i <= 3; i++)
            {
                int ListIndex = Random.Range(0, UnusedAsteroidSpawners.Count);
                UnusedAsteroidSpawners[ListIndex].GetComponent<Spawner>().SpawnAsteroid();
                UnusedAsteroidSpawners.RemoveAt(ListIndex);
            }
            UnusedAsteroidSpawners.Clear();
            foreach (GameObject spawner in AsteroidSpawners)
            {
                UnusedAsteroidSpawners.Add(spawner);
            }
            yield return new WaitForSeconds(timeToSpawn);
        }      
    }

    IEnumerator ActivateEnemySpawners()
    {
        while (true)
        {
            for (int i = 0; i <= 0; i++)
            {
                int ListIndex = Random.Range(0, UnusedEnemySpawners.Count);
                UnusedEnemySpawners[ListIndex].GetComponent<EnemySpawner>().SpawnEnemy();
                UnusedEnemySpawners.RemoveAt(ListIndex);
            }
            UnusedEnemySpawners.Clear();
            foreach (GameObject enemySpawner in EnemySpawners)
            {
                UnusedEnemySpawners.Add(enemySpawner);
            }
            yield return new WaitForSeconds(enemyTimeToSpawn);
        }
    }
    void IncreaseSpawnrate()
    {
        if (timeToSpawn <= 0.98) return;
        timeToSpawn *= 0.95f;
    }

    void IncreaseEnemySpawnrate()
    {
        if (enemyTimeToSpawn <= 3.5) return;
        enemyTimeToSpawn *= 0.95f;
    }

    void RaffleCoinDrop()
    {
        if (Random.Range(0f, 1f) <= 0.4)
        {
            int ListIndex = Random.Range(0, UnusedAsteroidSpawners.Count);
            UnusedAsteroidSpawners[ListIndex].GetComponent<Spawner>().SpawnCoin();
            UnusedAsteroidSpawners.RemoveAt(ListIndex);
        }
    }
}
