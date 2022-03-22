using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private List<GameObject> ballList;

    void Start()
    {
        ballList = new List<GameObject>();

        for(int i = 0; i < transform.childCount; i++)
        {
            ballList.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLV(int level)
    {
        foreach(GameObject ball in ballList)
        {
            ball.GetComponent<Ball>().damage = 20 * level;
        }
    }
}
