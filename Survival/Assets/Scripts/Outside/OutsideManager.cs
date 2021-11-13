using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideManager : MonoBehaviour
{
    public PlayerCharacter player;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        

    }

    // Update is called once per frame
    void Update()
    {
        // if(player.isHome==true){
        //     player.isHome=false;
            
        //     SceneManager.LoadScene("Home");
        // }
    }
}
