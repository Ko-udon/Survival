using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicJoystick_ko : MonoBehaviour
{
    public Transform player;
    public float speed=20f;
    private Joystick controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<Joystick>();

    }

    private void FixedUpdate()
    {
        Vector2 moveDir = Vector2.up * controller.Horizontal;
        player.transform.Rotate(moveDir * Time.fixedDeltaTime * speed);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
