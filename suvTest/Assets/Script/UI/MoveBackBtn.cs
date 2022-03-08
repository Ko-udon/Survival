using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackBtn : MonoBehaviour
{
    PlayerController player;
    bool btDown = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (btDown)
        {
            player.transform.Translate(0, 0, Time.deltaTime * -player.speed);
        }
    }

    /*public void MoveForward()
    {
        playerMove.transform.Translate(0, 0, Time.deltaTime *player.speed );
        Debug.Log("Btn");
    }*/

    public void BtnUp()
    {
        btDown = false;
    }
    public void BtnDown()
    {
        btDown = true;
    }
}
