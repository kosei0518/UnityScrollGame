using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject playerObj;
    private CharacterController characterController;
    private float playerSpeed;
    public bool playerJumpBool = true;

    private Animator anim;

    private Rigidbody2D rbody2D;
    public float jumpForce = 18f;
    private float moveSpeed = 5.5f;
    public bool equipSwordBool;
    public bool swordBool;
    private bool rightWall;
    private bool leftWall;

    public GameObject swordAttackRange;
    private bool rightStopper;
    private bool leftStopper;
    private bool rightWalk;
    private bool leftWalk;

    public bool playerRightDirection = true;
    private float jumpLimiter = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rbody2D = GetComponent<Rigidbody2D>();
        characterController = GetComponent<CharacterController>();
        swordBool = false;
        rightWall = false;
        leftWall = false;
        rightStopper = false;
        leftStopper = false;
        rightWalk = false;
        leftWalk = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rightStopper);


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerObj.transform.rotation = Quaternion.Euler(0, 180, 0);



            playerRightDirection = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerObj.transform.rotation = Quaternion.Euler(0, 0, 0);


            playerRightDirection = true;
        }

        Vector3 yPos = playerObj.transform.position;
        if (yPos.y < -3)
        {
            SceneManager.LoadScene("GameOver");
        }
        Vector2 moveVector = Vector2.zero;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVector = Vector2.right * moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVector = Vector2.left * moveSpeed;
        }
        rbody2D.velocity = new Vector2(moveVector.x, rbody2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerJumpBool == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpForce, 0);

                playerJumpBool = false;
                jumpLimiter = 0.0f;


                anim.SetBool("jumpAnimBool", true);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor") || collision.gameObject.CompareTag("Object"))
        {
            anim.SetBool("jumpAnimBool", false);

            playerJumpBool = true;


        }
    }
    private void OnCollisionStay2D(Collision2D stay)
    {
        if (stay.gameObject.CompareTag("floor") || stay.gameObject.CompareTag("Object"))
        {
            jumpLimiter += Time.deltaTime;
            if (jumpLimiter >= 0.1f)
            {
                anim.SetBool("jumpAnimBool", false);


                playerJumpBool = true;
            }




        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("floor") || other.gameObject.CompareTag("Object"))
        {
            playerJumpBool = false;

        }
    }
    void Move(Vector2 direction)
    {
        Vector2 force = direction * moveSpeed;
        rbody2D.velocity = new Vector2(force.x, rbody2D.velocity.y);
    }
}
