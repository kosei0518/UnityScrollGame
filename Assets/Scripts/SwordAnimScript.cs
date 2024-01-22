using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimScript : MonoBehaviour
{
    private Animator swordAnim;
    public float swordCoolTime;
    SpriteRenderer swordImage;

    // Start is called before the first frame update
    void Start()
    {
        swordAnim = gameObject.GetComponent<Animator>();
        swordCoolTime = 1.0f;
        swordImage = GetComponent<SpriteRenderer>();
        swordImage.color = new Color(swordImage.color.r, swordImage.color.g, swordImage.color.b, 0.0f);

    }


    // Update is called once per frame
    void Update()
    {
        swordCoolTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (swordCoolTime >= 0.8f)
            {
                StartCoroutine(SwordCoroutine());
                swordCoolTime = 0f;
            }

        }
    }
    private IEnumerator SwordCoroutine()
    {
        swordAnim.SetBool("swordAnimationBool", true);
        yield return new WaitForSeconds(0.7f);
        swordAnim.SetBool("swordAnimationBool", false);
    }
    public void EquipSword()
    {
        swordImage.color = new Color(swordImage.color.r, swordImage.color.g, swordImage.color.b, 1.0f);
    }
    public void RemoveSword()
    {
        swordImage.color = new Color(swordImage.color.r, swordImage.color.g, swordImage.color.b, 0.0f);
    }
}
