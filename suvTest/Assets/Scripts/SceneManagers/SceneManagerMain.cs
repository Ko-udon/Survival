using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerMain : MonoBehaviour
{
    GameManager gameManager;
    public List<GameObject> characterList;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnPlayer(gameManager.playerCharacterType);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnPlayer(string type)
    {
        if(type=="Earth")
        {
            characterList[0].SetActive(true);
        }
        else if(type=="Fire")
        {
            characterList[1].SetActive(true);
        }
    }
}
