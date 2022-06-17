using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    PlayerController player;
    public GameObject GameOverImg;
    public Image hpBar;
    public Image expBar;
    public Text expText;
    public Text levelText;
    public Text hpText;


    private float playerHp;
    private float playerTotalHp;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerTotalHp = player.hp;
        expText.text = player.exp.ToString() + "/" + player.expList[player.Level].ToString(); 
        levelText.text = "Lv." + player.Level.ToString();


        //debug
        expBar.fillAmount = 0;
        hpBar.fillAmount = 1;
        hpText.text = player.hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHpBar();
        PlayerExpBar();
        if (player.hp <= 0)
        {
            GameOverImg.gameObject.SetActive(true);
        }
        
    }
    public void PlayerHpBar()
    {

        if (player.hp > playerTotalHp)
        {
            playerTotalHp = player.hp;

        }

        playerHp = player.hp;
        hpBar.fillAmount = playerHp / playerTotalHp;


        hpText.text = playerHp.ToString() + "/" + playerTotalHp.ToString();
        
    }
    public void PlayerExpBar()
    {
        expBar.fillAmount = (float)player.exp/ (float)player.expList[player.Level];

    }
    public void ResetPlayerExpBar()
    {
        expBar.fillAmount = 0;
    }
    public void SetExp()
    {
        expText.text = player.exp.ToString() + "/" + player.expList[player.Level].ToString();

    }
    public void SetLevel()
    {
        levelText.text = "Lv." + player.Level.ToString();

    }
}
