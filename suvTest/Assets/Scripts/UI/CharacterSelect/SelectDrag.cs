using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectDrag : MonoBehaviour//,IPointerUpHandler,IPointerDownHandler
{
    ListCharacter_state listCharacterState_0;
    ListCharacter_state listCharacterState_1;
    ListCharacter_state listCharacterState_2;
    ListCharacter_state listCharacterState_3;
    ListCharacter_state listCharacterState_4;

    CharacterList characterList;
    GameManager gameManager;

    // Start is called before the first frame update
    /* private Vector2 beginDragPos;
     private Vector2 endDragPos;
     public float dragValue = 250f;*/

    void Start()
    {
        listCharacterState_0 = GameObject.Find("character_0").GetComponent<ListCharacter_state>();
        listCharacterState_1 = GameObject.Find("character_1").GetComponent<ListCharacter_state>();

        characterList = GameObject.Find("CharacterList").GetComponent<CharacterList>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //listCharacterState_2 = GameObject.Find("character_2").GetComponent<ListCharacter_state>();
        //listCharacterState_3 = GameObject.Find("character_3").GetComponent<ListCharacter_state>();
        //listCharacterState_4 = GameObject.Find("character_4").GetComponent<ListCharacter_state>();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //beginDragPos = eventData.position;
        //Debug.Log(beginDragPos);

    }
    public void ClickLeft()
    {
        characterList.rotateLeft();
        //listCharacterState_0.characterRotationLeft();
        //listCharacterState_1.characterRotationLeft();
        //listCharacterState_2.characterRotationLeft();
        //listCharacterState_3.characterRotationLeft();
        //listCharacterState_4.characterRotationLeft();

    }
    public void ClickRight()
    {
        characterList.rotateRight();
        //listCharacterState_0.characterRotationRight();
        //listCharacterState_1.characterRotationRight();
        //listCharacterState_2.characterRotationRight();
        //listCharacterState_3.characterRotationRight();
        //listCharacterState_4.characterRotationRight();
    }

    /*public void OnPointerUp(PointerEventData eventData)
    {
        endDragPos = eventData.position;
        //Debug.Log(endDragPos);
        float minus = Mathf.Abs(endDragPos.x - beginDragPos.x);
        if ((endDragPos.x < beginDragPos.x) & (minus > dragValue))
        {
            //Debug.Log(minus);
            Debug.Log("Left");
            listCharacterState_0.characterRotationLeft();
            listCharacterState_1.characterRotationLeft();
            //listCharacterState_2.characterRotationLeft();
            //listCharacterState_3.characterRotationLeft();
            //listCharacterState_4.characterRotationLeft();
        }
        else if ((endDragPos.x > beginDragPos.x) & (minus > dragValue))
        {
            Debug.Log("Right");
            listCharacterState_0.characterRotationRight();
            listCharacterState_1.characterRotationRight();
            //listCharacterState_2.characterRotationRight();
            //listCharacterState_3.characterRotationRight();
            //listCharacterState_4.characterRotationRight();
            // Debug.Log(minus);
        }
        else
        {

        }
    }*/
    


  
}
