using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    // Start is called before the first frame update
    public List<ListCharacter_state> characterList;
    public List<Vector3> listPos;


    void Start()
    {
        for (int i = 0; i < characterList.Count; i++)
        {
            listPos[i] = characterList[i].transform.localPosition;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int select()
    {
        return characterList[0].characterType;
    }
}
