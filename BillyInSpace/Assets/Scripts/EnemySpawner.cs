using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    float enemyBaseSpeed = 3f;
    void Start()
    {
        InvokeRepeating("IncreaseEnemySpeed", 15f, 15f);
    }
    public void SpawnEnemy()
    {
        var enemyToSpawn = enemies[Random.Range(0, enemies.Length)];
        enemyToSpawn.GetComponent<Enemy>().SetSpeed(enemyBaseSpeed * Random.Range(0.8f, 1.2f));
        Instantiate(enemyToSpawn, gameObject.transform.position, gameObject.transform.rotation);
    }
    void IncreaseEnemySpeed()
    {
        if (enemyBaseSpeed >= 8) return;
        enemyBaseSpeed *= 1.05f;
    }
}
