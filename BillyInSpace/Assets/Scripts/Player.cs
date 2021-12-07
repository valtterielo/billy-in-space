using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int health = 3;

    [SerializeField]
    float score = 0f;

    [SerializeField]
    float multiplier = 1.0f;

    [SerializeField]
    float speed = 5.0f;

    void Start()
    {
        //Pisteiden kasvattaminen alkaa 0.5 sekuntia pelin käynnistymisen
        //jälkeen ja päivittyy sekuntin välein
        InvokeRepeating("UpdateScore", 0.5f, 1f);
        //Pistelukeman kerroin kasvaa 15 sekuntin välein
        InvokeRepeating("IncreaseScoreMultiplier", 15f, 15f);
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
    }
    void IncreaseScoreMultiplier()
    {
        multiplier += 0.1f;
    }

    public void DecreaseHealth()
    {
        health--;
    }
}
