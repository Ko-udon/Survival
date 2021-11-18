using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    PlayerCharacter player;
    //EnemyCharacter enemy;

    SpriteRenderer enemySprite;
    //public int player_hp;
    //public int player_mt;
    public int player_air;

    public Text player_mt_text;
    public Text player_hp_text;



    // public Text reward_text;
    // public Image rewardImage;
    public Image Airbar;

    // public Image monsterImage;
    // public Text monsterCountText;

    // public Image bootyImage;
    // public Text bootyCountText;
    // public Text bootyText;

    public Image reward_1;
    public Image reward_2;

    public Text timerTxt;
    public float time = 59f;
    private float selectCountdown;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();
        
        

        selectCountdown = time;


    }

     void Timer()
    {
        if (Mathf.Floor(selectCountdown) <= 0)
        {
            // 
        }
        else
        {
            selectCountdown -= Time.deltaTime;
            timerTxt.text = Mathf.Floor(selectCountdown).ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //enemy=GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        player_hp_text.text = player.Hp.ToString();
        player_mt_text.text = player.Mt.ToString();
        player_air = (int)player.Air;
        Timer();

        Airbar.fillAmount = player.Air / 100;

        
        if(player.isWin==true)
        {
            StartCoroutine("showRewardUI");
            
        }
    }

    IEnumerator showRewardUI()
    {
        yield return new WaitForSeconds(1.0f);
        player.isWin=false;

        if(player.enemyType==1){
            reward_1.gameObject.SetActive(true);
            yield return new WaitForSeconds(2.0f);        
            reward_1.gameObject.SetActive(false);
        }
        else if(player.enemyType==2){
            reward_2.gameObject.SetActive(true);
            yield return new WaitForSeconds(2.0f);        
            reward_2.gameObject.SetActive(false);
        }

        

    }
}
