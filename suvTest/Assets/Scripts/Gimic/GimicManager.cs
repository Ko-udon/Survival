using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimicManager : MonoBehaviour
{
    public GameObject clearPortal;

    public GameObject RedBox;
    public GameObject GreenBox;
    public GameObject BlueBox;

    //public string[] answer;
    public string[] answer;
    public string[] playerAnswer;
 


    public int cnt=0;

    // Start is called before the first frame update
    void Start()
    {
     

    }
    public void addType(string type)
    {
        playerAnswer[cnt] = type;
        cnt++;
    }

    public void checkAnswer()
    {
      
        
        if (answer[0]==playerAnswer[0]&answer[1]==playerAnswer[1]&answer[2]==playerAnswer[2])
        {
            
            clearPortal.SetActive(true);
            RedBox.SetActive(false);
            GreenBox.SetActive(false);
            BlueBox.SetActive(false);
        }
        else
        {
            cnt = 0;
            playerAnswer[0] = null;
            playerAnswer[1] = null;
            playerAnswer[2] = null;
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        if (cnt == 3)
        {
            checkAnswer();
        }
        
    }
}
