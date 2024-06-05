using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YajirushiScript : MonoBehaviour
{
    private float switchingTime;
    private float delayTimer;
    private bool isMovingUp;
    // Start is called before the first frame update
    void Start()
    {
        isMovingUp = true;
        delayTimer = 0.1f;
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
        if (switchingTime >= 0.5f)
        {
            if (isMovingUp == true)
            {
                isMovingUp = false;
                switchingTime = 0.0f;
                delayTimer = 0.1f;
            }
            else if (isMovingUp == false)
            {
                isMovingUp = true;
                switchingTime = 0.0f;
                delayTimer = 0.1f;
            }
        }
        if (isMovingUp == true)
        {
            this.transform.position += new Vector3(0, 0.6f * Time.deltaTime, 0);

        }
        if (isMovingUp == false)
        {
            this.transform.position += new Vector3(0, -0.6f * Time.deltaTime, 0);

        }
    }
}
