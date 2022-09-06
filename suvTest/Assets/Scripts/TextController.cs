using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public TextAsset textFile;

    private Image backGround;
    private Text textUI;
    private bool isTouch;

    void Start()
    {
        backGround = transform.parent.GetComponent<Image>();
        textUI = GetComponent<Text>();
        textUI.text = "";
        isTouch = false;
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isTouch = true;
        }

        if(textUI.text == "")
        {
            backGround.color = new Color(1, 1, 1, 0);
        }
        else
        {
            backGround.color = new Color(1, 1, 1, 1);
        }
    }

    public IEnumerator WriteText(TextAsset text)
    {
        GameManager.gameManager.isCutScene = true;
        string dialoge = text.text;
        int a;
        string[] message = dialoge.Split('\n');

        for(int i = 0; i < message.Length; i++)
        {
            textUI.text = "";
            isTouch = false;

            for(a = 0; textUI.text != message[i]; a++)
            {
                textUI.text += message[i][a];
                if(isTouch)
                {
                    textUI.text = message[i];
                    isTouch = false;
                }
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitUntil(new System.Func<bool>(nextMessage));
        }

        textUI.text = "";
    }

    bool nextMessage()
    {
        return Input.GetMouseButtonDown(0);
    }
}
