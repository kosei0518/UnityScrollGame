using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowIconScrpt : MonoBehaviour
{
    public ArrowScript arrowScript;
    public SwordRangeScript swordRangeScript;
    public SwordAnimScript swordAnimScript;
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
            arrowScript.SendMessage("EquipBow");
            swordRangeScript.SendMessage("RemoveSword");
            swordAnimScript.SendMessage("RemoveSword");
            Destroy(this.gameObject);

        }

    }

}
