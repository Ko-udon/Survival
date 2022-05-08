using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public List<GameObject> ballList;
    public List<float> speedByLV;
    public List<float> damageByLV;


    private int level;

    void Start()
    {
        //ballList = new List<GameObject>();

        /*for(int i = 0; i < transform.childCount; i++)
        {
            ballList.Add(transform.GetChild(i).gameObject);
        }*/
    }

    void Update()
    {
        
    }

    public void UpdateLV(int level)
    {
        if(level > damageByLV.Count)
        {
            return;
        }


        if(level == 1)
        {
            ballList[0].SetActive(true);
            ballList[1].SetActive(false);
            ballList[2].SetActive(false);
            ballList[3].SetActive(false);
        }
        else if(level == 2)
        {
            ballList[1].SetActive(true);
        }
        else if(level == 4)
        {
            ballList[2].SetActive(true);
            ballList[3].SetActive(true);
        }

        foreach(GameObject ball in ballList)
        {
            this.level = level;
            ball.GetComponent<Ball>().speed = speedByLV[this.level - 1];
            ball.GetComponent<Ball>().damage = damageByLV[this.level - 1];
        }

        InitBall();
    }

    private void InitBall()
    {
        ballList[0].transform.localPosition = new Vector3(0, 0, -1.5f);
        ballList[1].transform.localPosition = new Vector3(0, 0, 1.5f);
        ballList[2].transform.localPosition = new Vector3(1.5f, 0, 0);
        ballList[3].transform.localPosition = new Vector3(-1.5f, 0, 0);
    }
}
