using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booty : MonoBehaviour
{
    public string item;
    public int exp;

    public PlayerCharacter player;
    public EnemyCharacter enemy;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        //enemy=GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyCharacter>();
        //item=enemy.booty_item;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player"){
            player.booty_item=item;
            player.exp+=exp;
            gameObject.SetActive(false);
        }
    }
}
