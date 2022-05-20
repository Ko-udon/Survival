using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public float speed;
    //public float Updown;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos =new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, speed * Time.deltaTime, 0);
        
    }
}
