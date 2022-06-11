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
    AudioSource audio;

    public Button btn;

    public GameObject locked;
    public GameObject unlocked;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        characterList = GameObject.Find("CharacterList").GetComponent<CharacterList>();
        btn = this.GetComponent<Button>();
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.characterDic[characterList.characterNameList[0]] == true)
        {
            btn.interactable = true;
            unlocked.SetActive(true);
            locked.SetActive(false);
        }
        else
        {
            btn.interactable = false;
            unlocked.SetActive(false);
            locked.SetActive(true);
        }


    }
    public void OnClick()
    {
        audio.Play();
        gameManager.playerCharacterType = characterList.select();

        Invoke("SceneMove", 2.0f);
    }
    private void SceneMove()
    {
        SceneManager.LoadScene("Main");
    }
    
}
