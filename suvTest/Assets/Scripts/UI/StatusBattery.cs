using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBattery : MonoBehaviour
{
    PlayerController player;

    public string statusType;
    public float lv2Value;
    public float lv3Value;
    public float lv4Value;
    public float lv5Value;
    public List<GameObject> battery_sp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();    
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerStatus();
        
    }

    public void CheckPlayerStatus()
    {
        if (statusType == "Speed")
        {
            if (player.speed >= lv2Value)
            {
                battery_sp[0].SetActive(true);
            }
            else if (player.speed >= lv3Value)
            {
                battery_sp[1].SetActive(true);
            }
            else if (player.speed >= lv4Value)
            {
                battery_sp[2].SetActive(true);
            }
            else if (player.speed >= lv5Value)
            {
                battery_sp[3].SetActive(true);
            }
        }
        else if (statusType == "Code")
        {
            /*if (value >= lv2Value)
            {
                battery_sp[0].SetActive(true);
            }
            else if (value >= lv3Value)
            {
                battery_sp[1].SetActive(true);
            }
            else if (value >= lv4Value)
            {
                battery_sp[2].SetActive(true);
            }
            else if (value >= lv5Value)
            {
                battery_sp[3].SetActive(true);
            }*/
        }
        else if(statusType=="Exp")
        {
            if (player.exp >= lv2Value)
            {
                battery_sp[0].SetActive(true);
            }
            else if (player.exp >= lv3Value)
            {
                battery_sp[1].SetActive(true);
            }
            else if (player.exp >= lv4Value)
            {
                battery_sp[2].SetActive(true);
            }
            else if (player.exp >= lv5Value)
            {
                battery_sp[3].SetActive(true);
            }
        }
        else if(statusType=="Hp")
        {
            if (player.hp >= lv2Value)
            {
                battery_sp[0].SetActive(true);
            }
            else if (player.hp >= lv3Value)
            {
                battery_sp[1].SetActive(true);
            }
            else if (player.hp >= lv4Value)
            {
                battery_sp[2].SetActive(true);
            }
            else if (player.hp >= lv5Value)
            {
                battery_sp[3].SetActive(true);
            }
        }
        


    }
}
