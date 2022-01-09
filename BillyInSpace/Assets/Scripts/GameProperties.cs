using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProperties : MonoBehaviour
{
    //public static GameProperties instance;
    [SerializeField] Sprite currentPlayerSprite;
    [SerializeField] int totalMoney;
    [SerializeField] GameObject astronaut;
    [SerializeField] GameObject spawnerController;
    [SerializeField] GameObject startScreen;
    [SerializeField] Text shopMoney;
    void Start()
    {
        ES3AutoSaveMgr.Current.Load();
        GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        astronaut.SetActive(GM.playerActive);
        spawnerController.SetActive(GM.spawnerControllerActive);
        startScreen.SetActive(GM.startScreenActive);
        shopMoney.text = totalMoney.ToString();

    }
    public int GetTotalMoney() { return totalMoney; }
    public void DecreaseMoney(int amount)
    {
        totalMoney -= amount;
        ES3AutoSaveMgr.Current.Save();
    }
    public void IncreaseMoney(int amount)
    {
        totalMoney += amount;
        ES3AutoSaveMgr.Current.Save();
    }
    public void SetPlayerSprite(Sprite sprite)
    {
        currentPlayerSprite = sprite;
        ES3AutoSaveMgr.Current.Save();
    }
    public Sprite GetCurrentSprite() { return currentPlayerSprite; }
}
