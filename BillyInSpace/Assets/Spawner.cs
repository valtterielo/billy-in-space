using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] asteroids;

    private void Start()
    {
        //InvokeRepeating("SpawnAsteroid", 0.5f, 1.5f);
    }

    public void SpawnAsteroid()
    {
        Instantiate(asteroids[Random.Range(0, asteroids.Length)], gameObject.transform.position, gameObject.transform.rotation);
    }
}
