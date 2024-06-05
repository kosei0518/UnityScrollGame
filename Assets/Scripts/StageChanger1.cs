using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageChanger1 : MonoBehaviour
{
    public GameObject scene_Stage1;
    public GameObject frame;
    private bool stage1ChangeBool;
    public GameObject stageSelectBackGround;
    public GameObject Player;

    void Start()
    {
        scene_Stage1.SetActive(false);
        stage1ChangeBool = false;
        frame.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.2f);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (stage1ChangeBool == true)
            {
                //stageSelectBackGround.SendMessage("MoveBackGround");
                Player.SendMessage("FadeOutPlayer");
                Invoke(nameof(Stage1), 3.5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scene_Stage1.SetActive(true);
            frame.GetComponent<Image>().color = new Color(0.2f, 0.7f, 0.6f, 1.0f);
            stage1ChangeBool = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scene_Stage1.SetActive(false);
            frame.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
            stage1ChangeBool = false;
        }
    }
    void Stage1()
    {
        SceneManager.LoadScene("MainScene");
    }
}
