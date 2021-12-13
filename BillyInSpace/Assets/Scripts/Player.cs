using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int health = 3;

    [SerializeField]
    int score = 0;

    [SerializeField]
    float multiplier = 1.0f;

    [SerializeField]
    float speed = 10.0f;

    [SerializeField]
    GameObject gameOverScreen;

    void Start()
    {
        //Pisteiden kasvattaminen alkaa 0.5 sekuntia pelin k�ynnistymisen
        //j�lkeen ja p�ivittyy sekuntin v�lein
        InvokeRepeating("UpdateScore", 0.5f, 1f);
        //Pistelukeman kerroin kasvaa 10 sekuntin v�lein
        InvokeRepeating("IncreaseScoreMultiplier", 10f, 10f);
    }

    void FixedUpdate()
    {
        if (Input.touchCount <= 0) return;

        if(Input.GetTouch(0).position.x < Screen.width / 2)
        {
            Move(-speed);
        } else if (Input.GetTouch(0).position.x > Screen.width / 2)
        {
            Move(speed);
        }
    }
    void Move(float velocity)
    {
        transform.position += Vector3.right * velocity * Time.deltaTime;
    }

    void UpdateScore()
    {
        score = Mathf.RoundToInt(score + (10 * multiplier));
        GameObject.Find("HUD").GetComponent<HudManager>().setScore(score);
    }
    void IncreaseScoreMultiplier()
    {
        multiplier += 0.1f;
    }

    public void DecreaseHealth()
    {
        health--;
        GameObject.Find("HUD").GetComponent<HudManager>().setHealthbar(health);

        if (health <= 0)
        {
            gameOverScreen.GetComponent<GameOver>().ActivateGameOver();
            Destroy(gameObject);     
        }
    }
}