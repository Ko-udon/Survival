using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }

    // Start is called before the first frame update
    public List<GameObject> characterList;
    public List<string> characterNameList;
    
    public BgmType[] BgmList;

    AudioSource audio;

    //public Dictionary<GameObject, string> characterList2;
    public List<Vector3> listPos;
    


    void Start()
    {
        audio = this.GetComponent<AudioSource>();

        for(int i=0;i<characterList.Count;i++)
        {
            if(i!=0)
            {
                characterList[i].SetActive(false);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public string select()
    {
        if(characterNameList[0]=="Earth")
        {
            audio.clip = BgmList[0].audio;
        }
        else if(characterNameList[0]=="Fire")
        {
            audio.clip = BgmList[1].audio;
        }

        audio.Play();
        
        return characterNameList[0];
        //return characterList[0].characterType;
    }

    public void SetFirstCharacter()
    {
        characterList[0].gameObject.SetActive(true);
        
        ListCharacter_state anim = characterList[0].GetComponent<ListCharacter_state>();
        anim.playAnim();
        
    }

    public void rotateLeft()
    {

        characterList[0].SetActive(false);
        GameObject tmp = characterList[0];
        string tmp_s = characterNameList[0];
        
        for (int i = 0; i < characterList.Count; i++)
        {
            if (i == characterList.Count - 1)
            {
                characterList[i] = tmp;
                characterNameList[i] = tmp_s;
            }
            else
            {
                characterList[i] = characterList[i + 1];
                characterNameList[i] = characterNameList[i+1];
            }


        }
        
        SetFirstCharacter();
    }
    public void rotateRight()
    {
        characterList[0].SetActive(false);
        GameObject tmp = characterList[characterList.Count - 1];
        string tmp_s = characterNameList[characterNameList.Count-1];
        for (int i = characterList.Count - 1; i > -1; i--)
        {
            if (i == 0)
            {
                characterList[i] = tmp;
                characterNameList[i] = tmp_s;
            }
            else
            {
                characterList[i] = characterList[i - 1];
                characterNameList[i] = characterNameList[i - 1];
            }


        }
        
        SetFirstCharacter();
    }
}
