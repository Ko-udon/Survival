using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    PlayerController player;
    public Image GameOverImg;
    public Image hpBar;
    public Image expBar;
    public Text expText;
    public Text levelText;

    private float playerHp;
    private float playerStartHp;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerStartHp = player.hp;
        expText.text = player.exp.ToString() + "/" + player.expList[player.Level].ToString(); 
        levelText.text = "Lv." + player.Level.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        //PlayerHpBar();
        //PlayerExpBar();
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
