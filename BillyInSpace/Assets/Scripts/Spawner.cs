using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] asteroids;
    [SerializeField]
    float asteroidBaseSpeed = 5f;
    void Start()
    {
        InvokeRepeating("IncreaseAsteroidSpeed", 15f, 15f);
    }
    public void SpawnAsteroid()
    {
        var asteroidToSpawn = asteroids[Random.Range(0, asteroids.Length)];
        asteroidToSpawn.GetComponent<Asteroid>().setSpeed(asteroidBaseSpeed * Random.Range(0.65f, 1.4f));
        Instantiate(asteroidToSpawn, gameObject.transform.position, gameObject.transform.rotation);
    }
    void IncreaseAsteroidSpeed()
    {
        if (asteroidBaseSpeed >= 10) return;
        asteroidBaseSpeed *= 1.05f;
    }
}
