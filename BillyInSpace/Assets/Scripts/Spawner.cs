using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] asteroids;
    [SerializeField]
    GameObject coin;
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

    public void SpawnCoin()
    {
        var coinObject = coin;
        coinObject.GetComponent<Coin>().setSpeed(asteroidBaseSpeed * Random.Range(0.65f, 1.4f));
        Instantiate(coinObject, gameObject.transform.position, gameObject.transform.rotation);
    }

    void IncreaseAsteroidSpeed()
    {
        if (asteroidBaseSpeed >= 10) return;
        asteroidBaseSpeed *= 1.05f;
    }
}
