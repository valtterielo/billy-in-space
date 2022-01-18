using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] int score = 0;
    [SerializeField] float multiplier = 1.0f;
    [SerializeField] float speed = 10.0f;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] AudioClip hitSound;
    [SerializeField] Text coinText;
    [SerializeField] int coins;
    [SerializeField] Text shopMoney;
    [SerializeField] Text gameOverMoneyText;
    [SerializeField] TextMeshProUGUI endScoreText;
    [SerializeField] Camera cam;
    GameObject gameProperties;
    GameObject gameManager;
    GameObject adManager;
    Sprite playerSprite;
    bool enemyTouched;


    void Start()
    {
        ES3AutoSaveMgr.Current.Load();
        gameProperties = GameObject.Find("GameProperties");
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<GameManager>().playthroughs++;
        adManager = GameObject.Find("Ads");
        playerSprite = gameProperties.GetComponent<GameProperties>().GetCurrentSprite();
        Debug.Log("Current sprite is " + playerSprite);
        gameObject.GetComponent<SpriteRenderer>().sprite = playerSprite;


        InvokeRepeating("UpdateScore", 0.5f, 1f);
        InvokeRepeating("IncreaseScoreMultiplier", 10f, 10f);
        
    }

    void FixedUpdate()
    {
        //enemyTouched = false;
        if (Input.touchCount <= 0) return;
        StartCoroutine(CheckEnemyHit());
        if (Input.GetTouch(0).position.x < Screen.width / 2 && !enemyTouched)
        {
            Move(-speed);
        } else if (Input.GetTouch(0).position.x > Screen.width / 2 && !enemyTouched)
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
        GameObject.Find("HUD").GetComponent<HudManager>().setScore(score);
    }
    void IncreaseScoreMultiplier()
    {
        multiplier += 0.1f;
    }

    IEnumerator CheckEnemyHit()
    {
        Vector3 touchPosWorld = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
        Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

        RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, cam.transform.forward);
        if(hitInformation.collider != null && hitInformation.transform.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hitted");
            enemyTouched = true;
            hitInformation.transform.gameObject.GetComponent<Enemy>().KillEnemy();
            yield return new WaitForSeconds(0.1f);
            enemyTouched = false;
       
        }
    }

    public void DecreaseHealth()
    {
        Vibration.Init();
        Vibration.VibrateNope();
        AudioSource.PlayClipAtPoint(hitSound, new Vector3(0, 0, -10));
        GetComponent<SpriteFlash>().Flash();
        health--;
        GameObject.Find("HUD").GetComponent<HudManager>().setHealthbar(health);

        if (health <= 0)
        {
            ShowAd();
            gameOverMoneyText.text = $" + {coins}";
            gameOverScreen.GetComponent<GameOver>().ActivateGameOver();
            gameProperties.GetComponent<GameProperties>().IncreaseMoney(coins);
            endScoreText.text = $"Score: {score}";
            gameObject.SetActive(false);
            ES3AutoSaveMgr.Current.Save();
            
        }
    }
    public void AddCoin()
    {
        coins++;
        coinText.text = coins.ToString();
    }

    public void ZeroScoreAndMoney()
    {
        score = 0;
        coins = 0;
    }

    public void RewardDoubleCoins()
    {
        gameProperties.GetComponent<GameProperties>().IncreaseMoney(coins);
        ES3AutoSaveMgr.Current.Save();
    }

    void ShowAd()
    {
        if (gameManager.GetComponent<GameManager>().playthroughs >= 3)
        {
            adManager.GetComponent<InterstitialAd>().ShowAd();
            gameManager.GetComponent<GameManager>().playthroughs = 0;
        }
    }
}
