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
    public int playerScore;
    public GameObject camera;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerInvalid = false;
        gameLimit = 100;
        timeLeft = 10;
        playerHp = 3;
        playerScore = 0;
        Time.timeScale = 1;
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
        playerHp--;
        if (playerInvalid == false)
        {
            if (playerHp > 0)
            {
                camera.SendMessage("CameraShaking");
                StartCoroutine(Restart());
                StartCoroutine("PlayerInvisible");
                PlayerSetLayerFalse();
            }
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
    public IEnumerator Restart()
    {
        //停止する//ダメージ受けてる最中
        Time.timeScale = 0;

        //ダメージ音鳴らすことを書いてる

        //3秒停止する
        yield return new WaitForSecondsRealtime(1.5f);

        //再開する
        Time.timeScale = 1;
    }
    public void DestroyedBigEnemy()
    {
        playerScore += 100;
        Debug.Log(playerScore);
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
