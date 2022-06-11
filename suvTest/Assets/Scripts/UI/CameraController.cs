using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    private float maxDir;
    RaycastHit hit;

    void Start()
    {
        player = transform.parent.gameObject;
        maxDir = (transform.position - player.transform.position).magnitude;
    }

    void Update()
    {
        //transform.LookAt(player.transform);

        if (Physics.Raycast(player.transform.position, (transform.position - player.transform.position).normalized, out hit, maxDir))
        {
            if(hit.transform.gameObject.tag == "Object" || hit.transform.gameObject.tag == "floor")
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + Vector3.forward, Time.deltaTime * 10);
                transform.position = hit.point;
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 2, -3.5f), Time.deltaTime * 5);
            }
        }
        
    }
}
