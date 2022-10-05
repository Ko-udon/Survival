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

    private bool isTouch;

    Coroutine col;

    tutorial_1Manager tutoManager;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(true);
        tutoManager = GameObject.Find("TutorialManager").GetComponent<tutorial_1Manager>();
        col = StartCoroutine(Typing_1(m_TypingText, messageList_0, m_Speed, textCount));

        isTouch = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
        }
    }

    IEnumerator Typing_1(TextMeshProUGUI typingText, List<string> messageList, float speed, int count)
    {
        tutoManager.textPrint = true;

        for (int i = 0; typingText.text != messageList[count]; i++)
        {
            typingText.text = messageList[count].Substring(0, i + 1);
            if (isTouch)
            {
                typingText.text = messageList[count];
                isTouch = false;
            }
            if(messageList[count][i] == ' ')
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(speed);
            }
        }
        yield return new WaitUntil(new System.Func<bool>(nextMessage));

        textCount++;
        isTouch = false;

        if (textCount == 3)
        {
            StopCoroutine(col);
            typingText.text = "";
            tutoManager.flowCount++;
            tutoManager.flow_1();
            textCount = 0;
            tutoManager.textPrint = false;
        }
        else
        {
            col = StartCoroutine(Typing_1(m_TypingText, messageList_0, m_Speed, textCount));
        }
    }
    IEnumerator Typing_2(TextMeshProUGUI typingText, List<string> messageList, float speed, int count)
    {
        tutoManager.textPrint = true;

        for (int i = 0; typingText.text != messageList[count]; i++)
        {
            typingText.text = messageList[count].Substring(0, i + 1);
            if (isTouch)
            {
                typingText.text = messageList[count];
                isTouch = false;
            }
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitUntil(new System.Func<bool>(nextMessage));

        textCount++;
        isTouch = false;

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
        tutoManager.textPrint = true;
        for (int i = 0; typingText.text != messageList[count]; i++)
        {
            typingText.text = messageList[count].Substring(0, i + 1);
            if (isTouch)
            {
                typingText.text = messageList[count];
                isTouch = false;
            }
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitUntil(new System.Func<bool>(nextMessage));

        isTouch = false;
        StopCoroutine(col);
        typingText.text = "";
        tutoManager.flowCount++;
        tutoManager.flow_5();
        textCount = 0;
        tutoManager.textPrint = false;
    }



    public void textFlow2()
    {
        col = StartCoroutine(Typing_2(m_TypingText, messageList_1, m_Speed, textCount));
    }
    public void textFlow3()
    {
        col = StartCoroutine(Typing_3(m_TypingText, messageList_2, m_Speed, textCount));
    }

    bool nextMessage()
    {
        return Input.GetMouseButtonDown(0);
    }
}
