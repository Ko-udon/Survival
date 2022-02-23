using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float time;
    
    void Start()
    {
        time = 2.5f;
    }

    
    void Update()
    {
        time -= Time.deltaTime;

        if(time < 0)
        {
            Destroy(gameObject);
        }
    }
}
