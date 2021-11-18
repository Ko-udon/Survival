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
        if(player.killenemy==true)
        {
            for(int j=0;j<enemyCount;j++)
                {
                    if(enemyList[j].tag=="EnemyType_"+player.enemyType.ToString()){
                            DestroyImmediate(enemyList[j]);
                        }
                }

            player.killenemy=false;
            // //win
            // int type=player.enemyType;
            
        }

        player.killenemy=false;
          
        
    }

    
    void Start()
    {
        
        CheckEnemy();
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

    // Update is called once per frame
    void Update()
    {
        if(player.isHome==true){
            player.isHome=false;
            
            SceneManager.LoadScene("Home");
        }

        if(player.isBattle==true){
            player.isBattle=false;
            SceneManager.LoadScene("Battle");
        }

        
    }
}
