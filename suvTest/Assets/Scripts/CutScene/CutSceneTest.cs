using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneTest : MonoBehaviour
{
    public GameObject cutSceneCam;

    private PlayerController player;
    private float time;
    private bool start;

    void Start()
    {
        start = false;
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > 5)
        {
            if (!start)
            {
                cutSceneCam.SetActive(true);
                start = true;
                GameManager.gameManager.isCutScene = true;
            }
            else
            {
                if(cutSceneCam.GetComponent<PlayableDirector>().state != PlayState.Playing)
                {
                    cutSceneCam.SetActive(false);
                    GameManager.gameManager.isCutScene = false;
                }
            }
        }
    }

    public void OnPauseClicked(GameObject menu)
    {
        menu.SetActive(true);
    }
}
