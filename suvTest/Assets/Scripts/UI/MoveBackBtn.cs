using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackBtn : MonoBehaviour
{
    PlayerController player;

    public Transform player_pos;
    public float test;
    
    bool btDown = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        test = player.transform.localEulerAngles.y;
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
        player_pos.transform.rotation = Quaternion.Euler(0, player.transform.localEulerAngles.y+180, 0);
    }
}
