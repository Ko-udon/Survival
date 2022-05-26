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
        
        if (num==0)
        {
            if(gameManager.characterDic[characterName]==true)
            {
                
                anim.Play("Running");
                Debug.Log("Start");
            }
            else
            {
                ms.enabled = true;
                //material.color = Color.black;  //¿·±Ë
                
            }
            
        }
        else
        {
            ms.enabled = false;
            //material.color = Color.black;

        }


    }

    // Update is called once per frame
    void Update()
    {


    }

    public void characterRotationLeft()
    {
        if (num == 0)
        {
            num = 1;
            characterList.characterList[num] = this;
            this.transform.localPosition = characterList.listPos[4];
        }
        else
        {
            num--;
            characterList.characterList[num] = this;
            this.transform.localPosition = characterList.listPos[num];

        }

        if (num == 0)
        {
            //material.color = Color.white;
            ms.enabled = true;
            anim.Play("Running");
        }
        else if (num != 0)
        {
            //material.color = Color.black;
            ms.enabled = false;
            anim.Stop("Running");
        }
        //StartCoroutine(ListCharacterMoveLeft());

    }






    public void characterRotationRight()
    {
        if (num == 1)
        {
            num = 0;
            characterList.characterList[num] = this;
            this.transform.localPosition = characterList.listPos[0];
        }
        else
        {
            num++;
            characterList.characterList[num] = this;
            this.transform.localPosition = characterList.listPos[num];

        }

        //
        if (num == 0)
        {
            //material.color = Color.white;
            ms.enabled = true;
            anim.Play("Running");
        }
        else if (num != 0)
        {
            //material.color = Color.black;
            ms.enabled = false;
            anim.Stop("Running");
        }



    }

/*
    IEnumerator ListCharacterMoveLeft()
    {
        if (num == 0)
        {
            transform.position += characterList.listPos[4] * Time.deltaTime;
        }
        else
        {
            transform.position += characterList.listPos[num--] * Time.deltaTime;
        }


        yield return 0;
    }

    IEnumerator ListCharacterMoveRight()
    {



        yield return 0;
    }*/
}
