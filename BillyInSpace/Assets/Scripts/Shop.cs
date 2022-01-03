using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    GameObject playerSprite;
    [SerializeField]
    GameObject price;
    [SerializeField]
    GameObject equipBtn;
    [SerializeField]
    Text shopMoney;

    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void Buy()
    {
        if (gameManager.GetComponent<GameProperties>().GetTotalMoney() >= int.Parse(price.GetComponent<Text>().text))
        {
            BuyItem();
        }
    }

    public void Equip()
    {
        gameManager.GetComponent<GameProperties>().SetPlayerSprite(playerSprite.GetComponent<Image>().sprite);
    }

    void BuyItem()
    {
        gameManager.GetComponent<GameProperties>().DecreaseMoney(int.Parse(price.GetComponent<Text>().text));
        price.GetComponent<Text>().text = "Owned";
        price.GetComponent<Text>().fontSize = 55;
        price.GetComponent<Text>().color = Color.green;
        equipBtn.SetActive(true);
        Text shopMoney = GameObject.Find("TotalMoneyText").GetComponent<Text>();
        shopMoney.text = gameManager.GetComponent<GameProperties>().GetTotalMoney().ToString();
        ES3AutoSaveMgr.Current.Save();
    }
}
