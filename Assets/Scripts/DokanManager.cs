using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DokanManager : MonoBehaviour
{
    public static bool dokan2Bool = false;
    public static bool dokan3Bool = false;
    public static bool dokan4Bool = false;
    public GameObject dokan2;
    public GameObject dokan3;
    public GameObject dokan4;
    public GameObject yajirushi;
    // Start is called before the first frame update
    void Start()
    {
        dokan2.SetActive(false);
        dokan3.SetActive(false);
        dokan4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dokan2Bool == true)
        {
            dokan2.SetActive(true);
            Destroy(yajirushi);
        }
        if (dokan3Bool == true)
        {
            dokan3.SetActive(true);
        }
        if (dokan4Bool == true)
        {
            dokan4.SetActive(true);
        }
    }

}
