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
        
        if (gameManager.characterDic[characterList.characterNameList[0]] == true)
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
