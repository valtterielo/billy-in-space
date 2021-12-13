using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] GameObject[] spawners;
    List<GameObject> UnusedSpawners = new List<GameObject>();
    [SerializeField] float timeToSpawn = 2f;
    void Start()
    {
        foreach (GameObject spawner in spawners)
        {
            UnusedSpawners.Add(spawner);
        }
        StartCoroutine(ActivateSpawners());
        InvokeRepeating("IncreaseSpawnrate", 15f, 15f);
    }
    IEnumerator ActivateSpawners()
    {
        while (true)
        {
            for (int i = 0; i <= 3; i++)
            {
                int ListIndex = Random.Range(0, UnusedSpawners.Count);
                UnusedSpawners[ListIndex].GetComponent<Spawner>().SpawnAsteroid();
                UnusedSpawners.RemoveAt(ListIndex);
            }
            UnusedSpawners.Clear();
            foreach (GameObject spawner in spawners)
            {
                UnusedSpawners.Add(spawner);
            }
            yield return new WaitForSeconds(timeToSpawn);
        }      
    }
    void IncreaseSpawnrate()
    {
        if (timeToSpawn <= 0.98) return;
        timeToSpawn *= 0.95f;
    }
}
