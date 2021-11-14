using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class test_Status : MonoBehaviour
{ 
    public Text dayText;
    public Text timeText;
    public Image HPGauge;
    public Image MTGauge;

    void Start()
    {
        dayText = GameObject.Find("DayText").GetComponent<Text>();
        timeText = GameObject.Find("TimeText").GetComponent<Text>();
        HPGauge = GameObject.Find("HPGauge").GetComponent<Image>();
        MTGauge = GameObject.Find("MTGauge").GetComponent<Image>();
    }

    void Update()
    {
        dayText.text = "Day " + GameManager.gameManager.day;
        if (GameManager.gameManager.time == 0)
        {
            timeText.text = "24 : 00";
        }
        else
        {
            string time = GameManager.gameManager.time.ToString("00.00");
            time = time.Replace(".", " : ");
            timeText.text = time;
        }
        HPGauge.fillAmount = GameManager.player.Hp / 100;
        MTGauge.fillAmount = GameManager.player.Mt / 100;
    }
}
