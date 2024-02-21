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
        startPosX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        _camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

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
        if (temp > startPosX + length)
        {
            startPosX += length;
        }
        else if (temp < startPosX - length)
        {
            startPosX -= length;
        }
    }
}
