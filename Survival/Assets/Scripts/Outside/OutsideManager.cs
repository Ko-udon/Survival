using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideManager : MonoBehaviour
{
    public static OutsideManager outside;
    public PlayerCharacter player;
    
    public GameObject[] enemyList;
    public GameObject enemy;
    public int enemyCount;
    //List<GameObject> enemyList=new List<GameObject>();
    // Start is called before the first frame update

    void Awake() 
    {
        //  if (outside == null)
        //     outside = this;

        // else if (outside != this)
        //     Destroy(gameObject);

        // DontDestroyOnLoad(gameObject);

        enemyList=new GameObject[enemyCount];

        player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        GetMonsterList();
        
    }

    void CheckEnemy()
    {
        // if(player.killenemy==true)
        // {
        //     for(int j=0;j<enemyCount;j++)
        //         {
        //             if(enemyList[j].tag=="EnemyType_"+player.enemyType.ToString()){
        //                     Destroy(enemyList[j]);
        //                 }
        //         }

        //     player.killenemy=false;
        //     // //win
        //     // int type=player.enemyType;
            
        // }

        // player.killenemy=false;

        for(int i=0;i<player.met_enemy_list.Count;i++)
        {
            for(int j=0;j<enemyCount;j++)
            {
                if(enemyList[j].tag=="EnemyType_"+player.met_enemy_list[i].ToString()&
                (player.enemy_kill_list[i]==1))
                {
                    Destroy(enemyList[j]);
                }

            }
        }
          
        
    }

    
    void Start()
    {
        
        CheckEnemy();
        SetPlayerPos();
        player.isWin=false;

    }

    void GetMonsterList()
    {
        for (int i=0;i<enemyCount;i++){
            enemy=GameObject.FindGameObjectWithTag("EnemyType_"+(i+1).ToString());
            Debug.Log("EnemyType_"+i.ToString());
            enemyList[i]=enemy;
        }
    }

    void SetPlayerPos()
    {
        player.transform.position=player.playerPos;
    }

    void SetPlayerPosHome()
    {
        player.playerPos=new Vector2(-8,-2);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isHome==true){
            player.isHome=false;
            SetPlayerPosHome();
            SceneManager.LoadScene("Home");
        }

        if(player.isBattle==true){
            player.isBattle=false;
            player.SavePlayerPos(2,1);
            SceneManager.LoadScene("Battle");
        }

        
    }
}
