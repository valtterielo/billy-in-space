using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    float speed;
    void FixedUpdate()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().DecreaseHealth();
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public void setSpeed(float NewSpeed)
    {
        speed = NewSpeed;
    }

}
