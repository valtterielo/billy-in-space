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
        ShowAd();
        ES3AutoSaveMgr.Current.Load();
        SceneManager.LoadScene("Main");
    }

    public void Shop()
    {
        ShowAd();
        ES3AutoSaveMgr.Current.Load();
        GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.startScreenActive = true;
        GM.playerActive = false;
        GM.spawnerControllerActive = false;
        SceneManager.LoadScene("Main");
    }

    void ShowAd()
    {
        GameObject adManager = GameObject.Find("Ads");
        GameObject gameProps = GameObject.Find("GameProperties");

        if(gameProps.GetComponent<GameProperties>().playthroughs >= 1)
        {
            adManager.GetComponent<InterstitialAd>().ShowAd();
            gameProps.GetComponent<GameProperties>().playthroughs = 0;
        }
    }
}
