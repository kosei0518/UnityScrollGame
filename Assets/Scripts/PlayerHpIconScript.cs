using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpIconScript : MonoBehaviour
{
    [SerializeField,Header("hpアイコン")]
    private GameObject playerIcon;
    private PlayerHpScript player;
    private int beforeHp;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHpScript>();
        beforeHp = player.GetHp();
        CreateHpIcon();
    }

    private void CreateHpIcon()
    {
        for (int i = 0; i < player.GetHp(); i++)
        {
            GameObject playerHpObj = Instantiate(playerIcon);
            playerHpObj.transform.parent = transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ShowHpIcon();
    }

    private void ShowHpIcon()
    {
        if (beforeHp == player.GetHp()) return;
        Image[] icons = transform.GetComponentsInChildren<Image>();
        for(int i = 0; i < icons.Length; i++)
        {
            icons[i].gameObject.SetActive(i < player.GetHp());
        }
        beforeHp = player.GetHp();

        
    }
}
