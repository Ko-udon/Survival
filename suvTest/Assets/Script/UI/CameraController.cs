using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float cameraSpeed = 5.0f;
    public GameObject player;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

    public float DelayTime;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir =
            new Vector3(player.transform.position.x + offsetX,
            player.transform.position.y + offsetY,
            player.transform.position.z + offsetZ);

        transform.position = dir;
        //transform.position = Vector3.Lerp(transform.position, dir, Time.deltaTime*DelayTime);
    }
}
