using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField]
    private GameObject arrowObj;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Vector3 playerPos;
    [SerializeField]
    private Quaternion playerRotation;
    private Vector3 addPos;
    public PlayerController playerController;
    private float shootInterval;
    [SerializeField]
    private bool equipBowBool;
    private SpriteRenderer bowImage;
    public GameObject bowObj;
    public SpriteRenderer arrowImage;
    // Start is called before the first frame update
    void Start()
    {
        shootInterval = 0.0f;
        equipBowBool = false;
        bowImage = bowObj.GetComponent<SpriteRenderer>();
        bowImage.color = new Color(bowImage.color.r, bowImage.color.g, bowImage.color.b, 0.0f);
        arrowImage = GetComponent<SpriteRenderer>();
        arrowImage.color = new Color(arrowImage.color.r, arrowImage.color.g, arrowImage.color.b, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (equipBowBool == true)
        {
            shootInterval += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (shootInterval >= 1.0f)
                {
                    Shoot();
                    shootInterval = 0.0f;
                }

            }
        }
    }
    public void EquipBow()
    {
        equipBowBool = true;
        bowImage.color = new Color(bowImage.color.r, bowImage.color.g, bowImage.color.b, 1.0f);
        arrowImage.color = new Color(arrowImage.color.r, arrowImage.color.g, arrowImage.color.b, 1.0f);
    }
    public void RemoveBow()
    {
        equipBowBool = false;
        bowImage.color = new Color(bowImage.color.r, bowImage.color.g, bowImage.color.b, 0.0f);
        arrowImage.color = new Color(arrowImage.color.r, arrowImage.color.g, arrowImage.color.b, 0.0f);
    }
    void Shoot()
    {
        playerPos = player.transform.position;
        //player.transform.rotation;
        if (playerController.playerRightDirection == true)
        {
            playerPos.x += 1f;
            playerRotation = Quaternion.Euler(0, 0, -45);
        }
        else if (playerController.playerRightDirection == false)
        {
            playerPos.x += -1;
            playerRotation = Quaternion.Euler(0, 180, -45);
        }

        Instantiate(arrowObj, playerPos, playerRotation);


    }
    public void EquipSword()
    {

    }
}
