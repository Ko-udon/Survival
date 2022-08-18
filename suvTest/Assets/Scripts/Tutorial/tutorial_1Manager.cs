using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_1Manager : MonoBehaviour
{
    public int flowCount;
    public GameObject tutoTextBoxGameObj;
    public GameObject horizontalAxisController;
    public GameObject forwardController;
    public GameObject backController;
    public GameObject nextStage;
    
    public int showCount=0;
    public int clickCount;
    tutorialTextBox tutoTextBox;
    Coroutine col;
    // Start is called before the first frame update
    void Start()
    {
        //col = StartCoroutine(showHorizontalController());
        
        tutoTextBoxGameObj.SetActive(true);
        tutoTextBox = GameObject.Find("tutoTextBox").GetComponent<tutorialTextBox>();

    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.9f);
        horizontalAxisController.SetActive(false);
    }
    IEnumerator delay2()
    {
        yield return new WaitForSeconds(0.9f);
        if(showCount<=2)
        {
            backController.SetActive(true);
            forwardController.SetActive(true);
        }
        else
        {
            backController.SetActive(false);
            forwardController.SetActive(false);
        }
        
    }


    //invoke호출이라 메소드를 따로 만들어야함 ㄹㅇ;

    public void showHorizontalController()
    {
        if(showCount>=4)
        {
            CancelInvoke("showHorizontalController");
            showCount = 0;
        }
        horizontalAxisController.SetActive(true);
        StartCoroutine(delay());
        showCount++;
    }
    public void showForwardBackController()
    {
        if (showCount >= 4)
        {
            
            CancelInvoke("showForwardBackController");
            showCount = 0;
        }
        forwardController.SetActive(true);
        backController.SetActive(true);
        StartCoroutine(delay2());
        showCount++;
    }


    // Update is called once per frame
    void Update()
    {

        
    }

    //좌우 시선 변경 버튼 표시
    public void flow_1()
    {
        tutoTextBoxGameObj.SetActive(false);
        InvokeRepeating("showHorizontalController", 0.5f, 1);
    }
    


/*    과학자
- “오, 목이 자연스럽게 돌아가잖아!”

AI
- “놀라시긴 이릅니다.오른 버튼으로 앞뒤로 이동해보시기 바랍니다.”
*/
    public void flow_2()
    {
        clickCount = 0;
        tutoTextBoxGameObj.SetActive(true);
        tutoTextBox.textFlow2();
    }

    //앞뒤 이동 컨트롤러 보이기
    public void flow_3()
    {
        tutoTextBoxGameObj.SetActive(false);
        InvokeRepeating("showForwardBackController", 0.5f, 1);
        
    }

    //앞뒤로 이동 후 
/*    AI
- “잘하셨습니다.이제 당신이 다른 곳으로 이동할 포탈로 이동해 보십시오.”

*/
    public void flow_4()
    {
        tutoTextBoxGameObj.SetActive(true);
        tutoTextBox.textFlow3();
    }

    //포탈 생성 후 이동 시 튜토리얼2로 이동
    public void flow_5()
    {
        tutoTextBoxGameObj.SetActive(false);
        nextStage.SetActive(true);
    }

    public void OnPauseClicked(GameObject menu)
    {
        menu.SetActive(true);
    }
}
