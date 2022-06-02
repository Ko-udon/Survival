using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCharacter_state : MonoBehaviour
{
    GameManager gameManager;

    CharacterList characterList;
    public Animation anim;

    public int num;
    public int characterType;
    public string characterName;
    public GameObject mesh;
    public SkinnedMeshRenderer ms;
    private Material material;
    
    
    // Start is called before the first frame update
    void Start()
    {

        //anim = gameObject.GetComponent<Animation>();
        //material = GetComponentInChildren<Renderer>().material;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        material = mesh.GetComponent<Renderer>().material;
        ms = mesh.GetComponent<SkinnedMeshRenderer>();
        
        characterList = GameObject.Find("CharacterList").GetComponent<CharacterList>();

        
        if (gameManager.characterDic[characterName] == true)
        {

             anim.Play("Running");
             Debug.Log("Start");
        }
         
            

       


    }
    public void playAnim()
    {
        anim.Play("Running");
    }

    // Update is called once per frame
    void Update()
    {
        

    }



}
