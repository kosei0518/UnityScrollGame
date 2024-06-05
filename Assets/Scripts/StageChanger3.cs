using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageChanger3 : MonoBehaviour
{
    public GameObject scene_Stage3;
    public GameObject frame;
    private bool stage3ChangeBool;
    public GameObject stageSelectBackGround;

    void Start()
    {
        scene_Stage3.SetActive(false);
        stage3ChangeBool = false;
        frame.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (stage3ChangeBool == true)
            {
                stageSelectBackGround.SendMessage("MoveBackGround");
                Invoke(nameof(Stage3), 3.5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scene_Stage3.SetActive(true);
            frame.GetComponent<Image>().color = new Color(0.2f, 0.7f, 0.6f, 1.0f);
            stage3ChangeBool = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scene_Stage3.SetActive(false);
            frame.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
            stage3ChangeBool = false;
        }
    }
    void Stage3()
    {
        SceneManager.LoadScene("Stage3");
    }
}
