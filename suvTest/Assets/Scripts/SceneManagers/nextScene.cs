using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public string nextSceneText;
    public GameObject effectNextScene;
    public GameObject clearImg;
    IEnumerator moveToNextScene()
    {
        effectNextScene.SetActive(true);
        StartCoroutine(showClearImg());
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(nextSceneText);
    }
    IEnumerator showClearImg()
    {

        yield return new WaitForSeconds(1.0f);
        clearImg.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.CompareTag("Player"))
        {
            StartCoroutine(moveToNextScene());
        }
    }

}
