using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyController : MonoBehaviour
{
    public GameObject bigEnemy;
    //private Rigidbody2D rbody2D;
    private float bigEnemyJumpForce;
    private float bigEnemyActionTimer;
    private float bigEnemyMoveForce;
    private Animator bigEnemyAnim;
    private bool bigEnemyDirection;
    public GameObject bigEnemyToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //rbody2D = GetComponent<Rigidbody2D>();
        bigEnemyAnim = GetComponent<Animator>();
        bigEnemyJumpForce = 15f;
        bigEnemyActionTimer = 0f;
        bigEnemyMoveForce = -5f;
        bigEnemyDirection = false;
    }

    // Update is called once per frame
    void Update()
    {
        bigEnemyActionTimer += Time.deltaTime;
        if (bigEnemyActionTimer >= 3f)
        { 
            StartCoroutine("BigEnemyCoroutine");
            bigEnemyActionTimer = 0f;
        }
    }
    private IEnumerator BigEnemyCoroutine()
    {
        bigEnemyAnim.SetBool("bigEnemyActionBool", true);
        yield return new WaitForSeconds(2.0f);
        GetComponent<Rigidbody2D>().velocity = new Vector3(bigEnemyMoveForce, bigEnemyJumpForce, 0);
        
        //this.rbody2D.AddForce(transform.up * bigEnemyJumpForce, ForceMode2D.Impulse);     
        //this.rbody2D.AddForce(transform.right * bigEnemyMoveForce, ForceMode2D.Impulse);      
        bigEnemyAnim.SetBool("bigEnemyActionBool", false);        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            if (bigEnemyDirection == false)
            {
                bigEnemyDirection = true;
                bigEnemyMoveForce = 5f;
                bigEnemy.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if(bigEnemyDirection == true)
            {
                bigEnemyDirection = false;
                bigEnemyMoveForce = -5f;
                bigEnemy.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            bigEnemyToPlayer.SendMessage("DamageToPlayer");
            
        }
        if (collision.gameObject.CompareTag("Arrow"))
        {
            DamageToEnemy();
        }
    }
    public void DamageToEnemy()
    {
        Destroy(this.gameObject);
    }
}