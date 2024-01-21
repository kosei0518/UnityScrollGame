using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHpScript : MonoBehaviour
{
    public static int playerHp = 5;
    bool once = false;
    Rigidbody2D rb;
    float transparency = 0.2f;
    SpriteRenderer sr;
    private bool playerInvalid;
    private float gameTimer;
    private int gameLimit;
    private int timeLeft;
    public Text gameTimeText;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerInvalid = false;
        gameLimit = 300;
        timeLeft = 10;
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
        if(timeLeft <= 0)
        {
            StartCoroutine("TimeOver");
            
        }
    }
    public void DamageToPlayer()
    {
        if (playerInvalid == false)
        {
            StartCoroutine("PlayerInvisible");
            
            playerHp--;
            

            if (playerHp <= 0)
            {
                if (once == false)
                {
                    Debug.Log("gameover");
                    SceneManager.LoadScene("GameOver");
                    once = true;

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
    
}
