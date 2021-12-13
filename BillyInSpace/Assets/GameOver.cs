using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void ActivateGameOver()
    {
        gameObject.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene("Main");
    }
}
