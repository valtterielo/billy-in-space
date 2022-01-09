using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField] GameObject astronaut;
    [SerializeField] GameObject spawnerController;
    [SerializeField] GameObject shopWindow;
    public void PlayGame()
    {
        GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.startScreenActive = false;
        GM.playerActive = true;
        GM.spawnerControllerActive = true;

        SceneManager.LoadScene("Main");
    }

    public void Customize()
    {
        ES3AutoSaveMgr.Current.Load();
        shopWindow.SetActive(true);
    }

    public void CustomizeBackBtn()
    {
        shopWindow.SetActive(false);
    }
}
