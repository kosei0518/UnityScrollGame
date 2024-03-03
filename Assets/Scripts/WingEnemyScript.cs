using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingEnemyScript : MonoBehaviour
{
    private float switchingTime;
    private float delayTimer;
    private bool isMovingUp;
    public GameObject player;
    public GameObject wingEnemyDeathEffect;

    // Start is called before the first frame update
    void Start()
    {
        isMovingUp = true;
        delayTimer = 1.0f;
        switchingTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
            return; // 1秒の待機中はここで処理終了
        }
        switchingTime += Time.deltaTime;
        if (switchingTime >= 3.0f)
        {
            if (isMovingUp == true)
            {
                isMovingUp = false;
                switchingTime = 0.0f;
                delayTimer = 1.0f;
            }
            else if (isMovingUp == false)
            {
                isMovingUp = true;
                switchingTime = 0.0f;
                delayTimer = 1.0f;
            }
        }
        if (isMovingUp == true)
        {
            this.transform.position += new Vector3(0, 1.2f * Time.deltaTime, 0);

        }
        if (isMovingUp == false)
        {
            this.transform.position += new Vector3(0, -1.2f * Time.deltaTime, 0);

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.SendMessage("DamageToPlayer");
        }
        if (other.gameObject.CompareTag("Arrow"))
        {
            DamageToEnemy();
        }
    }
    public void DamageToEnemy()
    {
        Instantiate(wingEnemyDeathEffect, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
