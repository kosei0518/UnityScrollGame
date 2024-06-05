using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageChanger2 : MonoBehaviour
{
    public GameObject scene_Stage2;
    public GameObject frame;
    private bool stage2ChangeBool;
    public GameObject stageSelectBackGround;

    void Start()
    {
        if (scene_Stage2 != null)
        {
            scene_Stage2.SetActive(false);
        }
        stage2ChangeBool = false;
        if (frame != null)
        {
            frame.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (stage2ChangeBool == true)
            {
                if (stageSelectBackGround != null)
                {
                    stageSelectBackGround.SendMessage("MoveBackGround");
                }
                Invoke(nameof(Stage2), 3.5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (scene_Stage2 != null)
            {
                scene_Stage2.SetActive(true);
            }
            if (frame != null)
            {
                frame.GetComponent<Image>().color = new Color(0.2f, 0.7f, 0.6f, 1.0f);
            }
            stage2ChangeBool = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (scene_Stage2 != null)
            {
                scene_Stage2.SetActive(false);
            }
            if (frame != null)
            {
                frame.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
            }
            stage2ChangeBool = false;
        }
    }

    void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }
}