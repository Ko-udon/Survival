using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleGameManager : MonoBehaviour
{
    PlayerCharacter player;
    EnemyCharacter enemy;

    public GameObject enemy_1;
    public GameObject enemy_2;
    public GameObject enemy_3;

    void Awake() 
    {
        player=GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();
        
        player.isBattle=true;

        
        

    }
    // Start is called before the first frame update
    void Start()
    {
        //enemy=GameObject.FindWithTag("Enemy").GetComponent<EnemyCharacter>();
        player.transform.position=new Vector2(-6,-2);
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

    // Update is called once per frame
    void Update()
    {
        if(player.isRun==true){
            
            player.isBattle=false;
            player.isRun=false;
            SceneManager.LoadScene("Outside");
        }

        if(player.endBattle==true){
            player.endBattle=false;
            player.isWin=false;
            player.isBattle=false;
            Debug.Log("win");
            SceneManager.LoadScene("Outside");
        }
    }
}
