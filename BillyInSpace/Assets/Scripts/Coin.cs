using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Asteroid
{
    [SerializeField]
    AudioClip coinPickupSound;

    public override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Player>())
        {
            AudioSource.PlayClipAtPoint(coinPickupSound, new Vector3(0, 0, -10), 0.5f);
            collision.gameObject.GetComponent<Player>().AddCoin();
            Destroy(gameObject);
        }
    }
}
