using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageChanger : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {


        //stage2_btn.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Stage1_1()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Stage1_2()
    {
        SceneManager.LoadScene("Stage2");
    }

}
