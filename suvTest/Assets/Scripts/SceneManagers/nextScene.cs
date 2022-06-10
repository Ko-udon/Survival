using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public string nextSceneText;
    public GameObject effectNextScene;
    IEnumerator moveToNextScene()
    {
        effectNextScene.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(nextSceneText);
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.CompareTag("Player"))
        {
            StartCoroutine(moveToNextScene());
        }
    }

}
