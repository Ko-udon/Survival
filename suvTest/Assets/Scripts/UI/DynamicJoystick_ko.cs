using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicJoystick_ko : MonoBehaviour
{
    public Transform player;
    PlayerController playerController;
    //public float speed=20f;
    private Joystick controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<Joystick>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    private void FixedUpdate()
    {
        if(!GameManager.gameManager.isCutScene)
        {
            Vector2 moveDir = Vector2.up * controller.Horizontal;
            player.transform.Rotate(moveDir * Time.fixedDeltaTime * playerController.rotSpeed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
