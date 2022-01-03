using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    [SerializeField]
    ParticleSystem enemySplatter;

    [SerializeField]
    AudioClip deathSound;

    GameObject target;

    void Start()
    {
        target = GameObject.Find("Astronaut");
    }

    void FixedUpdate()
    {
        ChaseTarget();
        RotateTowardsTarget();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().DecreaseHealth();
            Destroy(gameObject);
        }
    }

    void ChaseTarget()
    {
        if (target == null) return;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void RotateTowardsTarget()
    {
        if (target == null) return;
        var offset = 90f;
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    public void SetSpeed(float NewSpeed)
    {
        speed = NewSpeed;
    }

    public void KillEnemy()
    {
        Vibration.Init();
        Vibration.VibratePop();
        AudioSource.PlayClipAtPoint(deathSound, new Vector3(0, 0, -10), 0.7f);
        var splatter = Instantiate(enemySplatter, gameObject.transform.position, gameObject.transform.rotation);
        splatter.Play();
        Destroy(gameObject);
    }
}
