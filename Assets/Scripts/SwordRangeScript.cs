using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwordRangeScript : MonoBehaviour
{
    public bool swordWithinRange;
    private Collider2D enemy;
    public static float swordAttackCoolTime;
    private float swordCoolTime;
    private bool equipSwordBool;

    // Start is called before the first frame update
    void Start()
    {
        swordWithinRange = false;
        swordCoolTime = 1f;
        equipSwordBool = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (equipSwordBool == true)
        {
            swordCoolTime += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (swordCoolTime >= 0.8f)
                {
                    SwordAttack(enemy);
                    swordCoolTime = 0.0f;
                }

            }
        }

    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            swordWithinRange = true;
            enemy = other;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            swordWithinRange = false;
        }
    }

    private void SwordAttack(Collider2D other)
    {
        Debug.Log("攻撃");

        if (swordWithinRange == true)
        {
            Debug.Log("敵がいた");
            other.SendMessage("DamageToEnemy");
            //swordWithinRange = false;
        }
    }
    public void EquipSword()
    {
        equipSwordBool = true;
    }
    public void RemoveSword()
    {
        equipSwordBool = false;
    }
}
