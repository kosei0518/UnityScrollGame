using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BushScript : MonoBehaviour
{
    float transparency = 0.4f;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerView"))
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, transparency);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerView"))
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1.0f);
        }
    }
}
