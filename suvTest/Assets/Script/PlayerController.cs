using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Time.deltaTime * speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -Time.deltaTime * speed);
        }
    }
}
