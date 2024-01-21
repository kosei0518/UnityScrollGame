using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPrefabScript : MonoBehaviour
{
    private float arrowDeleteTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arrowDeleteTime += Time.deltaTime;
        transform.Translate(8.5f * Time.deltaTime, 8.5f * Time.deltaTime, 0f );


        if (arrowDeleteTime >= 0.8f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor") || collision.gameObject.CompareTag("Object")|| (collision.gameObject.CompareTag("Enemy")))
        {
            Destroy(this.gameObject);


        }

    }
}
