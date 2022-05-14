using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectBtn : MonoBehaviour
{
    GameManager gameManager;
    CharacterList characterList;
    ListCharacter_state listCharacter_state;

    private Button btn;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        characterList = GameObject.Find("CharacterList").GetComponent<CharacterList>();
        btn = this.GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        listCharacter_state = characterList.characterList[0];
        if(gameManager.characterDic[listCharacter_state.characterName]==true)
        {
            btn.interactable = true;
        }
        else
        {
            btn.interactable = false;
        }


    }
    public void OnClick()
    {
        gameManager.playerCharacterType = characterList.select();
        SceneManager.LoadScene("Main");
    }
    
}
