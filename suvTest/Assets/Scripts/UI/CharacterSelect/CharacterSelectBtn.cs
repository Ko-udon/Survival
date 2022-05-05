using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectBtn : MonoBehaviour
{
    GameManager gameManager;
    CharacterList characterList;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        characterList = GameObject.Find("CharacterList").GetComponent<CharacterList>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        gameManager.playerCharacterType = characterList.select();
        SceneManager.LoadScene("Main");
    }
}
