using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardBtn : MonoBehaviour
{
 
    PlayerController player;
    public Transform player_view;
    bool btDown = false;

    tutorial_1Manager tutoManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        player_view = GameObject.FindGameObjectWithTag("Player_view").GetComponent<Transform>();
        
        //tutoManager = GameObject.Find("TutorialManager").GetComponent<tutorial_1Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (btDown)
        {
            player.transform.Translate(0, 0, Time.deltaTime * player.speed);
            
        }*/
    }

    /*public void MoveForward()
    {
        playerMove.transform.Translate(0, 0, Time.deltaTime *player.speed );
        Debug.Log("Btn");
    }*/

    public void BtnUp()
    {
        if(!GameManager.gameManager.isCutScene)
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
            player_view.transform.rotation = Quaternion.Euler(0, player.transform.localEulerAngles.y, 0);
            //Debug.Log(player.transform.localEulerAngles.y);

            player.isIdle = false;
            player.ChangeDir(1);
        }
    }
}
