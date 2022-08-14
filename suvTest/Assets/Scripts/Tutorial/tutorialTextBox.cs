using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class tutorialTextBox : MonoBehaviour
{
    public TextMeshProUGUI m_TypingText;
    public float m_Speed = 0.02f;
    public List<string> messageList_0;
    public List<string> messageList_1;
    public List<string> messageList_2;
    public int textCount;
    public List<int> totalTextNumber;


    Coroutine col;

    tutorial_1Manager tutoManager;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(true);
        col = StartCoroutine(Typing_1(m_TypingText, messageList_0, m_Speed, textCount));
        tutoManager= GameObject.Find("TutorialManager").GetComponent<tutorial_1Manager>();



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typing_1(TextMeshProUGUI typingText, List<string> messageList, float speed, int count)
    {
       
        for (int i = 0; i < messageList[count].Length; i++)
        {
            typingText.text = messageList[count].Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(2.0f);
        
        
        
        textCount++;
        if (textCount == 3)
        {
            StopCoroutine(col);
            typingText.text = "";
            tutoManager.flowCount++;
            tutoManager.flow_1();
            textCount = 0;
            
        }
        else
        {
            col = StartCoroutine(Typing_1(m_TypingText, messageList_0, m_Speed, textCount));
            
        }
    }
    IEnumerator Typing_2(TextMeshProUGUI typingText, List<string> messageList, float speed, int count)
    {

        for (int i = 0; i < messageList[count].Length; i++)
        {
            typingText.text = messageList[count].Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(2.0f);
        textCount++;
        if (textCount == 2)
        {
            StopCoroutine(col);
            typingText.text = "";
            tutoManager.flowCount++;
            tutoManager.flow_3();
            textCount = 0;

        }
        else
        {
            col = StartCoroutine(Typing_2(m_TypingText, messageList_1, m_Speed, textCount));

        }
    }
    IEnumerator Typing_3(TextMeshProUGUI typingText, List<string> messageList, float speed, int count)
    {

        for (int i = 0; i < messageList[count].Length; i++)
        {
            typingText.text = messageList[count].Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(2.0f);
        StopCoroutine(col);
        typingText.text = "";
        tutoManager.flowCount++;
        tutoManager.flow_5();
        textCount = 0;
    }



    public void textFlow2()
    {
        col = StartCoroutine(Typing_2(m_TypingText, messageList_1, m_Speed, textCount));
    }
    public void textFlow3()
    {
        col = StartCoroutine(Typing_3(m_TypingText, messageList_2, m_Speed, textCount));
    }


}
