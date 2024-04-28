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
    public void Stage1_3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void Stage1_4()
    {
        SceneManager.LoadScene("Stage4");
    }
}
