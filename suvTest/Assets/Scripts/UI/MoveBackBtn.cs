using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBackBtn : MonoBehaviour
{
    PlayerController player;

    public Transform player_view;
    public float test;
    
    bool btDown = false;

    tutorial_1Manager tutoManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player_view = GameObject.FindGameObjectWithTag("Player_view").GetComponent<Transform>();
        if (SceneManager.GetActiveScene().name == "Tutorial_1")
        {
            tutoManager = GameObject.Find("TutorialManager").GetComponent<tutorial_1Manager>();
        }
        //tutoManager = GameObject.Find("TutorialManager").GetComponent<tutorial_1Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        test = player.transform.localEulerAngles.y;
        /*if (btDown)
        {
            player.transform.Translate(0, 0, Time.deltaTime * -player.speed);
        }*/
    }

    /*public void MoveForward()
    {
        playerMove.transform.Translate(0, 0, Time.deltaTime *player.speed );
        Debug.Log("Btn");
    }*/

    public void BtnUp()
    {
        if (!GameManager.gameManager.isCutScene)
        {
            btDown = false;
            player.isIdle = true;
            player.ChangeDir(0);

            if (tutoManager != null)
            {
                tutoManager.clickCount++;
                if (tutoManager.clickCount == 2)
                {
                    tutoManager.flow_4();
                }
            }
        }

    }
    public void BtnDown()
    {
        if (!GameManager.gameManager.isCutScene)
        {
            btDown = true;
            player_view.transform.rotation = Quaternion.Euler(0, player.transform.localEulerAngles.y + 180, 0);
            player.isIdle = false;
            player.ChangeDir(-1);
        }
    }
}
