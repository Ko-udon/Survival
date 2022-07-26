using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CutsceneBtn : MonoBehaviour
{

    public string btnType;
    public string nextScene;
    public List<Image> sceneList;
    public int cnt=0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLeft()
    {
       if(cnt==0)
        {
            return;
        }
        else
        {
            cnt--;
            sceneList[cnt].gameObject.SetActive(true);

            sceneList[cnt + 1].gameObject.SetActive(false);
        }
    }
    public void OnClickRight()
    {
        
        if(cnt==sceneList.Count-1)
        {
            moveNextScene();
        }
        else
        {
            cnt++;
            sceneList[cnt].gameObject.SetActive(true);

            sceneList[cnt - 1].gameObject.SetActive(false);

        }
    }

  

    public void moveNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

}
