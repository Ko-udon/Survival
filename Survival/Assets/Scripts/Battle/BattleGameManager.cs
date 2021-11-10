using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleGameManager : MonoBehaviour
{
    PlayerCharacter player;
    EnemyCharacter enemy;

    void Awake() 
    {
        player=GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();
        enemy=GameObject.FindWithTag("Enemy").GetComponent<EnemyCharacter>();
        player.isBattle=true;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isRun==true){
            SceneManager.LoadScene("Outside");
        }
    }
}
