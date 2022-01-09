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
        ES3AutoSaveMgr.Current.Load();
        SceneManager.LoadScene("Main");
    }

    public void Shop()
    {
        ES3AutoSaveMgr.Current.Load();
        GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.startScreenActive = true;
        GM.playerActive = false;
        GM.spawnerControllerActive = false;
        SceneManager.LoadScene("Main");
    }
}
