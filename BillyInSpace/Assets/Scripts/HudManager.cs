using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] hearts;

    [SerializeField]
    Text score;

    [SerializeField]
    GameObject emptyHeart;

    public void setScore(int playerScore)
    {
        score.text = playerScore.ToString();
    }

    public void setHealthbar(int i)
    {
        if (i < 0) return;
        hearts[i].GetComponent<Image>().sprite = emptyHeart.GetComponent<SpriteRenderer>().sprite;
    }
}
