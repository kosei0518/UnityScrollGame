using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public GameObject enemyObj;
    public bool moveRightDirection;
    public float enemyMoveCoolTime;
    public GameObject playerController;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        moveRightDirection = false;
        enemyMoveCoolTime = 0.0f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMoveCoolTime += Time.deltaTime;
        if (moveRightDirection == false)
        {
            enemyObj.transform.position += new Vector3(-1.5f, 0, 0) * Time.deltaTime;
            enemyObj.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (moveRightDirection == true)
        {
            enemyObj.transform.position += new Vector3(1.5f, 0, 0) * Time.deltaTime;
            enemyObj.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        Vector3 enemyyPos = enemyObj.transform.position;
        if (enemyyPos.y < -3)
        {
            Destroy(enemyObj);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            playerController.SendMessage("DamageToPlayer");
            //rb.AddForce(new Vector2(2f, 6), ForceMode2D.Impulse);
            //Destroy(this.gameObject);
            Debug.Log("ダメージを受けた");

        }
        if (collision.gameObject.CompareTag("Object") || collision.gameObject.CompareTag("Player")||collision.gameObject.CompareTag("Enemy"))
        {
            
            if (enemyMoveCoolTime >= 0.8f)
            {
                if (moveRightDirection == false)
                {
                    moveRightDirection = true;
                    rb.AddForce(new Vector2(2f, 6), ForceMode2D.Impulse);
                    enemyMoveCoolTime = 0.0f;
                }
                
            }
            if (enemyMoveCoolTime >= 0.8f)
            {
                if (moveRightDirection == true)
                {
                    moveRightDirection = false;
                    rb.AddForce(new Vector2(-2f, 6), ForceMode2D.Impulse);
                    enemyMoveCoolTime = 0.0f;
                }
            }
        }

        if (collision.gameObject.CompareTag("Arrow"))
        {
            DamageToEnemy();
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            if (enemyMoveCoolTime >= 0.8f)
            {
                if (moveRightDirection == false)
                {
                    moveRightDirection = true;
                    rb.AddForce(new Vector2(2f, 6), ForceMode2D.Impulse);
                    enemyMoveCoolTime = 0.0f;
                }

            }
            if (enemyMoveCoolTime >= 0.8f)
            {
                if (moveRightDirection == true)
                {
                    moveRightDirection = false;
                    rb.AddForce(new Vector2(2f, 6), ForceMode2D.Impulse);
                    enemyMoveCoolTime = 0.0f;
                }
            }
        }
    }
    public void DamageToEnemy()
    {
        Destroy(this.gameObject);
    }
       
        
    
}
