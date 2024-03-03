using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrollScript : MonoBehaviour
{
    [SerializeField, Header("視差効果"), Range(0, 1)]
    private float parallaxEffect;

    private GameObject _camera;
    private float length;
    private float startPosX;
    // Start is called before the first frame update
    void Start()
    {

        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosX = transform.position.x;
        Debug.Log(startPosX);
        _camera = Camera.main.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            startPosX += length;
        }
    }
    private void FixedUpdate()
    {
        Parallax();
    }
    private void Parallax()
    {
        float temp = _camera.transform.position.x * (1 - parallaxEffect);
        float dist = _camera.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPosX + dist, transform.position.y, transform.position.z);

    }
}
