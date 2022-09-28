using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneTest : MonoBehaviour
{
    public GameObject cutSceneCam;
    public GameObject mainUI;
    public GameObject stageClear;
    public TextController text;
    public List<GameObject> characterList;

    private PlayerController player;
    private float time;
    private bool start;

    List<GameObject> ableUI;

    void Start()
    {
        start = false;
        player = FindObjectOfType<PlayerController>();
        spawnPlayer(GameManager.gameManager.playerCharacterType);

        StartCoroutine(PlayingcutScene());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemys.Length == 0)
        {
            stageClear.SetActive(true);
        }
        else
        {
            stageClear.SetActive(false);
        }
    }

    void spawnPlayer(string type)
    {
        if (type == "Earth")
        {
            characterList[0].SetActive(true);
        }
        else if (type == "Fire")
        {
            characterList[1].SetActive(true);
        }
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
