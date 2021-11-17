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
        if(player.isWin==true)
        {
            //win
            int type=player.enemyType;
            for(int j=0;j<enemyCount;j++)
                {
                    if(enemyList[j].tag=="EnemyType_"+type.ToString()){
                            Destroy(enemyList[player.enemyType-1]);
                        }
                }
        }
          
        
    }

    
    void Start()
    {
        
        CheckEnemy();

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
