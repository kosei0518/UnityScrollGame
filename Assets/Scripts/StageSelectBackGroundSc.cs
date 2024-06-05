using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectBackGroundSc : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("BackGroundBool", false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveBackGround()
    {
        anim.SetBool("BackGroundBool", true);
    }
}
