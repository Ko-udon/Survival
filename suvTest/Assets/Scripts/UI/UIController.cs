using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    PlayerController player;
    public Image GameOverImg;
    public Image hpBar;
    private float playerHp;
    private float playerStartHp;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerStartHp = player.hp;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHpBar();
        if (player.hp < 0)
        {
            GameOverImg.gameObject.SetActive(true);
        }
        
    }
    public void PlayerHpBar()
    {
        playerHp = player.hp;
        hpBar.fillAmount = playerHp / playerStartHp;
        
    }
}
