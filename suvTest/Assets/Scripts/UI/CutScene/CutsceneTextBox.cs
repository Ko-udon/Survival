using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CutsceneTextBox : MonoBehaviour
{
   
    public TextMeshProUGUI m_TypingText;
    public float m_Speed = 0.02f;
    public List<string> messageList_0;
    public List<string> messageList_1;
    public List<string> messageList_2;
    public int textCount;
    


    Coroutine col;

    CutsceneBtn clickRightBtn;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Typing(m_TypingText, messageList, m_Speed,0));
        //clickRightBtn = transform.GetChild(0).GetComponent<CutsceneBtn>();
        clickRightBtn = GameObject.Find("Background").GetComponent<CutsceneBtn>();
        col = StartCoroutine(Typing(m_TypingText, messageList_0, m_Speed, textCount));
        textCount++;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Typing(TextMeshProUGUI typingText, List<string> messageList, float speed,int count)
    {
        if(count==messageList.Count)
        {
            //해당 씬의 모든 텍스트를 출력했다면
            clickRightBtn.OnClickRight();

        }
        else
        {
            for (int i = 0; i < messageList[count].Length; i++)
            {
                typingText.text = messageList[count].Substring(0, i + 1);
                yield return new WaitForSeconds(speed);
            }
        }
        
        
    }

    public void OnClick()
    {
        if(col!=null)
        {
            StopCoroutine(col);
        }
        if (clickRightBtn.cnt == 0)
        {

            col = StartCoroutine(Typing(m_TypingText, messageList_0, m_Speed, textCount));
            textCount++;
        }
        else if (clickRightBtn.cnt == 1)
        {
            
            col = StartCoroutine(Typing(m_TypingText, messageList_1, m_Speed, textCount));
            //textCount++;
        }
        else if (clickRightBtn.cnt == 2)
        {
            col = StartCoroutine(Typing(m_TypingText, messageList_2, m_Speed, textCount));
            textCount++;
        }
        else if (clickRightBtn.cnt == 3)
        {
            Debug.Log("세번째 씬");
            //clickRightBtn.OnClickRight();
        }
      



    }
}
