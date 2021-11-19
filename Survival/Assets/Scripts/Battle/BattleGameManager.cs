using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleGameManager : MonoBehaviour
{
    PlayerCharacter player;

    Animator playerAnim;
    EnemyCharacter enemy;
    

    public GameObject enemy_1;
    public GameObject enemy_2;
    public GameObject enemy_3;

    void Awake() 
    {
        player=GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();
        //sprite=player.GetComponent<SpriteRenderer>();
        //player.isBattle=true;
    
        playerAnim=player.GetComponent<Animator>();
        
        

    }
    // Start is called before the first frame update
    void Start()
    {
        //enemy=GameObject.FindWithTag("Enemy").GetComponent<EnemyCharacter>();
        //set player pos and sprite
        player.transform.position=new Vector2(-6,-2);
        player.isReward=false;
        

        switch(player.enemyType)
        {
            case 1:
                Instantiate(enemy_1,new Vector2(2.5f,-1.5f),Quaternion.identity);
                break;
            case 2:
                Instantiate(enemy_2,new Vector2(2.5f,-1.5f),Quaternion.identity);
                break;

        }
        
    }

    void SetPlayerRight()
    {
        playerAnim.SetInteger("hAxisRaw",1);
        playerAnim.SetInteger("vAxisRaw",0);
        playerAnim.SetBool("isChange",false);
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerRight();
        if(player.isRun==true){
            
            player.isBattle=false;
            player.isRun=false;
            SceneManager.LoadScene("Outside");
        }

        if(player.endBattle==true){
            player.endBattle=false;
            //player.isWin=false;
            //player.isWin=false;
            player.isBattle=false;
            Debug.Log("win");
            SceneManager.LoadScene("Outside");
        }

       
    }
}
