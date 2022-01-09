using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;
    void Start()
    {
        life = hearts.Length;
    }
    public void TakeDamage(int d)
    {
        life -= d;
        Destroy(hearts[life].gameObject);
    }
}
