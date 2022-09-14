using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneTest : MonoBehaviour
{
    public GameObject cutSceneCam;
    public GameObject mainUI;
    public TextController text;

    private PlayerController player;
    private float time;
    private bool start;

    List<GameObject> ableUI;

    void Start()
    {
        start = false;
        player = FindObjectOfType<PlayerController>();

        StartCoroutine(PlayingcutScene());
    }

    // Update is called once per frame
    void Update()
    {
        /*time += Time.deltaTime;

        if(time > 5)
        {
            if (!start)
            {
                cutSceneCam.SetActive(true);
                start = true;
                DisableOther();
                GameManager.gameManager.isCutScene = true;
            }
            else
            {
                if(cutSceneCam.GetComponent<PlayableDirector>().state != PlayState.Playing)
                {
                    cutSceneCam.SetActive(false);
                    EnableOther();
                    GameManager.gameManager.isCutScene = false;
                }
            }
        }*/
    }

    public IEnumerator PlayingcutScene()
    {
        yield return StartCoroutine(text.WriteText(text.textFile_1));

        cutSceneCam.SetActive(true);
        DisableOther();

        while(cutSceneCam.GetComponent<PlayableDirector>().state == PlayState.Playing)
        {
            //Debug.Log(cutSceneCam.GetComponent<PlayableDirector>().state);
            yield return null;
        }

        cutSceneCam.SetActive(false);
        EnableOther();

        yield return StartCoroutine(text.WriteText(text.textFile_2));

        GameManager.gameManager.isCutScene = false;
    }

    public void DisableOther()
    {
        ableUI = new List<GameObject>();
        for (int i = 0; i < mainUI.transform.childCount; i++)
        {
            GameObject ui = mainUI.transform.GetChild(i).gameObject;
            if (ui.activeSelf)
            {
                ableUI.Add(ui);
                ui.SetActive(false);
            }
        }
    }

    public void EnableOther()
    {
        foreach (GameObject ui in ableUI)
        {
            ui.SetActive(true);
        }
        ableUI.Clear();
    }

    public void OnPauseClicked(GameObject menu)
    {
        menu.SetActive(true);
    }
}
