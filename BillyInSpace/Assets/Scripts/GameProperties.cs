using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProperties : MonoBehaviour
{
    //public static GameProperties instance;
    [SerializeField] Sprite currentPlayerSprite;
    [SerializeField] int totalMoney;
    void Awake()
    {
        /*if(instance == null)
            instance = GetComponent<GameProperties>();
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);*/
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
