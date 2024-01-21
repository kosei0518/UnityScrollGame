using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordIconScript : MonoBehaviour
{
    public GameObject swordTile;
    public GameObject attackRange;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            swordTile.SendMessage("EquipSword");
            attackRange.SendMessage("EquipSword");
            
            //Debug.Log("剣をゲット");
            Destroy(this.gameObject);
        }
    }
}
