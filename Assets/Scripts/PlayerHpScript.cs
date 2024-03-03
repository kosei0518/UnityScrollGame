using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHpScript : MonoBehaviour
{
    public static int playerHp;
    bool onceCallGameOver = false;
    Rigidbody2D rb;
    float transparency = 0.2f;
    SpriteRenderer sr;
    private bool playerInvalid;
    private float gameTimer;
    private int gameLimit;
    private int timeLeft;
    public Text gameTimeText;
    [SerializeField] private GameObject playerLayer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerInvalid = false;
        gameLimit = 300;
        timeLeft = 10;
        playerHp = 3;
    }


    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            gameTimer += Time.deltaTime;
            timeLeft = gameLimit - (int)gameTimer;
            gameTimeText.text = timeLeft.ToString();
        }
        if (timeLeft <= 0)
        {
            StartCoroutine("TimeOver");

        }
    }
    public void DamageToPlayer()
    {
        if (playerInvalid == false)
        {
            StartCoroutine("PlayerInvisible");
            PlayerSetLayerFalse();
            playerHp--;


            if (playerHp <= 0)
            {
                if (onceCallGameOver == false)
                {
                    Debug.Log("gameover");
                    SceneManager.LoadScene("GameOver");
                    onceCallGameOver = true;

                }
            }
        }
    }
    private IEnumerator PlayerInvisible()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, transparency);
        playerInvalid = true;
        yield return new WaitForSeconds(1.5f);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1.0f);
        playerLayer.layer = 9;
        playerInvalid = false;
    }
    private IEnumerator TimeOver()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("GameOver");
    }
    public int GetHp()
    {
        return playerHp;
    }
    void PlayerSetLayerFalse()
    {

        playerLayer.layer = 10;

    }
    public void Recover()
    {
        playerHp++;
    }
}
