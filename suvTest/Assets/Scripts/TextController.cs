using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public TextAsset textFile_1;
    public TextAsset textFile_2;
    public Text name;
    public Text textUI;

    private Image backGround;
    private bool isTouch;

    void Start()
    {
        backGround = transform.parent.GetComponent<Image>();
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
            name.text = "";
            isTouch = false;

            switch(message[i][0])
            {
                case 'A':
                    name.text = "AI";
                    break;

                case 'P':
                    name.text = "°úÇÐÀÚ";
                    break;
            }

            string messageTemp = message[i].Substring(2);

            for(a = 2; textUI.text != messageTemp; a++)
            {
                textUI.text += message[i][a];
                if(isTouch)
                {
                    textUI.text = messageTemp;
                    isTouch = false;
                }
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitUntil(new System.Func<bool>(nextMessage));
        }

        textUI.text = "";
        name.text = "";
    }

    bool nextMessage()
    {
        return Input.GetMouseButtonDown(0);
    }
}
